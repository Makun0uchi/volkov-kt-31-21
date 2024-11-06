using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VolkoVladislavKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    с_group_name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false, comment: "Именование группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    с_subject_name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false, comment: "Именование дисциплины"),
                    b_deleted = table.Column<bool>(type: "bool", nullable: false, comment: "Мягкое удаление")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_subject_subject_id", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    с_student_first_name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false, comment: "Имя студента"),
                    с_student_last_name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false, comment: "Фамилия студента"),
                    с_student_middle_name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false, comment: "Отчество студента"),
                    f_students_group_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор связанной группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_cd_student_group_id",
                        column: x => x.f_students_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_grades",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор оценки")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    grade_value = table.Column<int>(type: "int4", nullable: false, comment: "Оценка"),
                    f_student_id = table.Column<int>(type: "int4", nullable: false, comment: "Связанный студент"),
                    f_subject_id = table.Column<int>(type: "int4", nullable: false, comment: "Связанная дисциплина")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_grades_grade_id", x => x.grade_id);
                    table.ForeignKey(
                        name: "fk_cd_grades_student_id",
                        column: x => x.f_student_id,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cd_grades_subject_id",
                        column: x => x.f_subject_id,
                        principalTable: "cd_subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_tests",
                columns: table => new
                {
                    test_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор зачета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    b_passed = table.Column<bool>(type: "bool", nullable: false, comment: "Результат"),
                    f_student_id = table.Column<int>(type: "int4", nullable: false, comment: "Связанный студент"),
                    f_subject_id = table.Column<int>(type: "int4", nullable: false, comment: "Связанная дисциплина")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_tests_test_id", x => x.test_id);
                    table.ForeignKey(
                        name: "fk_cd_tests_student_id",
                        column: x => x.f_student_id,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cd_tests_subject_id",
                        column: x => x.f_subject_id,
                        principalTable: "cd_subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_grades_f_student_id",
                table: "cd_grades",
                column: "f_student_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_grades_f_subject_id",
                table: "cd_grades",
                column: "f_subject_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "f_students_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_tests_f_student_id",
                table: "cd_tests",
                column: "f_student_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_tests_f_subject_id",
                table: "cd_tests",
                column: "f_subject_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_grades");

            migrationBuilder.DropTable(
                name: "cd_tests");

            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_subject");

            migrationBuilder.DropTable(
                name: "cd_group");
        }
    }
}
