using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace halvatta.API.Models
{
    public class Event
    {
        public int Id { get; set; }

        public int HostUserId { get; set; }

        public string EventName { get; set; }

        public EventState EventState { get; set; }

        public EventTheme Theme { get; set; }

        public IEnumerable<Dinner> Dinners { get; set; }

        public IEnumerable<ApplicationUser> Participants { get; set; } 
    }

    [Flags]
    public enum EventState
    {
        NotStarted,
        OnGoing,
        Ended
    }

    [Flags]
    public enum EventTheme
    {
        Countries
    }
}