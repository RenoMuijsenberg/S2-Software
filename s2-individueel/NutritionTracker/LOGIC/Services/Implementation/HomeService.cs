using AModelLayer.Models;
using DALInterfaces.Interfaces;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;

namespace LOGIC.Services.Implementation;

public class HomeService : IHomeService
{
    private readonly IHome _home;

    public HomeService(IHome home)
    {
        _home = home;
    }

    public async Task<GenericResult<SchemeModel>> GetSingleScheme(string userId)
    {
        //Create result object
        var result = new GenericResult<SchemeModel>();
        try
        {
            //Get todays date
            var today = DateTime.Now.DayOfWeek.ToString();

            //Get db entity based on id
            var scheme = await _home.GetSchemesByUserAndDay(userId, today);

            result.success = true;
            result.result = scheme;
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }
}