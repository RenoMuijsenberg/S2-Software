using AModelLayer.Models;
using DAL.DataContext;
using DALInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Functions.Specific;

public class Home : IHome
{
    private readonly DatabaseContext _db;

    public Home(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<SchemeModel> GetSchemesByUserAndDay(string userId, string today)
    {
        var scheme =
            await _db.Schemes.FirstOrDefaultAsync(x => x.UserId == userId && x.DayOne == today || x.DayTwo == today);

        scheme.Excersises = await _db.Excersises.Where(x => x.SchemeId == scheme.Id).OrderBy(x => x.DisplayOrder)
            .ToListAsync();

        foreach (var excersise in scheme.Excersises)
            excersise.Sets = await _db.Sets.Where(x => x.ExceriseId == excersise.Id).OrderBy(x => x.DisplayOrder)
                .ToListAsync();

        return scheme;
    }
}