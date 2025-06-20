using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversidadQ10.Domain.Common;
using UniversidadQ10.Domain.Entities;

namespace UniversidadQ10.Infrastructure.DataSource
{
    public class SubjectModelConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Materia");

            builder.HasKey(subject => subject.Id);

            builder.Property(subject => subject.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(subject => subject.Name)
               .HasColumnName("Nombre")
               .HasMaxLength(SubjectPropiertiesLength.NameMaxLength)
               .IsRequired();

            builder.Property(subject => subject.Credit)
               .HasColumnName("Creditos")
               .IsRequired();

            builder.Property(subject => subject.Code)
               .HasColumnName("Codigo")
               .IsRequired();

            builder.HasMany(subject => subject.Registration)
                .WithOne(registration => registration.Subject)
                .HasForeignKey(registration => registration.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
