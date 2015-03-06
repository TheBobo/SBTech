using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Race.Models
{
    public class RaceEvent
    {
        public int Id { get; set; }
        public int EventNumber { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime FinishTime { get; set; }
        public Decimal Distance { get; set; }
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }

        public RaceEvent()
        {
            Entries= new List<Entry>();
        }
    }
    }
