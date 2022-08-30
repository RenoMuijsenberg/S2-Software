namespace AModelLayer.Models;

public class EatenTodayModel
{
    public int NutritionId { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public float Calorie { get; set; }
    public float Fat { get; set; }
    public float Carb { get; set; }
    public float Protein { get; set; }
    public float Sugar { get; set; }
    public float Salt { get; set; }
    public int Amount { get; set; }
}