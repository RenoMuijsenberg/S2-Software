using System.ComponentModel.DataAnnotations;

namespace AModelLayer.Models;

public class ProductModel
{
    public int Id { get; set; } //PK
    public string Name { get; set; }
    public float Calorie { get; set; }
    public float Fat { get; set; }
    public float Carb { get; set; }
    public float Protein { get; set; }
    public float Sugar { get; set; }
    public float Salt { get; set; }
    
    //A product can belong to multiple nutritions
    public ICollection<NutritionModel> Nutritions { get; set; }
}
