using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolkoVladislavKT_31_21.Database.Helpers;
using VolkoVladislavKT_31_21.Models;

namespace VolkoVladislavKT_31_21.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<Group> builder) 
        {
            builder.ToTable(TableName);

            builder
                .HasKey(g => g.GroupId)
                .HasName($"pk_{TableName}_group_id");

            builder.Property(g => g.GroupId)
                .ValueGeneratedOnAdd()
                .HasColumnName("group_id")
                .HasComment("Идентификатор группы")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(g => g.GroupName)
                .HasColumnName("с_group_name")
                .HasComment("Именование группы")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
