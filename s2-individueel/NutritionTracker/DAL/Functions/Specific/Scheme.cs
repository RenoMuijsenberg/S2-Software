using AModelLayer.Models;
using DAL.DataContext;
using DALInterfaces.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Functions.Specific;

public class Scheme : IScheme
{
    private readonly DatabaseContext _db;

    public Scheme(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<List<SchemeModel>> GetSchemesByUser(string userId)
    {
        try
        {
            var schemes = await _db.Schemes.Where(x => x.UserId == userId).ToListAsync();

            foreach (var scheme in schemes)
            {
                scheme.Excersises = await _db.Excersises.Where(x => x.SchemeId == scheme.Id).ToListAsync();

                foreach (var excersise in scheme.Excersises)
                    excersise.Sets = await _db.Sets.Where(x => x.ExceriseId == excersise.Id).ToListAsync();
            }

            return schemes;
        }
        catch
        {
            throw;
        }
    }

    public async Task<SchemeModel> GetSchemeById(int id)
    {
        try
        {
            var scheme = _db.Schemes.First(x => x.Id == id);

            scheme.Excersises = await _db.Excersises.Where(x => x.SchemeId == scheme.Id).ToListAsync();

            foreach (var excersise in scheme.Excersises)
                excersise.Sets = await _db.Sets.Where(x => x.ExceriseId == excersise.Id).ToListAsync();

            return scheme;
        }
        catch
        {
            throw;
        }
    }
}