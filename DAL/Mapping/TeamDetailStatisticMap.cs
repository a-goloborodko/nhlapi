using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Mapping
{
    public class TeamDetailStatisticMap : EntityTypeConfiguration<TeamDetailStatistic>
    {
        public TeamDetailStatisticMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TeamDetailStatistics");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DefensiveZoneFaceoffs).HasColumnName("DefensiveZoneFaceoffs");
            this.Property(t => t.FiveOnFiveSavePctg).HasColumnName("FiveOnFiveSavePctg");
            this.Property(t => t.FiveOnFiveShootingPctg).HasColumnName("FiveOnFiveShootingPctg");
            this.Property(t => t.OffensiveZoneFaceoffs).HasColumnName("OffensiveZoneFaceoffs");
            this.Property(t => t.SeasonId).HasColumnName("SeasonId");
            this.Property(t => t.ShootingPlusSavePctg).HasColumnName("ShootingPlusSavePctg");
            this.Property(t => t.ShotAttemptsPctg).HasColumnName("ShotAttemptsPctg");
            this.Property(t => t.ShotAttemptsPctgAhead).HasColumnName("ShotAttemptsPctgAhead");
            this.Property(t => t.ShotAttemptsPctgBehind).HasColumnName("ShotAttemptsPctgBehind");
            this.Property(t => t.ShotAttemptsPctgClose).HasColumnName("ShotAttemptsPctgClose");
            this.Property(t => t.ShotAttemptsPctgTied).HasColumnName("ShotAttemptsPctgTied");
            this.Property(t => t.TeamId).HasColumnName("TeamId");
            this.Property(t => t.UnblockedShotAttemptsPctg).HasColumnName("UnblockedShotAttemptsPctg");
            this.Property(t => t.UnblockedShotAttemptsPctgAhead).HasColumnName("UnblockedShotAttemptsPctgAhead");
            this.Property(t => t.UnblockedShotAttemptsPctgBehind).HasColumnName("UnblockedShotAttemptsPctgBehind");
            this.Property(t => t.UnblockedShotAttemptsPctgClose).HasColumnName("UnblockedShotAttemptsPctgClose");
            this.Property(t => t.UnblockedShotAttemptsPctgTied).HasColumnName("UnblockedShotAttemptsPctgTied");
            this.Property(t => t.ZoneStartPctg).HasColumnName("ZoneStartPctg");

            // Relationships
            this.HasRequired(t => t.Team)
                .WithMany(t => t.TeamDetailStatistics)
                .HasForeignKey(d => d.TeamId);

        }
    }
}
