"use client";

import { useState } from "react";
import Link from "next/link";
import Image from "next/image";

export default function Header() {
  const [tickerVisible, setTickerVisible] = useState(true);

  return (
    <header className="w-full">
      {tickerVisible && (
        <div className="border-b border-gray-800 relative">
          <Image
            src="/images/Home/Group.jpg"
            alt="background pattern"
            fill
            className="object-cover opacity-50"
            priority
          />
          <div className="container mx-auto px-4 py-4 flex items-center justify-center relative z-10">
            <div className="flex items-center gap-2 text-sm text-gray-300">
              <span className="text-yellow-400">✨</span>
              <span>Discover Your Dream Property with Estatein</span>
              <Link
                href="#" 
                className="text-white underline hover:text-gray-300 transition-colors ml-1"
              >
                Learn More
              </Link>
            </div>
            <button
              onClick={() => setTickerVisible(false)}
              className="absolute right-4 text-gray-400 hover:text-white transition-colors text-xl z-20"
              aria-label="Close banner"
              >
                x
            </button>
          </div>
        </div>
      )}

      {/* Main Navigation */}
      <nav className="bg-[#0f0f1e] border-b border-gray-800">
        <div className="container mx-auto px-4">
          <div className="flex items-center justify-between h-23">
            {/* Logo */}
            <Link href="/" className="flex items-center group">
              <div className="w-40 h-20 rounded-lg flex items-center justify-center overflow-hidden">
                <Image
                  src="/images/Home/Logo.jpg"
                  alt="Estatein Logo"
                  width={160}
                  height={160}
                  className="object-contain"
                />
              </div>
              <span className="text-white font-semibold text-xl group-hover:text-purple-400 transition-colors">
                Estatein
              </span>
            </Link>

            {/* Center Navigation Links */}
            <div className="hidden md:flex items-center gap-2.5">
              <Link
                href="/home"
                className="px-6 py-2.5 text-white bg-[#1a1a2e] rounded-lg hover:bg-[#252538] transition-colors"
              >
                Home
              </Link>
              <Link
                href="/about"
                className="px-6 py-2.5 text-gray-300 hover:text-white hover:bg-[#1a1a2e] rounded-lg transition-colors"
              >
                About Us
              </Link>
              <Link
                href="/properties"
                className="px-6 py-2.5 text-gray-300 hover:text-white hover:bg-[#1a1a2e] rounded-lg transition-colors"
              >
                Properties
              </Link>
              <Link
                href="/services"
                className="px-6 py-2.5 text-gray-300 hover:text-white hover:bg-[#1a1a2e] rounded-lg transition-colors"
              >
                Services
              </Link>
            </div>

            {/* Contact Button */}
            <Link
              href="/contact"
              className="hidden sm:block px-6 py-2.5 text-white border border-gray-700 rounded-lg hover:bg-[#1a1a2e] hover:border-gray-600 transition-all"
            >
              Contact Us
            </Link>

            {/* Mobile Menu Button */}
            <button className="md:hidden text-white text-2xl">
              ☰
            </button>
          </div>
        </div>
      </nav>
    </header>
  )
}
