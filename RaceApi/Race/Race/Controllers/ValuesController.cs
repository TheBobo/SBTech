using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Xml;
using Race.Models;

namespace Race.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values/5
        public List<RaceEvent> Get(int sortByName = 0, int sortByOddNumber = 0)
        {
            string result = HostingEnvironment.MapPath("\\Race.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(result);
            XmlNodeList elemList = doc.GetElementsByTagName("RaceEvent");
            //for (int i = 0; i < elemList.Count; i++)
            List<RaceEvent> raceEvents = new List<RaceEvent>();

            foreach (XmlNode elem in elemList)
            {
                var raceEvent = new RaceEvent();
                raceEvent.Id = int.Parse(elem.Attributes["ID"].Value);
                raceEvent.EventNumber = int.Parse(elem.Attributes["EventNumber"].Value);
                raceEvent.EventTime = DateTime.Parse(elem.Attributes["EventTime"].Value);
                raceEvent.FinishTime = DateTime.Parse(elem.Attributes["FinishTime"].Value);
                raceEvent.Distance = decimal.Parse(elem.Attributes["Distance"].Value);
                raceEvent.Name = elem.Attributes["Name"].Value;

                foreach (XmlNode node in elem.ChildNodes)
                {
                    if (node.Name == "Entry")
                    {
                        var entry = new Entry();
                        entry.Id = int.Parse(node.Attributes["ID"].Value);
                        entry.Name = node.Attributes["Name"].Value;
                        entry.OddNumber = decimal.Parse(node.Attributes["OddsDecimal"].Value);
                        raceEvent.Entries.Add(entry);
                    }
                }

                if (sortByName == 1)
                {
                    raceEvent.Entries = raceEvent.Entries.OrderBy(x => x.Name).ToList();
                }
                else if (sortByName == -1)
                    {
                        raceEvent.Entries = raceEvent.Entries.OrderByDescending(x => x.Name).ToList();
                    }

                if (sortByOddNumber == 1)
                {
                    raceEvent.Entries = raceEvent.Entries.OrderBy(x => x.OddNumber).ToList();
                }
                else if (sortByOddNumber == -1)
                {
                    raceEvent.Entries = raceEvent.Entries.OrderByDescending(x => x.OddNumber).ToList();
                }
                raceEvents.Add(raceEvent);
            }

     

            return raceEvents;
            //var t= Json.Encode(raceEvents);

            //return t; //raceEvents;
        }

    }
}