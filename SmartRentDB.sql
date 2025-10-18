------------------------------------------------------------
-- CREATE DATABASE (nếu chưa có) & CHỌN DATABASE
------------------------------------------------------------
IF DB_ID(N'SmartRent') IS NULL
BEGIN
    CREATE DATABASE SmartRent;
    PRINT 'Database SmartRent created.';
END
ELSE
BEGIN
    PRINT 'Database SmartRent already exists.';
END
GO

USE SmartRent;
GO

------------------------------------------------------------
-- XÓA CÁC BẢNG NẾU TỒN TẠI (theo thứ tự tránh FK conflict)
------------------------------------------------------------
DROP TABLE IF EXISTS AI_SearchLogs;
DROP TABLE IF EXISTS Comments;
DROP TABLE IF EXISTS BlogPosts;
DROP TABLE IF EXISTS Payments;
DROP TABLE IF EXISTS Bookings;
DROP TABLE IF EXISTS RoomImages;
DROP TABLE IF EXISTS Rooms;
DROP TABLE IF EXISTS Apartments;
DROP TABLE IF EXISTS Users;
GO

------------------------------------------------------------
-- TẠO BẢNG: Users
------------------------------------------------------------
CREATE TABLE dbo.Users
(
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(20) NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN (N'Admin', N'Owner', N'Customer')),
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2 NULL
);
GO

------------------------------------------------------------
-- TẠO BẢNG: Apartments
-- Lưu ý: khi xóa user -> không tự động xóa apartments (NO ACTION)
-- để tránh multiple cascade paths; admin xử lý thủ công (hoặc soft-delete)
------------------------------------------------------------
CREATE TABLE dbo.Apartments
(
    ApartmentID INT IDENTITY(1,1) PRIMARY KEY,
    OwnerID INT NOT NULL,
    Name NVARCHAR(150) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Latitude DECIMAL(10,6) NULL,
    Longitude DECIMAL(10,6) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_Apartments_Users FOREIGN KEY (OwnerID)
        REFERENCES dbo.Users(UserID)
        ON DELETE NO ACTION
);
GO

CREATE INDEX IX_Apartments_OwnerID ON dbo.Apartments(OwnerID);
GO

------------------------------------------------------------
-- TẠO BẢNG: Rooms
-- Nếu xóa Apartment => xóa Rooms (CASCADE)
------------------------------------------------------------
CREATE TABLE dbo.Rooms
(
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    ApartmentID INT NOT NULL,
    Title NVARCHAR(150) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Area DECIMAL(10,2) NULL CHECK (Area > 0),
    Price DECIMAL(18,2) NOT NULL CHECK (Price >= 0),
    NumBedrooms INT NULL CHECK (NumBedrooms >= 0),
    NumBathrooms INT NULL CHECK (NumBathrooms >= 0),
    IsAvailable BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Rooms_Apartments FOREIGN KEY (ApartmentID)
        REFERENCES dbo.Apartments(ApartmentID)
        ON DELETE CASCADE
);
GO

CREATE INDEX IX_Rooms_ApartmentID ON dbo.Rooms(ApartmentID);
GO

------------------------------------------------------------
-- TẠO BẢNG: RoomImages
-- Xóa Room => xóa RoomImages
------------------------------------------------------------
CREATE TABLE dbo.RoomImages
(
    ImageID INT IDENTITY(1,1) PRIMARY KEY,
    RoomID INT NOT NULL,
    ImageUrl NVARCHAR(500) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_RoomImages_Rooms FOREIGN KEY (RoomID)
        REFERENCES dbo.Rooms(RoomID)
        ON DELETE CASCADE
);
GO

CREATE INDEX IX_RoomImages_RoomID ON dbo.RoomImages(RoomID);
GO

------------------------------------------------------------
-- TẠO BẢNG: Bookings
-- Xóa Room => xóa Bookings (CASCADE)
-- Xóa Customer (User) => KHÔNG xóa booking (NO ACTION) để lưu lịch sử
------------------------------------------------------------
CREATE TABLE dbo.Bookings
(
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    RoomID INT NOT NULL,
    CustomerID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL CHECK (TotalAmount >= 0),
    Commission AS (TotalAmount * 0.1) PERSISTED,
    Status NVARCHAR(50) NOT NULL DEFAULT N'Pending' CHECK (Status IN (N'Pending', N'Confirmed', N'Cancelled', N'Completed')),
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Bookings_Rooms FOREIGN KEY (RoomID)
        REFERENCES dbo.Rooms(RoomID)
        ON DELETE CASCADE,
    CONSTRAINT FK_Bookings_Users FOREIGN KEY (CustomerID)
        REFERENCES dbo.Users(UserID)
        ON DELETE NO ACTION,
    CONSTRAINT CK_Bookings_Dates CHECK (StartDate < EndDate)
);
GO

