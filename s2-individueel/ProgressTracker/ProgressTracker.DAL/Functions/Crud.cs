using DAL.DataContext;
using DALInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Functions.Crud;

public class Crud : ICrud
{
    private readonly DatabaseContext _db;

    public Crud(DatabaseContext db)
    {
        _db = db;
    }

    //Create new obj of given type
    public async Task<T> Create<T>(T objForDb) where T : class
    {
        await _db.AddAsync(objForDb); //Add obj to db
        await _db.SaveChangesAsync(); //Save db changes
        return objForDb; //Return created obj
    }

    //Get object based on id
    public async Task<T> Read<T>(int entityId) where T : class
    {
        var result = await _db.FindAsync<T>(entityId);
        return result;
    }

    //Get all entry from specific object
    public async Task<List<T>> ReadAll<T>() where T : class
    {
        var result = await _db.Set<T>().ToListAsync(); //Get all db entry from current object
        return result; //Return result
    }

    //Update any object
    public async Task<T> Update<T>(T objToUpdate, int entityId) where T : class
    {
        var obj = await _db.FindAsync<T>(entityId); //Find object we want to update based on id
        if (obj != null) //Check if found obj is not null
        {
            _db.Entry(obj).CurrentValues.SetValues(objToUpdate); //Replace found object values with new values
            await _db.SaveChangesAsync(); //Save changes in db
        }

        return obj; //Return updated object
    }

    //Delete given object
    public async Task<bool> Delete<T>(int entityId) where T : class
    {
        var objToDelete = await _db.FindAsync<T>(entityId); //Find obj based on id
        if (objToDelete != null) //Check if object exists
        {
            _db.Remove(objToDelete); //Remove object from db
            await _db.SaveChangesAsync(); //Save db changes
            return true; //(deleted)
        }

        return false; //(Not deleted)
    }
}