using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Webserver.Migrations
{
    /// <inheritdoc />
    public partial class addedPKtoRelationshipTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionOnPollId",
                table: "questionsOnPolls",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_questionsOnPolls",
                table: "questionsOnPolls",
                column: "QuestionOnPollId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_questionsOnPolls",
                table: "questionsOnPolls");

            migrationBuilder.DropColumn(
                name: "QuestionOnPollId",
                table: "questionsOnPolls");
        }
    }
}
