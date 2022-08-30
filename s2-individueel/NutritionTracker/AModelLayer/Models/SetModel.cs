using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AModelLayer.Models;

public class SetModel
{
    public int Id { get; set; } //PK
    public int ExceriseId { get; set; } //FK
    public int DisplayOrder { get; set; }
    public int Reps { get; set; }
    public int Weight { get; set; }
    
    //RELATIONS:
    //A set belongs to only 1 excersise
    public ExcersiseModel Excersise { get; set; }
}