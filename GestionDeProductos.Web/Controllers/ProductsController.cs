using GestionDeProductos.Web.Helpers;
using GestionDeProductos.Data.Models;
using GestionDeProductos.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionDeProductos.Data.Helpers;

namespace GestionDeProductos.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IBreadcrumbService _breadcrumbService;
        private string controllerName => nameof(ProductsController);
        private string productsLabel => "Products";


        public ProductsController(
            IBreadcrumbService breadcrumbService,
            IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            _breadcrumbService = breadcrumbService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.PrimaryBreadcrumb = _breadcrumbService.GetPrimaryBreadcrumb($"{controllerName}{nameof(Index)}");
                var products = await _unitOfWork.ProductsRepository.GetProducts();
                return View(products);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occurred. Your request cannot be completed.";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {

                ViewBag.PrimaryBreadcrumb = _breadcrumbService.GetPrimaryBreadcrumb($"{controllerName}{nameof(Create)}");
                ViewBag.SecondaryBreadcrumb = _breadcrumbService.GetSecondaryBreadcrumb($"{controllerName}{nameof(Create)}");
                ViewBag.ControllerName = productsLabel;

                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occurred. Your request cannot be completed.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Valida producto repetido

                    var productRepetid = await _unitOfWork.ProductsRepository.GetProductByName(products.Nombre);

                    if (productRepetid != null)
                    {
                        TempData["ErrorMessage"] = "Product already exists";
                    }
                    else
                    {

                        if (products.Cantidad > 100)
                        {
                            TempData["ErrorMessage"] = "The quantity must not exceed 100 units";
                        }
                        else
                        {
                            // Crear un nuevo GUID
                            Guid newGuid = Guid.NewGuid();

                            products.Id = newGuid;

                            await _unitOfWork.ProductsRepository.Add(products);
                            await _unitOfWork.Complete();

                            TempData["ResultMessage"] = "The Product was created successfully.";
                            return RedirectToAction(nameof(Index));
                        }                         
                        
                    }
                    
                }

                ViewBag.PrimaryBreadcrumb = _breadcrumbService.GetPrimaryBreadcrumb($"{controllerName}{nameof(Create)}");
                ViewBag.SecondaryBreadcrumb = _breadcrumbService.GetSecondaryBreadcrumb($"{controllerName}{nameof(Create)}");
                ViewBag.ControllerName = productsLabel;

                return View(products);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occurred. Your request cannot be completed.";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                ViewBag.PrimaryBreadcrumb = _breadcrumbService.GetPrimaryBreadcrumb($"{controllerName}{nameof(Details)}");
                ViewBag.SecondaryBreadcrumb = _breadcrumbService.GetSecondaryBreadcrumb($"{controllerName}{nameof(Details)}");
                ViewBag.ControllerName = productsLabel;

                if (id == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var products = await _unitOfWork.ProductsRepository.GetProductById(id);
                if (products == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(products);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occurred. Your request cannot be completed.";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            try
            {
                ViewBag.PrimaryBreadcrumb = _breadcrumbService.GetPrimaryBreadcrumb($"{controllerName}{nameof(Edit)}");
                ViewBag.SecondaryBreadcrumb = _breadcrumbService.GetSecondaryBreadcrumb($"{controllerName}{nameof(Edit)}");
                ViewBag.ControllerName = productsLabel;

                if (id == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var products = await _unitOfWork.ProductsRepository.Get(id);
                if (products == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(products);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occurred. Your request cannot be completed.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Products products)
        {
            try
            {

                if (ModelState.IsValid)
                {
                     
                    var productsToEdit = await _unitOfWork.ProductsRepository.Get(id);

                    if (productsToEdit != null)
                    {
                        if (products.Cantidad > 100)
                        {
                            TempData["ErrorMessage"] = "The quantity must not exceed 100 units";
                        }
                        else
                        {
                            productsToEdit.Nombre = products.Nombre;
                            productsToEdit.Descripcion = products.Descripcion;
                            productsToEdit.EsActivo = products.EsActivo;
                            productsToEdit.Cantidad = products.Cantidad;
                            productsToEdit.PrecioEntero = products.PrecioEntero;
                            productsToEdit.FechaExpiracion = products.FechaExpiracion;

                            await _unitOfWork.Complete();
                            TempData["ResultMessage"] = "The product was updated successfully.";
                            return RedirectToAction(nameof(Index));
                        }                            
                    } 
                    
                }

                ViewBag.PrimaryBreadcrumb = _breadcrumbService.GetPrimaryBreadcrumb($"{controllerName}{nameof(Edit)}");
                ViewBag.SecondaryBreadcrumb = _breadcrumbService.GetSecondaryBreadcrumb($"{controllerName}{nameof(Edit)}");
                ViewBag.ControllerName = productsLabel;

                return View(products);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occurred. Your request cannot be completed.";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                ViewBag.PrimaryBreadcrumb = _breadcrumbService.GetPrimaryBreadcrumb($"{controllerName}{nameof(Delete)}");
                ViewBag.SecondaryBreadcrumb = _breadcrumbService.GetSecondaryBreadcrumb($"{controllerName}{nameof(Delete)}");
                ViewBag.ControllerName = productsLabel;

                if (id == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var products = await _unitOfWork.ProductsRepository.GetProductById(id);
                if (products == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(products);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occurred. Your request cannot be completed.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            try
            {

                if (id == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var products = await _unitOfWork.ProductsRepository.Get(id);
                if (products == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _unitOfWork.ProductsRepository.Remove(products);
                    await _unitOfWork.Complete();
                    TempData["ResultMessage"] = "The product was deleted successfully.";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error has occurred. Your request cannot be completed.";
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
