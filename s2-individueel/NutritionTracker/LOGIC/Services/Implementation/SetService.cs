using AModelLayer.Models;
using DALInterfaces.Interfaces;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;

namespace LOGIC.Services.Implementation;

public class SetService : ISetService
{
    private readonly ICrud _crud;

    public SetService(ICrud crud)
    {
        _crud = crud;
    }

    public async Task<GenericResult<SetModel>> CreateSet(SetModel set, int excersiseId)
    {
        //Create new instace of result
        var result = new GenericResult<SetModel>();
        try
        {
            if (set.Reps < 1 || set.Weight < 1)
            {
                result.success = false;
                result.userMessage = "Data not correctly filled in";

                return result;
            }
            
            set.Id = 0;
            set.ExceriseId = excersiseId;
            await _crud.Create(set);

            result.userMessage = "Set was created successfully!";
            result.result = set;
            result.success = true;
        }
        catch
        {
            result.userMessage = "Set was not created successfully, please try again.";
            result.success = false;
        }

        return result;
    }

    public async Task<GenericResult<SetModel>> GetSet(int id)
    {
        //Create new instace of result
        var result = new GenericResult<SetModel>();
        try
        {
            var dalResult = await _crud.Read<SetModel>(id);

            result.result = dalResult;
            result.success = true;
        }
        catch
        {
            result.success = false;
        }

        return result;
    }

    public async Task<GenericResult<SetModel>> UpdateSet(SetModel set)
    {
        //Create new instace of result
        var result = new GenericResult<SetModel>();
        try
        {
            if (set.Reps < 1 || set.Weight < 1)
            {
                result.success = false;
                result.userMessage = "Data not correctly filled in";

                return result;
            }
            
            await _crud.Update(set, set.Id);

            result.userMessage = "Set was updated successfully!";
            result.result = set;
            result.success = true;
        }
        catch
        {
            result.userMessage = "Set was not updated successfully, please try again.";
            result.success = false;
        }

        return result;
    }

    public async Task<StandardResult> DeleteSet(int id)
    {
        //Create new instace of result
        var result = new GenericResult<SetModel>();
        try
        {
            result.userMessage = "Set was deleted successfully!";
            result.success = await _crud.Delete<SetModel>(id);
        }
        catch
        {
            result.userMessage = "Set was not deleted successfully, please try again.";
            result.success = false;
        }

        return result;
    }
}