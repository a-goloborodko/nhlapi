using System;
using Core.Enums;

namespace Core.Data
{
    public class TeamStatistic : BaseEntity
    {
        public double FaceoffWinPctg { get; set; }
        public int GamesPlayed { get; set; }
        public int GoalsAgainst { get; set; }
        public double GoalsAgainstPerGame { get; set; }
        public int GoalsFor { get; set; }
        public double GoalsForPerGame { get; set; }
        public int Losses { get; set; }
        public int OtLosses { get; set; }
        public double PkPctg { get; set; }
        public double PointPctg { get; set; }
        public int Points { get; set; }
        public double PpPctg { get; set; }
        public int RegPlusOtWins { get; set; }
        public double ShotsAgainstPerGame { get; set; }
        public double ShotsForPerGame { get; set; }
        public int Wins { get; set; }
        public Int16 GameType { get; set; }
        public long SeasonId { get; set; }
        public long TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
