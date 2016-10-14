using Core.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Mapping
{
    public class SeasonMapping : EntityTypeConfiguration<Season>
    {
        public SeasonMapping()
        {
            ToTable("Seasons");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x=>x.StartYear).IsRequired();
            Property(x => x.EndYear).IsRequired();
        }
    }
}
