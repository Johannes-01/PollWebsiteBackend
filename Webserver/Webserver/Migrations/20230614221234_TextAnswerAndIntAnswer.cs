using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Webserver.Migrations
{
    /// <inheritdoc />
    public partial class TextAnswerAndIntAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerType",
                table: "Answers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "intanswers",
                columns: table => new
                {
                    IntAnswerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AnsweredID = table.Column<int>(type: "integer", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    Heading = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intanswers", x => x.IntAnswerID);
                    //display answeredid as foreignkey of answered pk of answered
                });

            migrationBuilder.CreateTable(
                name: "textquestions",
                columns: table => new
                {
                    TextAnswerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AnsweredID = table.Column<int>(type: "integer", nullable: false),
                    SurveyID = table.Column<int>(type: "integer", nullable: false),
                    Heading = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_textquestions", x => x.TextAnswerID);
                    //display answeredid as foreignkey of answered pk of answered
                    //table.ForeignKey("FK_textquestions");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "intanswers");

            migrationBuilder.DropTable(
                name: "textquestions");

            migrationBuilder.DropColumn(
                name: "AnswerType",
                table: "Answers");
        }
    }
}
