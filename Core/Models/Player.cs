using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Player : BaseEntity
    {
        public bool Active { get; set; }
        public string Position { get; set; }
        public bool AlternateCaptain { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Captain { get; set; }
        public long TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Link { get; set; }
        public string Nationality { get; set; }
        public int PrimaryNumber { get; set; }
        public bool Rookie { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
