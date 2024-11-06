using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolkoVladislavKT_31_21.Database.Helpers;
using VolkoVladislavKT_31_21.Models;

namespace VolkoVladislavKT_31_21.Database.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        private const string TableName = "cd_tests";

        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.ToTable(TableName);

            builder
                .HasKey(t => t.TestId)
                .HasName($"pk_{TableName}_test_id");

            builder.Property(t => t.TestId)
                .ValueGeneratedOnAdd()
                .HasColumnName("test_id")
                .HasComment("Идентификатор зачета")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(t => t.isPassed)
                .HasColumnName("b_passed")
                .HasComment("Результат")
                .HasColumnType(ColumnType.Bool)
                .IsRequired();

            builder.Property(t => t.StudentId)
                .HasColumnName("f_student_id")
                .HasComment("Связанный студент")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(t => t.SubjectId)
                .HasColumnName("f_subject_id")
                .HasComment("Связанная дисциплина")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder
                .HasOne(t => t.Student)
                .WithMany(s => s.Tests)
                .HasForeignKey(t => t.StudentId)
                .HasConstraintName($"fk_{TableName}_student_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(t => t.Subject)
                .WithMany()
                .HasForeignKey(t => t.SubjectId)
                .HasConstraintName($"fk_{TableName}_subject_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Navigation(t => t.Student)
                .AutoInclude();

            builder
                .Navigation(t => t.Subject)
                .AutoInclude();
        }
    }
}
