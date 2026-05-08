using System.ComponentModel.DataAnnotations;

namespace Itransition_Project.Models;

public class Item : BaseEntity
{
    public string CustomIdValue { get; set; }
    
    public int InventoryId { get; set; }
    public virtual Inventory Inventory { get; set; }
    
    public string? CreatedById { get; set; }
    
    public string? String1 { get; set; }
    public string? String2 { get; set; }
    public string? String3 { get; set; }
    
    public int? Int1 { get; set; }
    public int? Int2 { get; set; }
    public int? Int3 { get; set; }
    
    public bool Bool1 { get; set; }
    public bool Bool2 { get; set; }
    public bool Bool3 { get; set; }
    
    public string? MultiLineText1 { get; set; }
    public string? MultiLineText2 { get; set; }
    public string? MultiLineText3 { get; set; }
    
    public string? FileUrl1 { get; set; }
    public string? FileUrl2 { get; set; }
    public string? FileUrl3 { get; set; }
}