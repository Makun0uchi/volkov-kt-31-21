using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolkoVladislavKT_31_21.Database.Helpers;
using VolkoVladislavKT_31_21.Models;

namespace VolkoVladislavKT_31_21.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(s => s.StudentId)
                .HasName($"pk_{TableName}_student_id");

            builder.Property(s => s.StudentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("student_id")
                .HasComment("Идентификатор студента")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(s => s.FirstName)
                .HasColumnName("с_student_first_name")
                .HasComment("Имя студента")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(s => s.LastName)
                .HasColumnName("с_student_last_name")
                .HasComment("Фамилия студента")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(s => s.MiddleName)
                .HasColumnName("с_student_middle_name")
                .HasComment("Отчество студента")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(255);

            builder.Property(s => s.GroupId)
                .HasColumnName("f_students_group_id")
                .HasComment("Идентификатор связанной группы")
                .HasColumnType(ColumnType.Int);

            builder
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId)
                .HasConstraintName($"fk_{TableName}_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .ToTable(TableName)
                .HasIndex(s => s.GroupId, $"idx_{TableName}_fk_f_group_id");

            builder
                .Navigation(s => s.Group)
                .AutoInclude();

            builder
                .Navigation(s => s.Grades)
                .AutoInclude();

            builder
                .Navigation(s => s.Tests)
                .AutoInclude();
        }
    }
}
