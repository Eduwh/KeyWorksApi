using KeyWorks.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyWorks.Api.Data.Mappings
{
    public class CardMap : IEntityTypeConfiguration<CardModel>
    {
        public void Configure(EntityTypeBuilder<CardModel> builder)
        {
            //Table name
            builder.ToTable("Card");

            //Primary Key
            builder.HasKey( x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Properties
            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime2")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.Property(x => x.ForeseenDate)
                .IsRequired()
                .HasColumnName("ForeseenDate")
                .HasColumnType("datetime2");

            builder.Property(x => x.Priority)
                .IsRequired()
                .HasColumnName("Priority")
                .HasColumnType("int");

            //Relationships / FKs

            builder.HasOne(x => x.User)
                .WithMany( x=> x.Cards)
                .HasConstraintName("FK_Card_User")
                .OnDelete( DeleteBehavior.Cascade);

            builder.HasOne(x => x.Status)
                .WithMany(x => x.Cards)
                .HasConstraintName("FK_Card_Status")
                .OnDelete( DeleteBehavior.Restrict);

            builder.HasOne(x => x.Sector)
                .WithMany(x => x.Cards)
                .HasConstraintName("FK_Card_Sector")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.Cards)
                .HasConstraintName("FK_Card_Team")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Project)
                .WithMany(x => x.Cards)
                .HasConstraintName("FK_Card_Project")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
