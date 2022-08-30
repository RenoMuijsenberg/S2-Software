using AModelLayer.Models;
using LOGIC.Services.Models;

namespace LOGICinterface.Interfaces;

public interface IExcersiseService
{
    Task<GenericResult<ExcersiseModel>> CreateExcersise(ExcersiseModel excersise);
    Task<StandardResult> DeleteExcersise(int id);
    Task<GenericResult<ExcersiseModel>> GetExcersise(int id);
    Task<GenericResult<ExcersiseModel>> UpdateExcersise(ExcersiseModel excersise);
}