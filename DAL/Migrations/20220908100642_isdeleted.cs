using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class isdeleted : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Students" );
        }
    }
}
