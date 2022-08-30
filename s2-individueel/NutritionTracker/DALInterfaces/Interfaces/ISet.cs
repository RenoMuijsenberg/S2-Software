using AModelLayer.Models;

namespace DALInterfaces.Interfaces;

public interface ISet
{
    Task<List<SetModel>> GetSetByExcersiseId(int excersiseId);
}