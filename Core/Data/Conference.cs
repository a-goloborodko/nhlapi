using System.Collections.Generic;

namespace Core.Data
{
    public class Conference : BaseEntity
    {
        public Conference()
        {
            Divisions = new HashSet<Division>();
            Teams = new HashSet<Team>();
        }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Abbreviation { get; set; }
        public string ShortName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
