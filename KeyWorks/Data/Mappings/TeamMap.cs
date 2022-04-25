using KeyWorks.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyWorks.Api.Data.Mappings
{
    public class TeamMap : IEntityTypeConfiguration<TeamModel>
    {
        public void Configure(EntityTypeBuilder<TeamModel> builder)
        {
            //Table name
            builder.ToTable("Team");

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
                .WithOne(x => x.Team)
                .HasConstraintName("FK_Team_Card")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
