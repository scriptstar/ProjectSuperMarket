using System;
using ProjectSuperMarket.Data;
using Microsoft.WindowsAzure.StorageClient;
using System.ComponentModel.DataAnnotations;

namespace ProjectSuperMarket.Data.Azure
{
    public class PostedProject : TableServiceEntity, IPostedProject
    {
        public PostedProject()
        {
            this.PartitionKey = "All";
            this.RowKey = "Title";
        }

        public PostedProject(string projectCategory, string projectTitle)
        {
            this.PartitionKey = projectCategory;
            this.RowKey = projectTitle;            
        }

        public string ProjectTitle { get; set; }
        
        public string ProjectCategory { get; set; }

        public string ProjectSubCategory { get; set; }

        public string WorkDescription { get; set; }
        
        public string BudgetRange { get; set; }

        public double MinimumBid { get; set; }

        public double MaximumBid { get; set; }

        public int DaysBidStaysAlive { get; set; }
        
        public string ProjectStarts { get; set; }

        public string BiddingEnds { get; set; }
        
        public string WhoCanBid { get; set; }
        
        public string PromotionalCode { get; set; }

        public bool CanBeDoneRemotely { get; set; }

        public bool FeaturedProject { get; set; }

        public bool NonPublicProject { get; set; }

        public bool HideBids { get; set; }

        public bool FullTime { get; set; }

        public string UserEmailId { get; set; }

        public string UserName { get; set; }

    }
}
