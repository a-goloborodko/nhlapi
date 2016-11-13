using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronization.Models.PlayerProfile
{
    public class PlayerModel
    {
        public int Id { get; set; }
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
        public TeamModel CurrentTeam { get; set; }
        public PositionModel PrimaryPosition { get; set; }
    }
}
