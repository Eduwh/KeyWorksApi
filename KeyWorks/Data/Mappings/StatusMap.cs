using KeyWorks.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyWorks.Api.Data.Mappings
{
    public class StatusMap : IEntityTypeConfiguration<StatusModel>
    {
        public void Configure(EntityTypeBuilder<StatusModel> builder)
        {
            //Table name
            builder.ToTable("Status");

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
                .WithOne(x => x.Status)
                .HasConstraintName("FK_Status_Card")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
