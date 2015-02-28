using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace halvatta.API.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public int DinnerId { get; set; }

        public int UserId { get; set; }

        public int Rating { get; set; }
    }
}