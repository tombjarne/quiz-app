using Microsoft.EntityFrameworkCore.Migrations;

namespace Lifekeys.Migrations
{
    public partial class InitialQuizMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    QuizId = table.Column<string>(type: "varchar(767)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    IsTrue = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solution",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solution_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    SolutionId = table.Column<string>(type: "varchar(767)", nullable: true),
                    QuestionId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_Solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_SolutionId",
                table: "Answer",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Solution_QuestionId",
                table: "Solution",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Solution");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Quiz");
        }
    }
}
