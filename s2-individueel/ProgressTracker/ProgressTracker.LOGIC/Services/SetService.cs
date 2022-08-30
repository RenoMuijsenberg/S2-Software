using DALInterfaces.Interfaces;
using Newtonsoft.Json.Linq;
using ProgressTracker.DAL.INTERFACES.Interfaces;
using ProgressTracker.LOGIC.INTERFACES.Interfaces;
using ProgressTracker.MODEL.Models;
using ProgressTracker.MODEL.Models.Result;

namespace ProgressTracker.LOGIC.Services;

public class SetService : ISetService
{
    private readonly ICrud _crud;
    private readonly ISet _set;
    
    public SetService(ICrud crud, ISet set)
    {
        _crud = crud;
        _set = set;
    }
    
    public async Task<StandardResult> CreateSet(JObject sets)
    {
        var result = new StandardResult();
        try
        {
            string exerciseId = sets["id"].Value<string>();
            sets.Remove("id");
            DateTime date = DateTime.Now;

            foreach (var set in sets)
            {
                var setModel = new SetModel
                {
                    ExerciseId = Guid.Parse(exerciseId),
                    Set = set.Value.ToString(),
                    Date = date
                };
                await _crud.Create<SetModel>(setModel);
            }

            result.success = true;
            result.userMessage = string.Format("Successfully updated exercise.");
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.userMessage = string.Format("Unsuccessfully created exercise.");
        }

        return result;
    }
    
    public async Task<GenericResult<List<SetModel>>> GetPrevSets(Guid id)
    {
        var result = new GenericResult<List<SetModel>>();
        try
        {
            var dalResult = await _set.GetPrevSets(id);

            result.result = dalResult;
            result.success = true;

            result.success = true;
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }
}