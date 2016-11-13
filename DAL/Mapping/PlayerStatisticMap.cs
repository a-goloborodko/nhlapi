using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Mapping
{
    public class PlayerStatisticMap : EntityTypeConfiguration<PlayerStatistic>
    {
        public PlayerStatisticMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("PlayerStatistics");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PlayerId).HasColumnName("PlayerId");
            this.Property(t => t.SeasonId).HasColumnName("SeasonId");
            this.Property(t => t.Assists).HasColumnName("Assists");
            this.Property(t => t.FaceoffWinPctg).HasColumnName("FaceoffWinPctg");
            this.Property(t => t.GamesPlayed).HasColumnName("GamesPlayed");
            this.Property(t => t.GameWinningGoals).HasColumnName("GameWinningGoals");
            this.Property(t => t.Goals).HasColumnName("Goals");
            this.Property(t => t.OtGoals).HasColumnName("OtGoals");
            this.Property(t => t.PenaltyMinutes).HasColumnName("PenaltyMinutes");
            this.Property(t => t.PlusMinus).HasColumnName("PlusMinus");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.PpGoals).HasColumnName("PpGoals");
            this.Property(t => t.PpPoints).HasColumnName("PpPoints");
            this.Property(t => t.ShGoals).HasColumnName("ShGoals");
            this.Property(t => t.ShPoints).HasColumnName("ShPoints");
            this.Property(t => t.ShiftsPerGame).HasColumnName("ShiftsPerGame");
            this.Property(t => t.ShootingPctg).HasColumnName("ShootingPctg");
            this.Property(t => t.Shots).HasColumnName("Shots");
            this.Property(t => t.TimeOnIcePerGame).HasColumnName("TimeOnIcePerGame");

            // Relationships
            this.HasRequired(t => t.Player)
                .WithMany(t => t.PlayerStatistics)
                .HasForeignKey(d => d.PlayerId);

        }
    }
}
