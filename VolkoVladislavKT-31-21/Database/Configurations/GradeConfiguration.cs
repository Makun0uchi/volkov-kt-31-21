using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolkoVladislavKT_31_21.Database.Helpers;
using VolkoVladislavKT_31_21.Models;

namespace VolkoVladislavKT_31_21.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        private const string TableName = "cd_grades";

        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable(TableName);

            builder
                .HasKey(g => g.GradeId)
                .HasName($"pk_{TableName}_grade_id");

            builder.Property(g => g.GradeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("grade_id")
                .HasComment("Идентификатор оценки")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(g => g.GradeValue)
                .HasColumnName("grade_value")
                .HasComment("Оценка")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(g => g.StudentId)
                .HasColumnName("f_student_id")
                .HasComment("Связанный студент")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(g => g.SubjectId)
                .HasColumnName("f_subject_id")
                .HasComment("Связанная дисциплина")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .HasConstraintName($"fk_{TableName}_student_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(g => g.Subject)
                .WithMany()
                .HasForeignKey(g => g.SubjectId)
                .HasConstraintName($"fk_{TableName}_subject_id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
