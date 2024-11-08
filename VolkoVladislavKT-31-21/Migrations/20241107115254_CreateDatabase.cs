using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    с_subject_type = table.Column<string>(type: "varchar", maxLength: 255, nullable: false, comment: "Направление дисциплины"),
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

            migrationBuilder.InsertData(
                table: "cd_group",
                columns: new[] { "group_id", "с_group_name" },
                values: new object[,]
                {
                    { 1, "Group A" },
                    { 2, "Group B" },
                    { 3, "Group C" },
                    { 4, "Group D" },
                    { 5, "Group E" },
                    { 6, "Group F" },
                    { 7, "Group G" },
                    { 8, "Group H" },
                    { 9, "Group I" },
                    { 10, "Group J" }
                });

            migrationBuilder.InsertData(
                table: "cd_subject",
                columns: new[] { "subject_id", "с_subject_name", "с_subject_type", "b_deleted" },
                values: new object[,]
                {
                    { 1, "Mathematics", "TechnicalSubject", false },
                    { 2, "Physics", "TechnicalSubject", false },
                    { 3, "History", "HumanisticSubject", false },
                    { 4, "Biology", "TechnicalSubject", false },
                    { 5, "Philosophy", "HumanisticSubject", false },
                    { 6, "Chemistry", "TechnicalSubject", false },
                    { 7, "Sociology", "HumanisticSubject", false },
                    { 8, "Literature", "HumanisticSubject", false },
                    { 9, "Computer Science", "TechnicalSubject", false },
                    { 10, "Geography", "HumanisticSubject", false }
                });

            migrationBuilder.InsertData(
                table: "cd_student",
                columns: new[] { "student_id", "с_student_first_name", "f_students_group_id", "с_student_last_name", "с_student_middle_name" },
                values: new object[,]
                {
                    { 1, "Alice", 1, "Johnson", "M" },
                    { 2, "Bob", 2, "Smith", "A" },
                    { 3, "Charlie", 1, "Brown", "B" },
                    { 4, "David", 3, "Wilson", "C" },
                    { 5, "Eve", 2, "Davis", "D" },
                    { 6, "Frank", 3, "Taylor", "E" },
                    { 7, "Grace", 4, "Evans", "F" },
                    { 8, "Hank", 5, "Moore", "G" },
                    { 9, "Ivy", 4, "Martin", "H" },
                    { 10, "Jake", 5, "White", "I" }
                });

            migrationBuilder.InsertData(
                table: "cd_grades",
                columns: new[] { "grade_id", "grade_value", "f_student_id", "f_subject_id" },
                values: new object[,]
                {
                    { 1, 85, 1, 1 },
                    { 2, 90, 2, 1 },
                    { 3, 78, 3, 2 },
                    { 4, 92, 4, 3 },
                    { 5, 67, 5, 4 },
                    { 6, 88, 6, 5 },
                    { 7, 73, 7, 6 },
                    { 8, 81, 8, 7 },
                    { 9, 76, 9, 8 },
                    { 10, 89, 10, 9 }
                });

            migrationBuilder.InsertData(
                table: "cd_tests",
                columns: new[] { "test_id", "f_student_id", "f_subject_id", "b_passed" },
                values: new object[,]
                {
                    { 1, 1, 1, true },
                    { 2, 2, 1, false },
                    { 3, 3, 2, true },
                    { 4, 4, 3, false },
                    { 5, 5, 4, true },
                    { 6, 6, 5, false },
                    { 7, 7, 6, true },
                    { 8, 8, 7, false },
                    { 9, 9, 8, true },
                    { 10, 10, 9, true }
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
