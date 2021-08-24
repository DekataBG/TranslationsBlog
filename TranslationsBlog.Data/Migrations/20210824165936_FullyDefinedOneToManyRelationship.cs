using Microsoft.EntityFrameworkCore.Migrations;

namespace TranslationsBlog.Data.Migrations
{
    public partial class FullyDefinedOneToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Volumes_VolumeId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Chapters_ChapterId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_LightNovels_LightNovelId",
                table: "Volumes");

            migrationBuilder.AlterColumn<int>(
                name: "LightNovelId",
                table: "Volumes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChapterId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VolumeId",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Volumes_VolumeId",
                table: "Chapters",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Chapters_ChapterId",
                table: "Parts",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_LightNovels_LightNovelId",
                table: "Volumes",
                column: "LightNovelId",
                principalTable: "LightNovels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Volumes_VolumeId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Chapters_ChapterId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_LightNovels_LightNovelId",
                table: "Volumes");

            migrationBuilder.AlterColumn<int>(
                name: "LightNovelId",
                table: "Volumes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChapterId",
                table: "Parts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VolumeId",
                table: "Chapters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Volumes_VolumeId",
                table: "Chapters",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Chapters_ChapterId",
                table: "Parts",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_LightNovels_LightNovelId",
                table: "Volumes",
                column: "LightNovelId",
                principalTable: "LightNovels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
