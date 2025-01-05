import fetch from "node-fetch";
import * as https from "https";

export default async function Placeholder() {
	let message = "Could not get message";
	try {
		console.log("Fetching data from endpoint");
		// Fetching logic
		const agent = new https.Agent({ rejectUnauthorized: false });
		const options = {
			method: "GET",
			headers: {
				"Content-Type": "application/json",
			},
			agent: agent,
		};
		const result = await fetch("https://localhost:32769/Placeholder", options);

		console.log(`Response Status: ${result.status}`, result.statusText);

		if (!result.ok) {
			throw new Error(`Server Error: ${result.status} ${result.statusText}`);
		}
		const jsonResponse = await result.json();
		message = jsonResponse.message;
	} catch (error) {
		console.error("Fetch Error:", error);
		message = `An error occurred while fetching data ${error}`;
	}

	return (
		<div>
			<h1>Fetched Data:</h1>
			<h2>{message}</h2>
		</div>
	);
}
