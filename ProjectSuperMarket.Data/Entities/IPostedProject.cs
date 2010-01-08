using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectSuperMarket.Data
{
    public interface IPostedProject
    {
        string PartitionKey { get; set; }
        string RowKey { get; set; }

        string ProjectTitle { get; set; }
        string ProjectCategory { get; set; }
        string ProjectSubCategory { get; set; }
        string WorkDescription { get; set; }
        string BudgetRange { get; set; }
        double MinimumBid { get; set; }
        double MaximumBid { get; set; }
        int DaysBidStaysAlive { get; set; }
        string ProjectStarts { get; set; }
        string BiddingEnds { get; set; }
        string WhoCanBid { get; set; }
        string PromotionalCode { get; set; }
        bool CanBeDoneRemotely { get; set; }
        bool FeaturedProject { get; set; }
        bool NonPublicProject { get; set; }
        bool HideBids { get; set; }
        bool FullTime { get; set; }
        string UserEmailId { get; set; }
        string UserName { get; set; }
    }
}
