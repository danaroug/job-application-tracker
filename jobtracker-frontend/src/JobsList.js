import React, { useEffect, useState } from 'react';

// JobsList component fetches and displays a list of jobs from the backend API
function JobsList() {
  // State to store the list of jobs fetched from the API
  const [jobs, setJobs] = useState([]);
  // State to track loading status while fetching data
  const [loading, setLoading] = useState(true);

  // useEffect runs once after the component mounts to fetch jobs data
  useEffect(() => {
    // Fetch jobs data from the API endpoint
    fetch('https://localhost:7054/api/jobs')
      .then((res) => {
        // Check if the response status is OK (status code 200-299)
        if (!res.ok) throw new Error('Network response was not ok');
        // Parse response as JSON
        return res.json();
      })
      .then((data) => {
        // Update the jobs state with the fetched data
        setJobs(data);
        // Set loading to false since data is fetched
        setLoading(false);
      })
      .catch((error) => {
        // Log any error that occurs during fetch
        console.error('Fetch error:', error);
        // Set loading to false even if there was an error to stop loading indicator
        setLoading(false);
      });
  }, []); // Empty dependency array means this effect runs only once

  // While loading, display a loading message
  if (loading) return <div>Loading jobs...</div>;

  // Render job listings or a message if no jobs found
  return (
    <div>
      <h2>Job Listings</h2>
      {jobs.length === 0 ? (
        // If no jobs, display this message
        <p>No jobs found.</p>
      ) : (
        // Otherwise, render a list of jobs
        <ul>
          {jobs.map((job) => (
            // Each job list item shows title, company, and status
            <li key={job.id}>
              <strong>{job.title}</strong> at {job.company} — Status: {job.status}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default JobsList;


