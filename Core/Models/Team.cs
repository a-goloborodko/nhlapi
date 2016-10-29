using System.Collections.Generic;

namespace Core.Models
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Abbreviation { get; set; }
        public string TeamName { get; set; }
        public string LocationName { get; set; }
        public int FirstYearOfPlay { get; set; }
        public long DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public long ConferenceId { get; set; }
        public virtual Conference Conference { get; set; }
        public string OfficialSiteUrl { get; set; }
        public string ShortName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<TeamStatistic> TeamStats { get; set; }
        public virtual ICollection<TeamDetailStatistic> TeamDetailStatistics { get; set; }
    }
}
