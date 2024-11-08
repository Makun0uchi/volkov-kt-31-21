using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolkoVladislavKT_31_21.Database.Helpers;
using VolkoVladislavKT_31_21.Models;

namespace VolkoVladislavKT_31_21.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "cd_subject";

        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable(TableName);

            builder
                .HasKey(s => s.SubjectId)
                .HasName($"pk_{TableName}_subject_id");

            builder.Property(s => s.SubjectId)
                .ValueGeneratedOnAdd()
                .HasColumnName("subject_id")
                .HasComment("Идентификатор дисциплины")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(s => s.SubjectName)
                .HasColumnName("с_subject_name")
                .HasComment("Именование дисциплины")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(s => s.SubjectType)
                .HasColumnName("с_subject_type")
                .HasComment("Направление дисциплины")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(s => s.isDeleted)
                .HasColumnName("b_deleted")
                .HasComment("Мягкое удаление")
                .HasColumnType(ColumnType.Bool);
        }
    }
}
