using Core.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Mapping
{
    public class TeamMapping : EntityTypeConfiguration<Team>
    {

        public TeamMapping()
        {
            ToTable("Teams");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Abbreviation).IsRequired().HasMaxLength(10);
            Property(x => x.Link).HasMaxLength(50);
            Property(x => x.TeamName).IsRequired().HasMaxLength(50);
            Property(x => x.LocationName).IsRequired().HasMaxLength(50);
            Property(x => x.DivisionId).IsRequired();
            Property(x => x.ConferenceId).IsRequired();
            Property(x => x.OfficialSiteUrl).HasMaxLength(50);
            Property(x => x.Name).HasMaxLength(50);
            HasRequired<Division>(x => x.Division)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.DivisionId);
            HasRequired<Conference>(x => x.Conference)
               .WithMany(x => x.Teams)
               .HasForeignKey(x => x.ConferenceId);
        }
    }
}
