"use client";

import Link from "next/link";
import Image from "next/image";
import { ArrowUpRight } from "lucide-react";
import { TiHome } from "react-icons/ti";
import { IoPersonCircleOutline } from "react-icons/io5";
import { TbBuildings } from "react-icons/tb";
import { IoSunnySharp } from "react-icons/io5";

export default function HomePage() {
  return (
    <main className="min-h-screen bg-[#0a0a0f] text-white">
      {/* Hero Section */}
      <section className="relative min-h-[70vh] flex items-center overflow-hidden">
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

        <div className="container pl-24 relative z-10">
          <div className="grid md:grid-cols-2 items-center">
            {/* Left Content */}
            <div className="space-y-6">
              <h1 className="text-5xl md:text-6xl font-bold">
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
              <div className="grid grid-cols-3 gap-4 pt-8">
                <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-6">
                  <div className="text-3xl font-bold mb-2">200+</div>
                  <div className="text-gray-400 text-md">Happy Customers</div>
                </div>
                <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-6">
                  <div className="text-3xl font-bold mb-2">10k+</div>
                  <div className="text-gray-400 text-md">
                    Properties For Clients
                  </div>
                </div>
                <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-6">
                  <div className="text-3xl font-bold mb-2">16+</div>
                  <div className="text-gray-400 text-md">
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
          <div className="relative w-40 h-40">
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
        <div className="container mx-auto">
          <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-5">
            {/* Feature Card 1 */}
            <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-10 hover:border-purple-600 transition-all group relative">
              <div className="absolute top-6 right-6">
                <ArrowUpRight className="w-8 h-8 text-gray-600 group-hover:text-purple-600 transition-colors" />
              </div>

              <div className="w-16 h-16 bg-purple-600/20 rounded-full flex items-center justify-center mb-4 mt-4 mx-auto">
                <TiHome className="w-9 h-9 text-purple-600" />
              </div>

              <h3 className="text-lg font-semibold text-center">
                Find Your Dream Home
              </h3>
            </div>

            {/* Feature Card 2 */}
            <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-10 hover:border-purple-600 transition-all group relative">
              <div className="absolute top-6 right-6">
                <ArrowUpRight className="w-8 h-8 text-gray-600 group-hover:text-purple-600 transition-colors" />
              </div>

              <div className="w-16 h-16 bg-purple-600/20 rounded-full flex items-center justify-center mb-4 mt-4 mx-auto">
                <IoPersonCircleOutline className="w-9 h-9 text-purple-600" />
              </div>

              <h3 className="text-lg font-semibold text-center">
                Unlock Property Value
              </h3>
            </div>

            {/* Feature Card 3 */}
            <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-10 hover:border-purple-600 transition-all group relative">
              <div className="absolute top-6 right-6">
                <ArrowUpRight className="w-8 h-8 text-gray-600 group-hover:text-purple-600 transition-colors" />
              </div>

              <div className="w-16 h-16 bg-purple-600/20 rounded-full flex items-center justify-center mb-4 mt-4 mx-auto">
                <TbBuildings className="w-9 h-9 text-purple-600" />
              </div>

              <h3 className="text-lg font-semibold text-center">
                Effortless Property Management
              </h3>
            </div>

            {/* Feature Card 4 */}
            <div className="bg-[#1a1a2e] border border-gray-800 rounded-lg p-10 hover:border-purple-600 transition-all group relative">
              <div className="absolute top-6 right-6">
                <ArrowUpRight className="w-8 h-8 text-gray-600 group-hover:text-purple-600 transition-colors" />
              </div>

              <div className="w-16 h-16 bg-purple-600/20 rounded-full flex items-center justify-center mb-4 mt-4 mx-auto">
                <IoSunnySharp className="w-9 h-9 text-purple-600" />
              </div>

              <h3 className="text-lg font-semibold text-center">
                Smart Investments. Informed Decisions
              </h3>
            </div>
          </div>
        </div>
      </section>
    </main>
  );
}
