namespace DALInterfaces.Interfaces;

public interface ICrud
{
    Task<T> Create<T>(T objForDb) where T : class;
    Task<T> Read<T>(int entityId) where T : class;
    Task<List<T>> ReadAll<T>() where T : class;
    Task<T> Update<T>(T objToUpdate, int entityId) where T : class;
    Task<bool> Delete<T>(int entityId) where T : class;
}