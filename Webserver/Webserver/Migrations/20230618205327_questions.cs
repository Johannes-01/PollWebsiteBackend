using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Webserver.Migrations
{
    /// <inheritdoc />
    public partial class questions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_questionsOnPolls",
                table: "questionsOnPolls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_textquestions",
                table: "textquestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_intanswers",
                table: "intanswers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "textquestions");

            migrationBuilder.DropColumn(
                name: "Heading",
                table: "textquestions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "intanswers");

            migrationBuilder.DropColumn(
                name: "Heading",
                table: "intanswers");

            migrationBuilder.RenameTable(
                name: "questionsOnPolls",
                newName: "QuestionsOnPolls");

            migrationBuilder.RenameTable(
                name: "textquestions",
                newName: "Textanswer");

            migrationBuilder.RenameTable(
                name: "intanswers",
                newName: "IntAnswer");

            migrationBuilder.RenameColumn(
                name: "TextAnswerID",
                table: "Textanswer",
                newName: "TextanswerID");

            migrationBuilder.RenameColumn(
                name: "SurveyID",
                table: "Textanswer",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "AnsweredID",
                table: "Textanswer",
                newName: "AnswerID");

            migrationBuilder.RenameColumn(
                name: "AnsweredID",
                table: "IntAnswer",
                newName: "AnswerID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Answers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Answers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "AnswerID",
                table: "Answers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionsOnPolls",
                table: "QuestionsOnPolls",
                column: "QuestionOnPollId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "AnswerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Textanswer",
                table: "Textanswer",
                column: "TextanswerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IntAnswer",
                table: "IntAnswer",
                column: "IntAnswerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionsOnPolls",
                table: "QuestionsOnPolls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Textanswer",
                table: "Textanswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IntAnswer",
                table: "IntAnswer");

            migrationBuilder.DropColumn(
                name: "AnswerID",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "QuestionsOnPolls",
                newName: "questionsOnPolls");

            migrationBuilder.RenameTable(
                name: "Textanswer",
                newName: "textquestions");

            migrationBuilder.RenameTable(
                name: "IntAnswer",
                newName: "intanswers");

            migrationBuilder.RenameColumn(
                name: "TextanswerID",
                table: "textquestions",
                newName: "TextAnswerID");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "textquestions",
                newName: "SurveyID");

            migrationBuilder.RenameColumn(
                name: "AnswerID",
                table: "textquestions",
                newName: "AnsweredID");

            migrationBuilder.RenameColumn(
                name: "AnswerID",
                table: "intanswers",
                newName: "AnsweredID");

            migrationBuilder.AlterColumn<int[]>(
                name: "UserID",
                table: "Answers",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "AnsweredID",
                table: "Answers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "textquestions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Heading",
                table: "textquestions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "intanswers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Heading",
                table: "intanswers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_questionsOnPolls",
                table: "questionsOnPolls",
                column: "QuestionOnPollId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "AnsweredID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_textquestions",
                table: "textquestions",
                column: "TextAnswerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_intanswers",
                table: "intanswers",
                column: "IntAnswerID");
        }
    }
}
