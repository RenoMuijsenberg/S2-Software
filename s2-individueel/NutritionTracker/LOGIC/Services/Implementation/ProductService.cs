using AModelLayer.Models;
using DALInterfaces.Interfaces;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;

namespace LOGIC.Services.Implementation;

public class ProductService : IProductService
{
    private readonly ICrud _crud;

    public ProductService(ICrud crud)
    {
        _crud = crud;
    }

    public async Task<GenericResult<ProductModel>> AddSingelProduct(ProductModel product, int quantity)
    {
        //Create new instace of result
        var result = new GenericResult<ProductModel>();
        try
        {
            if (String.IsNullOrWhiteSpace(product.Name))
            {
                result.success = false;
                result.userMessage = "Name is not filled in, please try again.";
                return result;
            }
            
            if (quantity > 0)
            {
                product.Calorie /= quantity;
                product.Carb /= quantity;
                product.Fat /= quantity;
                product.Protein /= quantity;
                product.Salt /= quantity;
                product.Sugar /= quantity;
            }
            
            product = await _crud.Create<ProductModel>(product);

            result.userMessage = string.Format("Product {0} was created successfully!", product.Name);
            result.result = product;
            result.success = true;
        }
        catch
        {
            result.userMessage = "Product was not created successfully, please try again.";
            result.success = false;
        }

        return result;
    }

    public async Task<GenericResult<List<ProductModel>>> GetAllProducts()
    {
        //Create instace of result
        var result = new GenericResult<List<ProductModel>>();
        try
        {
            //Get all db produts
            var products = await _crud.ReadAll<ProductModel>();

            result.success = true;
            result.result = products;
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.success = false;
        }

        return result;
    }

    public async Task<GenericResult<ProductModel>> GetSingleProduct(int entityId)
    {
        //Create result object
        var result = new GenericResult<ProductModel>();
        try
        {
            //Get db entity based on id
            var product = await _crud.Read<ProductModel>(entityId);

            result.success = true;
            result.result = product;
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }

    public async Task<GenericResult<ProductModel>> UpdateSingleProduct(ProductModel product, int id)
    {
        //Create result object
        var result = new GenericResult<ProductModel>();
        try
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                result.success = false;
                result.userMessage = string.Format("{0} was not updated successfully.", product.Name);
                return result;
            }
            
            await _crud.Update<ProductModel>(product, id);

            result.success = true;
            result.result = product;
            result.userMessage = string.Format("{0} was updated successfully.", product.Name);
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.userMessage = string.Format("{0} was not updated successfully.", product.Name);
        }

        return result;
    }

    public async Task<StandardResult> DeleteProduct(int id)
    {
        //Create result object
        var result = new StandardResult();
        try
        {
            result.success = await _crud.Delete<ProductModel>(id);
            result.userMessage = "Deleted successfully.";
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.userMessage = "Delete was not successfull.";
        }

        return result;
    }
}