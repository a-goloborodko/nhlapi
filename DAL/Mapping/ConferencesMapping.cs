using Core.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Mapping
{
    public class ConferencesMapping : EntityTypeConfiguration<Conference>
    {
        public ConferencesMapping()
        {
            ToTable("Conferences");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).IsRequired().HasMaxLength(70);
            Property(x => x.Abbreviation).IsRequired().HasMaxLength(10);
            Property(x => x.ShortName).IsRequired().HasMaxLength(10);
            Property(x => x.Link).HasMaxLength(50);
        }
    }
}
