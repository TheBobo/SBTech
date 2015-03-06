using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Race.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal OddNumber { get; set; }

        public Entry() { }
    }
}