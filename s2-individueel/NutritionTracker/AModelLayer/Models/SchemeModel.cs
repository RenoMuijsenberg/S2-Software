using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AModelLayer.Models;

public class SchemeModel
{
    public int Id { get; set; } //PK
    public string UserId { get; set; } //FK
    public string Name { get; set; }
    public string DayOne { get; set; }
    public string? DayTwo { get; set; }

    
    //RELATIONS:
    //A scheme belongs to only 1 user
    public AppUserModel User { get; set; }
    //A scheme can have multiple excersises
    public ICollection<ExcersiseModel> Excersises { get; set; }
}