using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Mapping
{
    public class DivisionsMapping : EntityTypeConfiguration<Division>
    {
        public DivisionsMapping()
        {
            ToTable("Divisions");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Abbreviation).IsRequired().HasMaxLength(10);
            Property(x => x.Link).HasMaxLength(50);

            // Relationships
            HasRequired<Conference>(x => x.Conference)
                .WithMany(x => x.Divisions)
                .HasForeignKey(x => x.ConferenceId);
        }

    }
}
