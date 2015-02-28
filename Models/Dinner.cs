using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace halvatta.API.Models
{
    public class Dinner
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public int HostUserId { get; set; }

        public IEnumerable<ApplicationUser> Participants { get; set; }
 
        public DateTime StartDate { get; set; }

        public IEnumerable<Vote> Votes { get; set; } 
    }
}