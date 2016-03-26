using System.Collections.Generic;

namespace Core.Data
{
   public class Division:BaseEntity
    {
       public Division()
       {
           Teams = new HashSet<Team>();
       }

        public string Name { get; set; }
        public string Abbreviation{ get; set; }
        public string Link { get; set; }
        public long ConferenceId { get; set; }
        public virtual Conference Conference { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
