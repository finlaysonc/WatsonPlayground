using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SarahNLP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Craeted = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "getutcdate()"),
                    Discriminator = table.Column<string>(nullable: false),
                    ContentText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "SmsMessages",
                columns: table => new
                {
                    SmsMessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageText = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    MessageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsMessages", x => x.SmsMessageId);
                    table.ForeignKey(
                        name: "FK_SmsMessages_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToneScores",
                columns: table => new
                {
                    ToneScoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToneType = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    SmsMessageId = table.Column<int>(nullable: true),
                    Score = table.Column<double>(nullable: true),
                    ToneName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToneScores", x => x.ToneScoreId);
                    table.ForeignKey(
                        name: "FK_ToneScores_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToneScores_SmsMessages_SmsMessageId",
                        column: x => x.SmsMessageId,
                        principalTable: "SmsMessages",
                        principalColumn: "SmsMessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmsMessages_MessageId",
                table: "SmsMessages",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ToneScores_MessageId",
                table: "ToneScores",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ToneScores_SmsMessageId",
                table: "ToneScores",
                column: "SmsMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToneScores");

            migrationBuilder.DropTable(
                name: "SmsMessages");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
