using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Itransition_Project.Migrations
{
    /// <inheritdoc />
    public partial class schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<string>(type: "text", nullable: false),
                    CustomIdFormat = table.Column<string>(type: "text", nullable: false),
                    StringField1 = table.Column<string>(type: "text", nullable: true),
                    StringField1Description = table.Column<string>(type: "text", nullable: true),
                    IsStringField1Visible = table.Column<bool>(type: "boolean", nullable: false),
                    StringField2 = table.Column<string>(type: "text", nullable: true),
                    StringField2Description = table.Column<string>(type: "text", nullable: true),
                    IsStringField2Visible = table.Column<bool>(type: "boolean", nullable: false),
                    StringField3 = table.Column<string>(type: "text", nullable: true),
                    StringField3Description = table.Column<string>(type: "text", nullable: true),
                    IsStringField3Visible = table.Column<bool>(type: "boolean", nullable: false),
                    IntField1 = table.Column<string>(type: "text", nullable: true),
                    IntField1Description = table.Column<string>(type: "text", nullable: true),
                    IsIntField1Visible = table.Column<bool>(type: "boolean", nullable: false),
                    IntField2 = table.Column<string>(type: "text", nullable: true),
                    IntField2Description = table.Column<string>(type: "text", nullable: true),
                    IsIntField2Visible = table.Column<bool>(type: "boolean", nullable: false),
                    IntField3 = table.Column<string>(type: "text", nullable: true),
                    IntField3Description = table.Column<string>(type: "text", nullable: true),
                    IsIntField3Visible = table.Column<bool>(type: "boolean", nullable: false),
                    BoolField1 = table.Column<string>(type: "text", nullable: true),
                    BoolField1Description = table.Column<string>(type: "text", nullable: true),
                    IsBoolField1Visible = table.Column<bool>(type: "boolean", nullable: false),
                    BoolField2 = table.Column<string>(type: "text", nullable: true),
                    BoolField2Description = table.Column<string>(type: "text", nullable: true),
                    IsBoolField2Visible = table.Column<bool>(type: "boolean", nullable: false),
                    BoolField3 = table.Column<string>(type: "text", nullable: true),
                    BoolField3Description = table.Column<string>(type: "text", nullable: true),
                    IsBoolField3Visible = table.Column<bool>(type: "boolean", nullable: false),
                    MultilineText1 = table.Column<string>(type: "text", nullable: true),
                    MultilineText1Description = table.Column<string>(type: "text", nullable: true),
                    IsMultilineText1Visible = table.Column<bool>(type: "boolean", nullable: false),
                    MultilineText2 = table.Column<string>(type: "text", nullable: true),
                    MultilineText2Description = table.Column<string>(type: "text", nullable: true),
                    IsMultilineText2Visible = table.Column<bool>(type: "boolean", nullable: false),
                    MultilineText3 = table.Column<string>(type: "text", nullable: true),
                    MultilineText3Description = table.Column<string>(type: "text", nullable: true),
                    IsMultilineText3Visible = table.Column<bool>(type: "boolean", nullable: false),
                    FileUrl1 = table.Column<string>(type: "text", nullable: true),
                    FileUrl1Description = table.Column<string>(type: "text", nullable: true),
                    IsFileUrl1Visible = table.Column<bool>(type: "boolean", nullable: false),
                    FileUrl2 = table.Column<string>(type: "text", nullable: true),
                    FileUrl2Description = table.Column<string>(type: "text", nullable: true),
                    IsFileUrl2Visible = table.Column<bool>(type: "boolean", nullable: false),
                    FileUrl3 = table.Column<string>(type: "text", nullable: true),
                    FileUrl3Description = table.Column<string>(type: "text", nullable: true),
                    IsFileUrl3Visible = table.Column<bool>(type: "boolean", nullable: false),
                    RawVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    InventoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryAccess",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAccess", x => new { x.InventoryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_InventoryAccess_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryAccess_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTag",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTag", x => new { x.InventoryId, x.TagId });
                    table.ForeignKey(
                        name: "FK_InventoryTag_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomIdValue = table.Column<string>(type: "text", nullable: false),
                    InventoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    String1 = table.Column<string>(type: "text", nullable: true),
                    String2 = table.Column<string>(type: "text", nullable: true),
                    String3 = table.Column<string>(type: "text", nullable: true),
                    Int1 = table.Column<int>(type: "integer", nullable: true),
                    Int2 = table.Column<int>(type: "integer", nullable: true),
                    Int3 = table.Column<int>(type: "integer", nullable: true),
                    Bool1 = table.Column<bool>(type: "boolean", nullable: false),
                    Bool2 = table.Column<bool>(type: "boolean", nullable: false),
                    Bool3 = table.Column<bool>(type: "boolean", nullable: false),
                    MultiLineText1 = table.Column<string>(type: "text", nullable: true),
                    MultiLineText2 = table.Column<string>(type: "text", nullable: true),
                    MultiLineText3 = table.Column<string>(type: "text", nullable: true),
                    FileUrl1 = table.Column<string>(type: "text", nullable: true),
                    FileUrl2 = table.Column<string>(type: "text", nullable: true),
                    FileUrl3 = table.Column<string>(type: "text", nullable: true),
                    RawVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_InventoryId",
                table: "Comment",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CategoryId",
                table: "Inventory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CreatorId",
                table: "Inventory",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAccess_UserId",
                table: "InventoryAccess",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTag_TagId",
                table: "InventoryTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_InventoryId_CustomIdValue",
                table: "Item",
                columns: new[] { "InventoryId", "CustomIdValue" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Like_ItemId",
                table: "Like",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId_ItemId",
                table: "Like",
                columns: new[] { "UserId", "ItemId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "InventoryAccess");

            migrationBuilder.DropTable(
                name: "InventoryTag");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "AspNetUsers");
        }
    }
}
