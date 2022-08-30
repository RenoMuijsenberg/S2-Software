using Newtonsoft.Json.Linq;
using ProgressTracker.MODEL.Models;
using ProgressTracker.MODEL.Models.Result;

namespace ProgressTracker.LOGIC.INTERFACES.Interfaces;

public interface ISetService
{
    Task<StandardResult> CreateSet(JObject sets);
    Task<GenericResult<List<SetModel>>> GetPrevSets(Guid id);
}