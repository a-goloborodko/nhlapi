namespace Core.Models
{
    public partial class TeamDetailStatistic : BaseEntity
    {
        public int DefensiveZoneFaceoffs { get; set; }
        public decimal FiveOnFiveSavePctg { get; set; }
        public decimal FiveOnFiveShootingPctg { get; set; }
        public int OffensiveZoneFaceoffs { get; set; }
        public long SeasonId { get; set; }
        public decimal ShootingPlusSavePctg { get; set; }
        public decimal ShotAttemptsPctg { get; set; }
        public decimal ShotAttemptsPctgAhead { get; set; }
        public decimal ShotAttemptsPctgBehind { get; set; }
        public decimal ShotAttemptsPctgClose { get; set; }
        public decimal ShotAttemptsPctgTied { get; set; }
        public long TeamId { get; set; }
        public decimal UnblockedShotAttemptsPctg { get; set; }
        public decimal UnblockedShotAttemptsPctgAhead { get; set; }
        public decimal UnblockedShotAttemptsPctgBehind { get; set; }
        public decimal UnblockedShotAttemptsPctgClose { get; set; }
        public decimal UnblockedShotAttemptsPctgTied { get; set; }
        public decimal ZoneStartPctg { get; set; }
        public virtual Season Season { get; set; }
        public virtual Team Team { get; set; }
    }
}
