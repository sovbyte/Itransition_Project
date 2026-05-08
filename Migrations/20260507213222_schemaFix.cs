using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itransition_Project.Migrations
{
    /// <inheritdoc />
    public partial class schemaFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Inventory_InventoryId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_AspNetUsers_CreatorId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Category_CategoryId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAccess_AspNetUsers_UserId",
                table: "InventoryAccess");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAccess_Inventory_InventoryId",
                table: "InventoryAccess");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTag_Inventory_InventoryId",
                table: "InventoryTag");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTag_Tag_TagId",
                table: "InventoryTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Inventory_InventoryId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Item_ItemId",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryTag",
                table: "InventoryTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryAccess",
                table: "InventoryAccess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "InventoryTag",
                newName: "InventoryTags");

            migrationBuilder.RenameTable(
                name: "InventoryAccess",
                newName: "InventoryAccesses");

            migrationBuilder.RenameTable(
                name: "Inventory",
                newName: "Inventories");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Like_UserId_ItemId",
                table: "Likes",
                newName: "IX_Likes_UserId_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_ItemId",
                table: "Likes",
                newName: "IX_Likes_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_InventoryId_CustomIdValue",
                table: "Items",
                newName: "IX_Items_InventoryId_CustomIdValue");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryTag_TagId",
                table: "InventoryTags",
                newName: "IX_InventoryTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryAccess_UserId",
                table: "InventoryAccesses",
                newName: "IX_InventoryAccesses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_CreatorId",
                table: "Inventories",
                newName: "IX_Inventories_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_CategoryId",
                table: "Inventories",
                newName: "IX_Inventories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_InventoryId",
                table: "Comments",
                newName: "IX_Comments_InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryTags",
                table: "InventoryTags",
                columns: new[] { "InventoryId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryAccesses",
                table: "InventoryAccesses",
                columns: new[] { "InventoryId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Inventories_InventoryId",
                table: "Comments",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_AspNetUsers_CreatorId",
                table: "Inventories",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Categories_CategoryId",
                table: "Inventories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAccesses_AspNetUsers_UserId",
                table: "InventoryAccesses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAccesses_Inventories_InventoryId",
                table: "InventoryAccesses",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTags_Inventories_InventoryId",
                table: "InventoryTags",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTags_Tags_TagId",
                table: "InventoryTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Inventories_InventoryId",
                table: "Items",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Items_ItemId",
                table: "Likes",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Inventories_InventoryId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_AspNetUsers_CreatorId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Categories_CategoryId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAccesses_AspNetUsers_UserId",
                table: "InventoryAccesses");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAccesses_Inventories_InventoryId",
                table: "InventoryAccesses");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTags_Inventories_InventoryId",
                table: "InventoryTags");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTags_Tags_TagId",
                table: "InventoryTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Inventories_InventoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Items_ItemId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryTags",
                table: "InventoryTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryAccesses",
                table: "InventoryAccesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameTable(
                name: "InventoryTags",
                newName: "InventoryTag");

            migrationBuilder.RenameTable(
                name: "InventoryAccesses",
                newName: "InventoryAccess");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "Inventory");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId_ItemId",
                table: "Like",
                newName: "IX_Like_UserId_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_ItemId",
                table: "Like",
                newName: "IX_Like_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_InventoryId_CustomIdValue",
                table: "Item",
                newName: "IX_Item_InventoryId_CustomIdValue");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryTags_TagId",
                table: "InventoryTag",
                newName: "IX_InventoryTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryAccesses_UserId",
                table: "InventoryAccess",
                newName: "IX_InventoryAccess_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_CreatorId",
                table: "Inventory",
                newName: "IX_Inventory_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_CategoryId",
                table: "Inventory",
                newName: "IX_Inventory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_InventoryId",
                table: "Comment",
                newName: "IX_Comment_InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryTag",
                table: "InventoryTag",
                columns: new[] { "InventoryId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryAccess",
                table: "InventoryAccess",
                columns: new[] { "InventoryId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory",
                column: "InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Inventory_InventoryId",
                table: "Comment",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_AspNetUsers_CreatorId",
                table: "Inventory",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Category_CategoryId",
                table: "Inventory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAccess_AspNetUsers_UserId",
                table: "InventoryAccess",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAccess_Inventory_InventoryId",
                table: "InventoryAccess",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTag_Inventory_InventoryId",
                table: "InventoryTag",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTag_Tag_TagId",
                table: "InventoryTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Inventory_InventoryId",
                table: "Item",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Item_ItemId",
                table: "Like",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
