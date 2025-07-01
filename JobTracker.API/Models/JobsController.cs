using System;

namespace JobApplicationTracker.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = "Wishlist"; // e.g., Wishlist, Applied, Interview, Offer, Rejected
        public DateTime DateApplied { get; set; }
        public string Link { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}

