using System.ComponentModel.DataAnnotations;
using Superpower.Parsers;

namespace Itransition_Project.Models;

public class Inventory
{
    public int InventoryId { get; set; }
    [Required]
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsPublic { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    
    public string CreatorId { get; set; }
    public virtual User Creator { get; set; }
    
    public string CustomIdFormat { get; set; } = "SEQ";
    
    public string? StringField1 { get; set; }
    public string? StringField1Description { get; set; }
    public bool IsStringField1Visible { get; set; }
    public string? StringField2 { get; set; }
    public string? StringField2Description { get; set; }
    public bool IsStringField2Visible { get; set; }
    public string? StringField3 { get; set; }
    public string? StringField3Description { get; set; }
    public bool IsStringField3Visible { get; set; }

    public string? IntField1 { get; set; }
    public string? IntField1Description { get; set; }
    public bool IsIntField1Visible { get; set; }
    public string? IntField2 { get; set; }
    public string? IntField2Description { get; set; }
    public bool IsIntField2Visible { get; set; }
    public string? IntField3 { get; set; }
    public string? IntField3Description { get; set; }
    public bool IsIntField3Visible { get; set; }

    public string? BoolField1 { get; set; }
    public string? BoolField1Description { get; set; }
    public bool IsBoolField1Visible { get; set; }
    public string? BoolField2 { get; set; }
    public string? BoolField2Description { get; set; }
    public bool IsBoolField2Visible { get; set; }
    public string? BoolField3 { get; set; }
    public string? BoolField3Description { get; set; }
    public bool IsBoolField3Visible { get; set; }
    
    public string? MultilineText1 { get; set; }
    public string? MultilineText1Description { get; set; }
    public bool IsMultilineText1Visible { get; set; }
    public string? MultilineText2 { get; set; }
    public string? MultilineText2Description { get; set; }
    public bool IsMultilineText2Visible { get; set; }
    public string? MultilineText3 { get; set; }
    public string? MultilineText3Description { get; set; }
    public bool IsMultilineText3Visible { get; set; }
    
    public string? FileUrl1 { get; set; }
    public string? FileUrl1Description { get; set; }
    public bool IsFileUrl1Visible { get; set; }
    public string? FileUrl2 { get; set; }
    public string? FileUrl2Description { get; set; }
    public bool IsFileUrl2Visible { get; set; }
    public string? FileUrl3 { get; set; }
    public string? FileUrl3Description { get; set; }
    public bool IsFileUrl3Visible { get; set; }
    
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    public virtual ICollection<InventoryTag> InventoryTags { get; set; } = new List<InventoryTag>();
    public virtual ICollection<InventoryUser> InventoryAccesses { get; set; } = new List<InventoryUser>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    
    [Timestamp]
    public byte[] RawVersion { get; set; }
    
}