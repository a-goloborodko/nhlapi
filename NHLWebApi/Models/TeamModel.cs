using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHLWebApi.Models
{
    public class TeamModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Abbreviation { get; set; }
        public string TeamName { get; set; }
        public string LocationName { get; set; }
        public int FirstYearOfPlay { get; set; }
        public long DivisionId { get; set; }
        public long ConferenceId { get; set; }
        public string OfficialSiteUrl { get; set; }
        public string ShortName { get; set; }
        public bool Active { get; set; }
    }
}