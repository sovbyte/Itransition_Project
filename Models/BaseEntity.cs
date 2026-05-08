using System.ComponentModel.DataAnnotations;

namespace Itransition_Project.Models;

public class BaseEntity
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; } =  DateTime.Now;
    public DateTime UpdatedAt { get; set; }
    
    [Timestamp]
    public byte[] RawVersion { get; set; }
}