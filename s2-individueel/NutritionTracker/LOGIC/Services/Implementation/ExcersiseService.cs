using AModelLayer.Models;
using DALInterfaces.Interfaces;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;

namespace LOGIC.Services.Implementation;

public class ExcersiseService : IExcersiseService
{
    private readonly ICrud _crud;
    private readonly ISet _set;

    public ExcersiseService(ICrud crud, ISet set)
    {
        _crud = crud;
        _set = set;
    }

    public async Task<GenericResult<ExcersiseModel>> CreateExcersise(ExcersiseModel excersise)
    {
        //Create new instace of result
        var result = new GenericResult<ExcersiseModel>();
        try
        {
            if (excersise.Name == "")
            {
                result.success = false;
                result.userMessage = "No named filled in";

                return result;
            }
            
            excersise.Id = 0;
            await _crud.Create(excersise);

            result.userMessage = string.Format("Excersise {0} was created successfully!", excersise.Name);
            result.result = excersise;
            result.success = true;
        }
        catch
        {
            result.userMessage = "Excersise was not created successfully, please try again.";
            result.success = false;
        }

        return result;
    }

    public async Task<GenericResult<ExcersiseModel>> GetExcersise(int id)
    {
        //Create new instace of result
        var result = new GenericResult<ExcersiseModel>();
        try
        {
            var dalResult = await _crud.Read<ExcersiseModel>(id);

            dalResult.Sets = await _set.GetSetByExcersiseId(dalResult.Id);
            dalResult.Sets = dalResult.Sets.OrderBy(x => x.DisplayOrder).ToList();

            result.result = dalResult;
            result.success = true;
        }
        catch
        {
            result.success = false;
        }

        return result;
    }

    public async Task<GenericResult<ExcersiseModel>> UpdateExcersise(ExcersiseModel excersise)
    {
        //Create new instace of result
        var result = new GenericResult<ExcersiseModel>();
        try
        {
            if (excersise.Name == "")
            {
                result.success = false;
                result.userMessage = "No named filled in";

                return result;
            }
            
            var dalResult = await _crud.Update(excersise, excersise.Id);

            result.result = dalResult;
            result.success = true;
        }
        catch
        {
            result.success = false;
        }

        return result;
    }

    public async Task<StandardResult> DeleteExcersise(int id)
    {
        //Create new instace of result
        var result = new GenericResult<ExcersiseModel>();
        try
        {
            result.userMessage = "Excersise was deleted successfully!";
            result.success = await _crud.Delete<ExcersiseModel>(id);;
        }
        catch
        {
            result.userMessage = "Excersise was not deleted successfully, please try again.";
            result.success = false;
        }

        return result;
    }
}