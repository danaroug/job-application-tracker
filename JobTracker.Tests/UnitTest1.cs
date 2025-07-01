namespace JobTracker.Tests;

using Xunit; // For [Fact] and assertions
using Moq; // For mocking (not used yet, but ready for future tests)
using Microsoft.AspNetCore.Mvc; // For IActionResult and controller results
using System.Collections.Generic; // For List<T>
using System.Threading.Tasks; // For async support
using Microsoft.EntityFrameworkCore; // For in-memory database
using JobApplicationTracker.Controllers; // Your API controller namespace
using JobApplicationTracker.Data; // Your DbContext namespace
using JobApplicationTracker.Models; // Your model namespace
using System.Linq; // For LINQ extensions
using System.Collections;

public class JobsControllerTests
{
    // Helper method to provide sample jobs for testing
    private List<Job> GetTestJobs()
    {
        return new List<Job>
        {
            new Job { Id = 1, Title = "Software Engineer", Company = "Acme Corp", Status = "Applied" },
            new Job { Id = 2, Title = "Web Developer", Company = "Beta LLC", Status = "Wishlist" }
        };
    }
   
    [Fact] // Marks this method as a test case to be run by xUnit
    public async Task GetJobs_ReturnsAllJobs()
    {
        // Arrange: Configure an in-memory database for testing
        var options = new DbContextOptionsBuilder<JobContext>()
            .UseInMemoryDatabase(databaseName: "JobListTestDb")
            .Options;

        // Use a 'using' block to ensure proper disposal of the context after the test
        using (var context = new JobContext(options))
        {
            // Seed the in-memory database with test data
            context.Jobs.AddRange(GetTestJobs());
            context.SaveChanges(); // Save changes to persist data in in-memory DB

            // Instantiate the controller, passing in the test DbContext
            var controller = new JobsController(context);

            // Act: Call the GetJobs method on the controller asynchronously
            var result = await controller.GetJobs();

            // Assert: Verify the result type and data
            var jobs = Assert.IsType<List<Job>>(result.Value); // Assert that the result's Value is a List<Job>
            Assert.Equal(2, jobs.Count); // Assert that we have exactly 2 jobs returned
            Assert.Equal("Software Engineer", jobs[0].Title); // Assert the first job's title is as expected
        }
    }
    [Fact] // Marks this method as a test case to be run by xUnit
    public async Task GetJobs_ReturnsOnlyJobsWithStatusApplied()

    {
        // Arrange: Configure an in-memory database for testing
        var options = new DbContextOptionsBuilder<JobContext>()
            .UseInMemoryDatabase(databaseName: "JobListTestDb")
            .Options;
        

        // Use a 'using' block to ensure proper disposal of the context after the test
        using (var context = new JobContext(options))
        {
            // Seed the in-memory database with test data
            context.Jobs.AddRange(GetTestJobs());
            context.SaveChanges();

            // Instantiate the controller, passing in the test DbContext
            var controller = new JobsController(context);

            // Act: Call the GetJobs method on the controller asynchronously
            var result = await controller.GetJobs();

            // Assert: Verify the result type and data
            var jobs = Assert.IsType<List<Job>>(result.Value); // get the List<Job> from ActionResult
            Assert.All(jobs, job => Assert.Equal("Applied", job.Status));

        }
    }
}

