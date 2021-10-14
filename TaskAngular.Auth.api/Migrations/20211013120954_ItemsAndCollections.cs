using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskAngular.Auth.api.Migrations
{
    public partial class ItemsAndCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondFiled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdFiled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstFieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondFieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdFieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    FirsList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    IDItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCollection = table.Column<int>(type: "int", nullable: false),
                    NameItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstField_Int = table.Column<int>(type: "int", nullable: false),
                    SecondField_Int = table.Column<int>(type: "int", nullable: false),
                    ThirdField_Int = table.Column<int>(type: "int", nullable: false),
                    FirstField_String = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondField_String = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdField_String = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstField_Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecondField_Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThirdField_Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstField_Bool = table.Column<bool>(type: "bit", nullable: false),
                    SecondField_Bool = table.Column<bool>(type: "bit", nullable: false),
                    ThirdField_Bool = table.Column<bool>(type: "bit", nullable: false),
                    Likes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikesCount = table.Column<int>(type: "int", nullable: false),
                    CommentsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.IDItem);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
