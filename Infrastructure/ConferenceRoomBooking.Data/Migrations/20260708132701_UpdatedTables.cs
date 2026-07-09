using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceRoomBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceRoomEntity_BookingEntity_BookingId",
                table: "ConferenceRoomEntity");

            migrationBuilder.DropIndex(
                name: "IX_ConferenceRoomEntity_BookingId",
                table: "ConferenceRoomEntity");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "ConferenceRoomEntity");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ConferenceRoomEntity");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "ConferenceRoomEntity");

            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "BookingEntity");

            migrationBuilder.RenameColumn(
                name: "DurationHours",
                table: "BookingEntity",
                newName: "DurationHours");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "BookingEntity",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<Guid>(
                name: "ConferenceRoomId",
                table: "BookingEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BookingServiceEntity",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OptionalServiceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingServiceEntity", x => new { x.BookingId, x.OptionalServiceId });
                    table.ForeignKey(
                        name: "FK_BookingServiceEntity_BookingEntity_BookingId",
                        column: x => x.BookingId,
                        principalTable: "BookingEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingServiceEntity_OptionalServiceEntity_OptionalServiceId",
                        column: x => x.OptionalServiceId,
                        principalTable: "OptionalServiceEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomServiceEntity",
                columns: table => new
                {
                    ConferenceRoomId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OptionalServiceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServiceEntity", x => new { x.ConferenceRoomId, x.OptionalServiceId });
                    table.ForeignKey(
                        name: "FK_RoomServiceEntity_ConferenceRoomEntity_ConferenceRoomId",
                        column: x => x.ConferenceRoomId,
                        principalTable: "ConferenceRoomEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomServiceEntity_OptionalServiceEntity_OptionalServiceId",
                        column: x => x.OptionalServiceId,
                        principalTable: "OptionalServiceEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntity_ConferenceRoomId",
                table: "BookingEntity",
                column: "ConferenceRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServiceEntity_OptionalServiceId",
                table: "BookingServiceEntity",
                column: "OptionalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceEntity_OptionalServiceId",
                table: "RoomServiceEntity",
                column: "OptionalServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntity_ConferenceRoomEntity_ConferenceRoomId",
                table: "BookingEntity",
                column: "ConferenceRoomId",
                principalTable: "ConferenceRoomEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntity_ConferenceRoomEntity_ConferenceRoomId",
                table: "BookingEntity");

            migrationBuilder.DropTable(
                name: "BookingServiceEntity");

            migrationBuilder.DropTable(
                name: "RoomServiceEntity");

            migrationBuilder.DropIndex(
                name: "IX_BookingEntity_ConferenceRoomId",
                table: "BookingEntity");

            migrationBuilder.DropColumn(
                name: "ConferenceRoomId",
                table: "BookingEntity");

            migrationBuilder.RenameColumn(
                name: "DurationHours",
                table: "BookingEntity",
                newName: "DurationHours");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "ConferenceRoomEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ConferenceRoomEntity",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "ConferenceRoomEntity",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "BookingEntity",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndAt",
                table: "BookingEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceRoomEntity_BookingId",
                table: "ConferenceRoomEntity",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceRoomEntity_BookingEntity_BookingId",
                table: "ConferenceRoomEntity",
                column: "BookingId",
                principalTable: "BookingEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
