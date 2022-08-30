using AModelLayer.Models;
using DAL.DataContext;
using DALInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Functions.Specific;

public class Set : ISet
{
    private readonly DatabaseContext _db;

    public Set(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<List<SetModel>> GetSetByExcersiseId(int excersiseId)
    {
        var sets = await _db.Sets.Where(x => x.ExceriseId == excersiseId).ToListAsync();
        return sets;
    }
}