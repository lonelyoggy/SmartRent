import Link from "next/link";
import Image from "next/image";
import {
  FaFacebookF,
  FaLinkedinIn,
  FaTwitter,
  FaYoutube,
} from "react-icons/fa";
import { IoSend } from "react-icons/io5";

export default function Footer() {
  return (
    <footer className="bg-[#0a0a0f] text-white">
      {/* CTA Section */}
      <section className="relative border-y border-gray-800 overflow-hidden">
        {/* Grainy Background Image */}
        <div className="absolute inset-0 opacity-30">
          <Image
            src="/images/Footer/Grainy Background.png"
            alt="Grainy Background"
            fill
            className="object-cover"
          />
        </div>

        <div className="container mx-auto px-1 py-16 relative z-10">
          <div className="flex flex-col md:flex-row justify-between items-center gap-8">
            <div className="max-w-2xl">
              <h2 className="text-3xl md:text-4xl font-bold mb-4">
                Start Your Real Estate Journey Today
              </h2>
              <p className="text-gray-400">
                Your dream property is just a click away. Whether you're looking
                for a new home, a strategic investment, or expert real estate
                advice, Estatein is here to assist you every step of the way.
                Take the first step towards your real estate goals and explore
                our available properties or get in touch with our team for
                personalized assistance.
              </p>
            </div>
            <button className="px-8 py-4 bg-purple-600 rounded-lg hover:bg-purple-700 transition-all whitespace-nowrap">
              Explore Properties
            </button>
          </div>
        </div>
      </section>

      {/* Main Footer */}
      <div className="w-full px-4 py-16">
        <div className="flex justify-center mb-5">
          <div className="grid grid-cols-1 md:grid-cols-3 lg:grid-cols-7 gap-4 max-w-7xl w-full">
            {/* Brand Column */}
            <div className="lg:col-span-2 ml-[-50]">
              <div className="flex items-center mb-[-10] mt-[-40]">
                <div className="w-50 h-50 rounded-lg flex items-center justify-center overflow-hidden relative">
                  <Image
                    src="/images/Home/Logo.jpg"
                    alt="Estatein Logo"
                    fill
                    className="object-cover ml-5"
                  />
                </div>
                <span className="text-xl font-bold">Estatein</span>
              </div>

              {/* Email Subscription */}
              <div className="relative">
                <input
                  type="email"
                  placeholder="Enter Your Email"
                  className="w-88 bg-[#1a1a2e] mt-[-20] border border-gray-800 rounded-xl px-4 py-3 pr-12 focus:outline-none focus:border-purple-600 transition-colors"
                />
                <button className="absolute right-15 mt-[-7] top-1/2 -translate-y-1/2 w-8 h-8 bg-purple-600 rounded-xl flex items-center justify-center hover:bg-purple-700 transition-all">
                  <IoSend className="w-4 h-4" />
                </button>
              </div>
            </div>

            {/* Home Column */}
            <div>
              <h3 className="font-semibold mb-4">Home</h3>
              <ul className="space-y-3 text-gray-400">
                <li>
                  <Link
                    href="#hero"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Hero Section
                  </Link>
                </li>
                <li>
                  <Link
                    href="#features"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Features
                  </Link>
                </li>
                <li>
                  <Link
                    href="#properties"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Properties
                  </Link>
                </li>
                <li>
                  <Link
                    href="#testimonials"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Testimonials
                  </Link>
                </li>
                <li>
                  <Link
                    href="#faq"
                    className="hover:text-purple-600 transition-colors"
                  >
                    FAQ's
                  </Link>
                </li>
              </ul>
            </div>

            {/* About Us Column */}
            <div>
              <h3 className="font-semibold mb-4">About Us</h3>
              <ul className="space-y-3 text-gray-400">
                <li>
                  <Link
                    href="/about/story"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Our Story
                  </Link>
                </li>
                <li>
                  <Link
                    href="/about/works"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Our Works
                  </Link>
                </li>
                <li>
                  <Link
                    href="/about/how-it-works"
                    className="hover:text-purple-600 transition-colors"
                  >
                    How It Works
                  </Link>
                </li>
                <li>
                  <Link
                    href="/about/team"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Our Team
                  </Link>
                </li>
                <li>
                  <Link
                    href="/about/clients"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Our Clients
                  </Link>
                </li>
              </ul>
            </div>

            {/* Properties Column */}
            <div>
              <h3 className="font-semibold mb-4">Properties</h3>
              <ul className="space-y-3 text-gray-400">
                <li>
                  <Link
                    href="/properties/portfolio"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Portfolio
                  </Link>
                </li>
                <li>
                  <Link
                    href="/properties/categories"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Categories
                  </Link>
                </li>
              </ul>
            </div>

            {/* Services Column */}
            <div>
              <h3 className="font-semibold mb-4">Services</h3>
              <ul className="space-y-3 text-gray-400">
                <li>
                  <Link
                    href="/services/valuation"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Valuation Mastery
                  </Link>
                </li>
                <li>
                  <Link
                    href="/services/marketing"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Strategic Marketing
                  </Link>
                </li>
                <li>
                  <Link
                    href="/services/negotiation"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Negotiation Wizardry
                  </Link>
                </li>
                <li>
                  <Link
                    href="/services/closing"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Closing Success
                  </Link>
                </li>
                <li>
                  <Link
                    href="/services/management"
                    className="hover:text-purple-600 transition-colors"
                  >
                    Property Management
                  </Link>
                </li>
              </ul>
            </div>

            {/* Contact Us Column */}
            <div>
              <h3 className="font-semibold mb-4 whitespace-nowrap">
                Contact Us
              </h3>
              <ul className="space-y-3 text-gray-400">
                <li>
                  <Link
                    href="/contact/form"
                    className="hover:text-purple-600 transition-colors whitespace-nowrap"
                  >
                    Contact Form
                  </Link>
                </li>
                <li>
                  <Link
                    href="/contact/offices"
                    className="hover:text-purple-600 transition-colors whitespace-nowrap"
                  >
                    Our Offices
                  </Link>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>

      {/* Bottom Bar */}
      <div className="w-full px-4 py-8 border-t border-gray-800 bg-[#0f0f1e]">
        <div className="flex flex-col mr-30 ml-30 md:flex-row justify-between items-center gap-4 ">
          <div className="flex items-center gap-6 text-sm text-gray-100">
            <p>@2025 Estatein. All Rights Reserved</p>
            <Link
              href="/terms"
              className="hover:text-purple-600 transition-colors"
            >
              Terms & Conditions
            </Link>
          </div>

          {/* Social Media Icons */}
          <div className="flex gap-4">
            <a
              href="https://facebook.com"
              target="_blank"
              rel="noopener noreferrer"
              className="w-10 h-10 border border-gray-700 rounded-lg flex items-center justify-center hover:bg-[#1a1a2e] hover:border-purple-600 transition-all"
            >
              <FaFacebookF className="w-4 h-4" />
            </a>
            <a
              href="https://linkedin.com"
              target="_blank"
              rel="noopener noreferrer"
              className="w-10 h-10 border border-gray-700 rounded-lg flex items-center justify-center hover:bg-[#1a1a2e] hover:border-purple-600 transition-all"
            >
              <FaLinkedinIn className="w-4 h-4" />
            </a>
            <a
              href="https://twitter.com"
              target="_blank"
              rel="noopener noreferrer"
              className="w-10 h-10 border border-gray-700 rounded-lg flex items-center justify-center hover:bg-[#1a1a2e] hover:border-purple-600 transition-all"
            >
              <FaTwitter className="w-4 h-4" />
            </a>
            <a
              href="https://youtube.com"
              target="_blank"
              rel="noopener noreferrer"
              className="w-10 h-10 border border-gray-700 rounded-lg flex items-center justify-center hover:bg-[#1a1a2e] hover:border-purple-600 transition-all"
            >
              <FaYoutube className="w-4 h-4" />
            </a>
          </div>
        </div>
      </div>
    </footer>
  );
}
