using AModelLayer.Models;
using DALInterfaces.Interfaces;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;

namespace LOGIC.Services.Implementation;

public class SchemeService : ISchemeService
{
    private readonly ICrud _crud;
    private readonly IScheme _scheme;

    public SchemeService(ICrud crud, IScheme scheme)
    {
        _crud = crud;
        _scheme = scheme;
    }

    public async Task<GenericResult<List<SchemeModel>>> GetSchemesByUserId(string userId)
    {
        var result = new GenericResult<List<SchemeModel>>();
        try
        {
            var dalResult = await _scheme.GetSchemesByUser(userId);

            var dayIndex = new List<string>
                {"MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY"};
            dalResult = dalResult.OrderBy(x => dayIndex.IndexOf(x.DayOne.ToUpper())).ToList();

            foreach (var scheme in dalResult)
            {
                scheme.Excersises = scheme.Excersises.OrderBy(x => x.DisplayOrder).ToList();

                foreach (var excersise in scheme.Excersises)
                    excersise.Sets = excersise.Sets.OrderBy(x => x.DisplayOrder).ToList();
            }

            result.result = dalResult;
            result.success = true;
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }

    public async Task<GenericResult<SchemeModel>> GetSchemeById(int id)
    {
        var result = new GenericResult<SchemeModel>();
        try
        {
            var dalResult = await _scheme.GetSchemeById(id);

            dalResult.Excersises = dalResult.Excersises.OrderBy(x => x.DisplayOrder).ToList();

            result.result = dalResult;
            result.success = true;
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }

    public async Task<GenericResult<SchemeModel>> CreateScheme(SchemeModel scheme)
    {
        var result = new GenericResult<SchemeModel>();
        try
        {
            if (string.IsNullOrWhiteSpace(scheme.Name))
            {
                result.success = false;
                result.userMessage = "No name filled in";

                return result;
            }
            
            scheme = await _crud.Create(scheme);

            result.userMessage = string.Format("Scheme {0} was created successfully!", scheme.Name);
            result.result = scheme;
            result.success = true;
        }
        catch
        {
            result.userMessage = "Scheme was not created successfully, please try again.";
            result.success = false;
        }

        return result;
    }

    public async Task<GenericResult<SchemeModel>> UpdateScheme(SchemeModel scheme)
    {
        var result = new GenericResult<SchemeModel>();
        try
        {
            if (string.IsNullOrWhiteSpace(scheme.Name))
            {
                result.success = false;
                result.userMessage = "No name filled in";

                return result;
            }
            
            scheme = await _crud.Update(scheme, scheme.Id);

            result.userMessage = string.Format("Scheme {0} was updated successfully!", scheme.Name);
            result.result = scheme;
            result.success = true;
        }
        catch
        {
            result.userMessage = "Scheme was not updated successfully, please try again.";
            result.success = false;
        }

        return result;
    }

    public async Task<StandardResult> DeleteScheme(int id)
    {
        var result = new GenericResult<SchemeModel>();
        try
        {
            result.success = await _crud.Delete<SchemeModel>(id);
            result.userMessage = "Scheme was deleted successfully!";
        }
        catch
        {
            result.userMessage = "Scheme was not deleted successfully, please try again.";
            result.success = false;
        }

        return result;
    }
}