CREATE INDEX IX_Bookings_RoomID ON dbo.Bookings(RoomID);
CREATE INDEX IX_Bookings_CustomerID ON dbo.Bookings(CustomerID);
GO

------------------------------------------------------------
-- TẠO BẢNG: Payments
-- Xóa Booking => xóa Payment
------------------------------------------------------------
CREATE TABLE dbo.Payments
(
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    BookingID INT NOT NULL,
    PaymentDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    PaymentMethod NVARCHAR(50) NULL,
    Amount DECIMAL(18,2) NOT NULL CHECK (Amount >= 0),
    CommissionAmount DECIMAL(18,2) NULL,
    CONSTRAINT FK_Payments_Bookings FOREIGN KEY (BookingID)
        REFERENCES dbo.Bookings(BookingID)
        ON DELETE CASCADE
);
GO

CREATE INDEX IX_Payments_BookingID ON dbo.Payments(BookingID);
GO

------------------------------------------------------------
-- TẠO BẢNG: BlogPosts
-- Xóa User => KHÔNG xóa blog tự động (NO ACTION) để tránh mất nội dung; admin xử lý
------------------------------------------------------------
CREATE TABLE dbo.BlogPosts
(
    PostID INT IDENTITY(1,1) PRIMARY KEY,
    AuthorID INT NOT NULL,
    Title NVARCHAR(255) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_BlogPosts_Users FOREIGN KEY (AuthorID)
        REFERENCES dbo.Users(UserID)
        ON DELETE NO ACTION
);
GO

CREATE INDEX IX_BlogPosts_AuthorID ON dbo.BlogPosts(AuthorID);
GO

------------------------------------------------------------
-- TẠO BẢNG: Comments
-- Xóa BlogPost => xóa Comments
-- Xóa User => KHÔNG xóa comment tự động (NO ACTION) để giữ lịch sử; hoặc có thể set tên "deleted user"
-- RoomSuggestionID nếu xóa Room => để NULL
------------------------------------------------------------
CREATE TABLE dbo.Comments
(
    CommentID INT IDENTITY(1,1) PRIMARY KEY,
    PostID INT NOT NULL,
    AuthorID INT NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    RoomSuggestionID INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Comments_BlogPosts FOREIGN KEY (PostID)
        REFERENCES dbo.BlogPosts(PostID)
        ON DELETE CASCADE,
    CONSTRAINT FK_Comments_Users FOREIGN KEY (AuthorID)
        REFERENCES dbo.Users(UserID)
        ON DELETE NO ACTION,
    CONSTRAINT FK_Comments_Rooms FOREIGN KEY (RoomSuggestionID)
        REFERENCES dbo.Rooms(RoomID)
        ON DELETE SET NULL
);
GO

CREATE INDEX IX_Comments_PostID ON dbo.Comments(PostID);
CREATE INDEX IX_Comments_AuthorID ON dbo.Comments(AuthorID);
GO

------------------------------------------------------------
-- TẠO BẢNG: AI_SearchLogs
-- Xóa User => KHÔNG xóa search logs (NO ACTION) để giữ lịch sử AI training; admin xử lý
------------------------------------------------------------
CREATE TABLE dbo.AI_SearchLogs
(
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    SearchQuery NVARCHAR(500) NULL,
    Preferences NVARCHAR(MAX) NULL, -- JSON/text
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_AI_SearchLogs_Users FOREIGN KEY (UserID)
        REFERENCES dbo.Users(UserID)
        ON DELETE NO ACTION
);
GO

CREATE INDEX IX_AI_SearchLogs_UserID ON dbo.AI_SearchLogs(UserID);
GO

------------------------------------------------------------
-- MOCK DATA (INSERT)
------------------------------------------------------------
BEGIN TRANSACTION;

