"use client";

import Link from "next/link";

export default function HomePage() {
  return (
    <main className="flex flex-col items-center justify-center min-h-screen bg-gray-50 text-gray-800">
      <h1 className="text-4xl font-bold mb-6">🏠 Welcome to SmartRent</h1>
      <p className="text-lg text-center max-w-md mb-8">
        SmartRent helps you find and manage apartments effortlessly with AI-powered tools.
      </p>
      <Link
        href="/login"
        className="px-6 py-3 bg-blue-600 text-white rounded-lg shadow hover:bg-blue-700 transition"
      >
        Go to Login
      </Link>
    </main>
  );
}
