"use client";

export default function LoginForm() {
	return (
		<form className="flex flex-col gap-3 max-w-sm">
			<label className="flex flex-col text-sm">
				<span className="mb-1">Email</span>
				<input className="px-3 py-2 rounded bg-white/5" type="email" />
			</label>

			<label className="flex flex-col text-sm">
				<span className="mb-1">Password</span>
				<input className="px-3 py-2 rounded bg-white/5" type="password" />
			</label>

			<button className="mt-2 rounded bg-purple-600 px-4 py-2 text-white">Sign in</button>
		</form>
	);
}

