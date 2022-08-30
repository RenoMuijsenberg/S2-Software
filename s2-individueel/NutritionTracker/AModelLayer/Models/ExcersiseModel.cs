using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AModelLayer.Models;

public class ExcersiseModel
{
    public int Id { get; set; } //PK
    public int SchemeId { get; set; } //FK
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    
    //RELATIONS:
    //An excersise belongs to only scheme
    public SchemeModel Scheme { get; set; }
    
    //An excersise can have multiple sets
    public ICollection<SetModel> Sets { get; set; }
}