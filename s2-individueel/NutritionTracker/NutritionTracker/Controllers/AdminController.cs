using AModelLayer.Models;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB_APP.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private IProductService _productService;

    public AdminController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _productService.GetAllProducts();

        return View(result.result);
    }

    public IActionResult CreateProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductModel product, IFormCollection form)
    {
        var quantity =
            Convert.ToInt32(form["quantity"]); //convert to int because i cant send form object to class library.

        var result = await _productService.AddSingelProduct(product, quantity); //Wait for project to be added.

        if (result.success) //If project is added
        {
            TempData["Success"] = result.userMessage; //Show message that product is created
            return RedirectToAction("Index"); //Return to product overview
        }

        TempData["Error"] = result.userMessage; //Show message that product is created
        return View(product); //Return to create view when not successfull
    }

    public async Task<IActionResult> EditProduct(int id)
    {
        var result = await _productService.GetSingleProduct(id);

        return View(result.result);
    }

    [HttpPost]
    public async Task<IActionResult> EditProduct(ProductModel product, int id)
    {
        var result = await _productService.UpdateSingleProduct(product, id);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage; //Show message that product is updated

            return View(product);
        }

        TempData["Success"] = result.userMessage; //Show message that product is updated

        return RedirectToAction("Index"); //Return to overview of products
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProduct(id);

        if (!result.success) TempData["Error"] = result.userMessage; //Show message that product is updated

        TempData["Success"] = result.userMessage; //Show message that product is updated

        return RedirectToAction("Index");
    }
}