-- USERS
INSERT INTO dbo.Users (FullName, Email, PasswordHash, Phone, Role)
VALUES
(N'Admin System', N'admin@smartrent.vn', N'HASHED_ADMIN', N'0909000000', N'Admin'),
(N'Nguyen Van A', N'a@smartrent.vn', N'HASHED_OWNER_A', N'0909111111', N'Owner'),
(N'Tran Thi B', N'b@smartrent.vn', N'HASHED_CUSTOMER_B', N'0909222222', N'Customer'),
(N'Le Van C', N'c@smartrent.vn', N'HASHED_OWNER_C', N'0909333333', N'Owner'),
(N'Pham Thi D', N'd@smartrent.vn', N'HASHED_CUSTOMER_D', N'0909444444', N'Customer');

-- APARTMENTS
INSERT INTO dbo.Apartments (OwnerID, Name, Address, Description, Latitude, Longitude)
VALUES
(2, N'Luxury Riverside Apartment', N'12 Nguyễn Hữu Cảnh, Q. Bình Thạnh, TP.HCM', N'Căn hộ cao cấp view sông Sài Gòn', 10.791234, 106.721234),
(4, N'Sunrise City View', N'25 Nguyễn Hữu Thọ, Q.7, TP.HCM', N'Căn hộ hiện đại có hồ bơi và phòng gym', 10.737890, 106.697123);

-- ROOMS
INSERT INTO dbo.Rooms (ApartmentID, Title, Description, Area, Price, NumBedrooms, NumBathrooms)
VALUES
(1, N'Phòng Master View Sông', N'Phòng lớn có ban công, nội thất sang trọng', 40.50, 15000000.00, 1, 1),
(1, N'Phòng Nhỏ Tiện Nghi', N'Phòng nhỏ, đầy đủ tiện ích, phù hợp sinh viên', 25.00, 9000000.00, 1, 1),
(2, N'Phòng Studio Hiện Đại', N'Thiết kế mở, đầy ánh sáng, view thành phố', 35.00, 12000000.00, 1, 1);

-- ROOM IMAGES
INSERT INTO dbo.RoomImages (RoomID, ImageUrl)
VALUES
(1, N'https://cdn.smartrent.vn/room1_1.jpg'),
(1, N'https://cdn.smartrent.vn/room1_2.jpg'),
(2, N'https://cdn.smartrent.vn/room2_1.jpg'),
(3, N'https://cdn.smartrent.vn/room3_1.jpg');

-- BOOKINGS
INSERT INTO dbo.Bookings (RoomID, CustomerID, StartDate, EndDate, TotalAmount, Status)
VALUES
(1, 3, '2025-10-10', '2025-11-10', 15000000.00, N'Confirmed'),
(3, 5, '2025-11-01', '2025-12-01', 12000000.00, N'Pending');

-- PAYMENTS
INSERT INTO dbo.Payments (BookingID, PaymentMethod, Amount, CommissionAmount)
VALUES
(1, N'Credit Card', 15000000.00, 1500000.00),
(2, N'Bank Transfer', 12000000.00, 1200000.00);

-- BLOG POSTS
INSERT INTO dbo.BlogPosts (AuthorID, Title, Content)
VALUES
(3, N'Tìm căn hộ 1 phòng ngủ khu Bình Thạnh', N'Mình đang tìm căn hộ 1 phòng ngủ, giá tầm 10-12 triệu/tháng.'),
(5, N'Tìm căn hộ có hồ bơi ở Q7', N'Mình muốn thuê căn hộ có hồ bơi, view đẹp.');

-- COMMENTS
INSERT INTO dbo.Comments (PostID, AuthorID, Content, RoomSuggestionID)
VALUES
(1, 2, N'Mình có căn hộ Riverside phù hợp, bạn xem thử nha!', 2),
(2, 4, N'Căn Sunrise City của mình có hồ bơi, giá 12 triệu.', 3);

-- AI SEARCH LOGS
INSERT INTO dbo.AI_SearchLogs (UserID, SearchQuery, Preferences)
VALUES
(3, N'Căn hộ 1 phòng ngủ gần Bình Thạnh', N'{"priceRange":"8-12tr","area":"Bình Thạnh","bedrooms":1}'),
(5, N'Căn hộ có hồ bơi quận 7', N'{"priceRange":"10-13tr","area":"Quận 7","amenities":["pool"]}');

COMMIT;
GO

PRINT '✅ SmartRent schema + mock data created successfully (with CREATE DATABASE).';
GO
