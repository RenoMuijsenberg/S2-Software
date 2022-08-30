using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using ProgressTracker.DAL.INTERFACES.Interfaces;
using ProgressTracker.MODEL.Models;

namespace ProgressTracker.DAL.Functions.Specific;

public class Set : ISet
{
    private readonly DatabaseContext _db;

    public Set(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<List<SetModel>> GetPrevSets(Guid id)
    {
        try
        {
            //Get prev date
            var date = await _db.Sets.Where(x => x.ExerciseId == id).OrderByDescending(x => x.Date).FirstOrDefaultAsync();

            var sets = await _db.Sets.Where(x => x.ExerciseId == id && x.Date == date.Date).ToListAsync();

            return sets;
        }
        catch
        {
            throw;

        }
    }
}