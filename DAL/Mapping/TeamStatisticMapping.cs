using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Mapping
{
    public class TeamStatisticMapping : EntityTypeConfiguration<TeamStatistic>
    {
        public TeamStatisticMapping()
        {
            ToTable("TeamStatistics");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FaceoffWinPctg).IsRequired();
            Property(x => x.GamesPlayed).IsRequired();
            Property(x => x.GameType).IsRequired();
            Property(x => x.GoalsAgainst).IsRequired();
            Property(x => x.GoalsAgainstPerGame).IsRequired();
            Property(x => x.GoalsFor).IsRequired();
            Property(x => x.GoalsForPerGame).IsRequired();
            Property(x => x.Losses).IsRequired();
            Property(x => x.OtLosses).IsRequired();
            Property(x => x.PkPctg).IsRequired();
            Property(x => x.PointPctg).IsRequired();
            Property(x => x.Points).IsRequired();
            Property(x => x.PpPctg).IsRequired();
            Property(x => x.RegPlusOtWins).IsRequired();
            Property(x => x.ShotsAgainstPerGame).IsRequired();
            Property(x => x.ShotsForPerGame).IsRequired();
            Property(x => x.Wins).IsRequired();

            // Relationships
            HasRequired(x => x.Team)
                .WithMany(x => x.TeamStats)
                .HasForeignKey(x => x.TeamId);
        }
    }
}
