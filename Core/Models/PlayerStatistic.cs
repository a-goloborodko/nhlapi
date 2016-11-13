using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class PlayerStatistic : BaseEntity
    {
        public long PlayerId { get; set; }
        public long SeasonId { get; set; }
        public int Assists { get; set; }
        public decimal FaceoffWinPctg { get; set; }
        public int GamesPlayed { get; set; }
        public int GameWinningGoals { get; set; }
        public int Goals { get; set; }
        public int OtGoals { get; set; }
        public int PenaltyMinutes { get; set; }
        public int PlusMinus { get; set; }
        public int Points { get; set; }
        public int PpGoals { get; set; }
        public int PpPoints { get; set; }
        public int ShGoals { get; set; }
        public int ShPoints { get; set; }
        public decimal ShiftsPerGame { get; set; }
        public decimal ShootingPctg { get; set; }
        public int Shots { get; set; }
        public decimal TimeOnIcePerGame { get; set; }
        public virtual Player Player { get; set; }
    }
}
