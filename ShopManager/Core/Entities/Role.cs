using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManager.Core.Entities;

public class Role
{
    [Key]
    public uint Id { get; set; }
    public required string Name { get; set; }
}