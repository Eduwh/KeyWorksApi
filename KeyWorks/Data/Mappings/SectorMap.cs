using KeyWorks.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyWorks.Api.Data.Mappings
{
    public class SectorMap : IEntityTypeConfiguration<SectorModel>
    {
        public void Configure(EntityTypeBuilder<SectorModel> builder)
        {
            //Table name
            builder.ToTable("Sector");

            //Primary Key
            builder.HasKey( x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Properties
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            //Fk
            builder.HasMany(x => x.Cards)
                .WithOne(x => x.Sector)
                .HasConstraintName("FK_Sector_Card")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
