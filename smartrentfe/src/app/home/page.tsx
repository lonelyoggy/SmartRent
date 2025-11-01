"use client";

import Link from "next/link";
import Image from "next/image";
import { ArrowUpRight } from "lucide-react";

export default function HomePage() {
  return (
    <main className="min-h-screen bg-[#0a0a0f] text-white">
      {/* Hero Section */}
      <section className="relative min-h-[90vh] flex items-center overflow-hidden">
        {/* Background Buildings - Right Side */}
        <div className="bg-[#13131c] absolute right-0 top-0 w-1/2 bottom-0 z-0">
          <Image
            src="/images/Home/Buildings.png"
            alt="Modern buildings"
            fill
            className="object-cover"
            priority
          />
        </div>

        <div className="container mx-auto px-4 relative z-10">
          <div className="grid md:grid-cols-2 gap-12 items-center">
            {/* Left Content */}
            <div className="space-y-8">
              <h1 className="text-6xl md:text-7xl font-bold leading-tight">
                Discover Your Dream Property With Estatein
              </h1>

              <p className="text-gray-300 text-lg leading-relaxed">
                Your journey to finding the perfect property begins here.
                Explore our listings to find the home that matches your dreams.
              </p>

              {/* Call-to-Action Buttons */}
              <div className="flex gap-4">
                <button className="px-6 py-3 border border-gray-700 rounded-lg hover:bg-[#1a1a2e] transition-all">
                  Learn More
                </button>
                <button className="px-6 py-3 bg-purple-600 rounded-lg hover:bg-purple-700 transition-all">
                  Browse Properties
                </button>
              </div>

              {/* Stats */}
              <div className="grid grid-cols-3 gap-6 pt-8">
                <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-6">
                  <div className="text-3xl font-bold mb-2">200+</div>
                  <div className="text-gray-400 text-sm">Happy Customers</div>
                </div>
                <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-6">
                  <div className="text-3xl font-bold mb-2">10k+</div>
                  <div className="text-gray-400 text-sm">
                    Properties For Clients
                  </div>
                </div>
                <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-6">
                  <div className="text-3xl font-bold mb-2">16+</div>
                  <div className="text-gray-400 text-sm">
                    Years of Experience
                  </div>
                </div>
              </div>
            </div>

            {/* Right Side - Empty for buildings */}
            <div className="hidden md:block"></div>
          </div>
        </div>

        {/* Circular Badge - Centered and Overlaying */}
        <div className="hidden md:flex absolute left-1/2 top-73 -translate-x-1/2 -translate-y-1/2 z-20">
          <div className="relative w-48 h-48">
            {/* Outer Circle */}
            <div className="bg-[#0a0a0f] absolute inset-0 border-2 border-gray-800 rounded-full"></div>

            {/* Curved Text using SVG */}
            <svg
              className="absolute inset-0 w-full h-full -rotate-90"
              viewBox="0 0 200 200"
            >
              <defs>
                <path
                  id="circlePath"
                  d="M 100, 100 m -75, 0 a 75,75 0 1,1 150,0 a 75,75 0 1,1 -150,0"
                />
              </defs>
              <text
                className="fill-white uppercase tracking-[0.4em]"
                style={{ fontSize: "15px", fontWeight: 500 }}
              >
                <textPath href="#circlePath" startOffset="10%">
                  Your Dream Property Design ✨
                </textPath>
              </text>
            </svg>

            {/* Center Circle with Arrow */}
            <div className="absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2 w-22 h-22 border-2 border-gray-800 rounded-full flex items-center justify-center bg-[#0a0a0f]">
              <ArrowUpRight
                className="w-12 h-12 text-white"
                strokeWidth={1.5}
              />
            </div>
          </div>
        </div>
      </section>

      {/* Features Section */}
      <section className="py-20 bg-[#0f0f1e]">
        <div className="container mx-auto px-4">
          <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-6">
            {/* Feature Card 1 */}
            <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-8 hover:border-purple-600 transition-all group relative">
              <div className="absolute top-6 right-6">
                <ArrowUpRight className="w-6 h-6 text-gray-600 group-hover:text-purple-600 transition-colors" />
              </div>

              <div className="w-16 h-16 bg-purple-600/20 rounded-full flex items-center justify-center mb-6">
                <svg
                  className="w-8 h-8 text-purple-600"
                  fill="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path d="M10 20v-6h4v6h5v-8h3L12 3 2 12h3v8z" />
                </svg>
              </div>

              <h3 className="text-xl font-semibold mb-3">
                Find Your Dream Home
              </h3>
            </div>

            {/* Feature Card 2 */}
            <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-8 hover:border-purple-600 transition-all group relative">
              <div className="absolute top-6 right-6">
                <ArrowUpRight className="w-6 h-6 text-gray-600 group-hover:text-purple-600 transition-colors" />
              </div>

              <div className="w-16 h-16 bg-purple-600/20 rounded-full flex items-center justify-center mb-6">
                <svg
                  className="w-8 h-8 text-purple-600"
                  fill="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 3c1.66 0 3 1.34 3 3s-1.34 3-3 3-3-1.34-3-3 1.34-3 3-3zm0 14.2c-2.5 0-4.71-1.28-6-3.22.03-1.99 4-3.08 6-3.08 1.99 0 5.97 1.09 6 3.08-1.29 1.94-3.5 3.22-6 3.22z" />
                </svg>
              </div>

              <h3 className="text-xl font-semibold mb-3">
                Unlock Property Value
              </h3>
            </div>

            {/* Feature Card 3 */}
            <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-8 hover:border-purple-600 transition-all group relative">
              <div className="absolute top-6 right-6">
                <ArrowUpRight className="w-6 h-6 text-gray-600 group-hover:text-purple-600 transition-colors" />
              </div>

              <div className="w-16 h-16 bg-purple-600/20 rounded-full flex items-center justify-center mb-6">
                <svg
                  className="w-8 h-8 text-purple-600"
                  fill="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path d="M3 13h8V3H3v10zm0 8h8v-6H3v6zm10 0h8V11h-8v10zm0-18v6h8V3h-8z" />
                </svg>
              </div>

              <h3 className="text-xl font-semibold mb-3">
                Effortless Property Management
              </h3>
            </div>

            {/* Feature Card 4 */}
            <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-8 hover:border-purple-600 transition-all group relative">
              <div className="absolute top-6 right-6">
                <ArrowUpRight className="w-6 h-6 text-gray-600 group-hover:text-purple-600 transition-colors" />
              </div>

              <div className="w-16 h-16 bg-purple-600/20 rounded-full flex items-center justify-center mb-6">
                <svg
                  className="w-8 h-8 text-purple-600"
                  fill="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path d="M12 2l3.09 6.26L22 9.27l-5 4.87 1.18 6.88L12 17.77l-6.18 3.25L7 14.14 2 9.27l6.91-1.01L12 2z" />
                </svg>
              </div>

              <h3 className="text-xl font-semibold mb-3">
                Smart Investments. Informed Decisions
              </h3>
            </div>
          </div>
        </div>
      </section>
    </main>
  );
}
