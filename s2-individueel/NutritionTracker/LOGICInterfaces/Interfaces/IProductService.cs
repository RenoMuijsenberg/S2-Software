using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AModelLayer.Models;

namespace LOGICinterface.Interfaces;

public interface IProductService
{
    //Create one product
    Task<GenericResult<ProductModel>> AddSingelProduct(ProductModel product, int quantity);

    //Get all products
    Task<GenericResult<List<ProductModel>>> GetAllProducts();

    //Get one product
    Task<GenericResult<ProductModel>> GetSingleProduct(int entityId);

    //Update product
    Task<GenericResult<ProductModel>> UpdateSingleProduct(ProductModel product, int id);

    //Delete product
    Task<StandardResult> DeleteProduct(int id);
}