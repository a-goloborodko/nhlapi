using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Mapping
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Position)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BirthCity)
                .HasMaxLength(50);

            this.Property(t => t.BirthCountry)
                .HasMaxLength(50);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Height)
                .HasMaxLength(50);

            this.Property(t => t.Weight)
                .HasMaxLength(50);

            this.Property(t => t.Link)
                .HasMaxLength(50);

            this.Property(t => t.Nationality)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Players");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.AlternateCaptain).HasColumnName("AlternateCaptain");
            this.Property(t => t.BirthCity).HasColumnName("BirthCity");
            this.Property(t => t.BirthCountry).HasColumnName("BirthCountry");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.Captain).HasColumnName("Captain");
            this.Property(t => t.TeamId).HasColumnName("TeamId");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.Link).HasColumnName("Link");
            this.Property(t => t.Nationality).HasColumnName("Nationality");
            this.Property(t => t.PrimaryNumber).HasColumnName("PrimaryNumber");
            this.Property(t => t.Rookie).HasColumnName("Rookie");

            // Relationships
            this.HasRequired(t => t.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(d => d.TeamId);

        }
    }
}
