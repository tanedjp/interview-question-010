using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace interview_question_010.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidate",
                columns: table => new
                {
                    candidate_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    candidate_fullname = table.Column<string>(type: "text", nullable: true),
                    test_uid = table.Column<Guid>(type: "uuid", nullable: true),
                    test_name = table.Column<string>(type: "text", nullable: true),
                    score = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidate", x => x.candidate_uid);
                });

            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    test_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    test_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test", x => x.test_uid);
                });

            migrationBuilder.CreateTable(
                name: "candidate_question",
                columns: table => new
                {
                    candidate_question_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    candidate_uid = table.Column<Guid>(type: "uuid", nullable: true),
                    question_uid = table.Column<Guid>(type: "uuid", nullable: true),
                    question_name = table.Column<string>(type: "text", nullable: true),
                    is_correct = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidate_question", x => x.candidate_question_uid);
                    table.ForeignKey(
                        name: "FK_candidate_question_candidate_candidate_uid",
                        column: x => x.candidate_uid,
                        principalTable: "candidate",
                        principalColumn: "candidate_uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    question_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    test_uid = table.Column<Guid>(type: "uuid", nullable: true),
                    question_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.question_uid);
                    table.ForeignKey(
                        name: "FK_question_test_test_uid",
                        column: x => x.test_uid,
                        principalTable: "test",
                        principalColumn: "test_uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidate_choice",
                columns: table => new
                {
                    candidate_choice_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    candidate_question_uid = table.Column<Guid>(type: "uuid", nullable: true),
                    choice_uid = table.Column<Guid>(type: "uuid", nullable: true),
                    choice_name = table.Column<string>(type: "text", nullable: true),
                    is_selected = table.Column<bool>(type: "boolean", nullable: true),
                    is_correct = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidate_choice", x => x.candidate_choice_uid);
                    table.ForeignKey(
                        name: "FK_candidate_choice_candidate_question_candidate_question_uid",
                        column: x => x.candidate_question_uid,
                        principalTable: "candidate_question",
                        principalColumn: "candidate_question_uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "choice",
                columns: table => new
                {
                    choice_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    question_uid = table.Column<Guid>(type: "uuid", nullable: true),
                    choice_name = table.Column<string>(type: "text", nullable: true),
                    is_corrent = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choice", x => x.choice_uid);
                    table.ForeignKey(
                        name: "FK_choice_question_question_uid",
                        column: x => x.question_uid,
                        principalTable: "question",
                        principalColumn: "question_uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidate_choice_candidate_question_uid",
                table: "candidate_choice",
                column: "candidate_question_uid");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_question_candidate_uid",
                table: "candidate_question",
                column: "candidate_uid");

            migrationBuilder.CreateIndex(
                name: "IX_choice_question_uid",
                table: "choice",
                column: "question_uid");

            migrationBuilder.CreateIndex(
                name: "IX_question_test_uid",
                table: "question",
                column: "test_uid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidate_choice");

            migrationBuilder.DropTable(
                name: "choice");

            migrationBuilder.DropTable(
                name: "candidate_question");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "candidate");

            migrationBuilder.DropTable(
                name: "test");
        }
    }
}
