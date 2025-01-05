import Link from "next/link";

export default function home() {
	return (
		<div>
			<h1>Home Placeholder</h1>
			<Link href="/data" about="Takes you to the data page">
				<button>Go to Data Page</button>
			</Link>
		</div>
	);
}
