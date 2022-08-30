using AModelLayer.Models;
using DAL.DataContext;
using DALInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Functions.Specific;

public class Nutrition : INutrition
{
    private readonly DatabaseContext _db;

    public Nutrition(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<List<NutritionModel>> GetNutritionWithDate(DateTime date, string userId)
    {
        var nutrition = await _db.Nutritions.Where(x => x.Date.Date == date.Date && x.UserId == userId).ToListAsync();
        return nutrition;
    }
}