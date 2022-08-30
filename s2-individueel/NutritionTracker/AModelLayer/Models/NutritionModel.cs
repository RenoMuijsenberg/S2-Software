using System.ComponentModel.DataAnnotations;

namespace AModelLayer.Models;

public class NutritionModel
{
    public int Id { get; set; } //PK
    public string UserId { get; set; } //FK
    public int ProductId { get; set; } //FK
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    
    //RELATIONS
    //A nutrition belongs to 1 user
    public AppUserModel User { get; set; }
    
    //A nutrition has 1 product
    public ProductModel Product { get; set; }
}
