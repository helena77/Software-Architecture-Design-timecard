using System;
using Newtonsoft.Json;
using restapi.Helpers;

namespace restapi.Models
{
    public class Transition
    {
        public Transition() { }

        public Transition(Event ev, TimecardStatus status)
        {
            // check the transition status
            // it cannot back to the draft state
            if (status != TimecardStatus.Draft) {
                this.OccurredAt = DateTime.UtcNow;
                this.TransitionedTo = status;
                this.Event = ev;
            }
        }

        public Transition(Event ev) : this(ev, TimecardStatus.Draft) { }

        public DateTime OccurredAt { get; set; }

        public TimecardStatus TransitionedTo { get; set; }

        [JsonProperty("detail")]
        public Event Event { get; set; }

        public override string ToString()
        {
            return PublicJsonSerializer.SerializeObjectIndented(this);
        }
    }
}