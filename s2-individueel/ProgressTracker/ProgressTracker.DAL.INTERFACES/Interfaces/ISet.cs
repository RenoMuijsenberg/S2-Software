using ProgressTracker.MODEL.Models;

namespace ProgressTracker.DAL.INTERFACES.Interfaces;

public interface ISet
{
    Task<List<SetModel>> GetPrevSets(Guid id);
}