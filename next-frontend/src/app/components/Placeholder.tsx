

import fetch from "node-fetch";
import * as https from "https";

export default async function Placeholder() {
	let message = "Could not fetch from API";

	try {
		// Prep agent to accept data from .NET Backend with self-signed certificate
		const options =
		{
			agent:  new https.Agent({ rejectUnauthorized: false })
		};

		// Fetch data
		console.log("Fetching data from API");
		const result = await fetch("https://localhost:7218/api/profiles/2", options);
		const rawResponse = await result.text();
		console.log(`Raw Response: ${rawResponse}`);

		// Validate
		if (!result.ok) {
			throw new Error(`Server Error: ${result.status} ${result.statusText}`);
		}

		// Set message to display
		message = JSON.stringify(rawResponse);

	} 
	catch (error) 
	{
		console.error("Fetch Error:", error);
		message = `An error occured: ${error}`;
	}


	// Return tsx
	return (
		<div>
			<h1>Fetched Data:</h1>
			<h2>{message}</h2>
		</div>
	);
}
