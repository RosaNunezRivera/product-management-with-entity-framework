using AutoMapper;
using PMBLL;
using PMDLL;
using ProductManagementSPAWithEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementSPAWithEntityFramework.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            //Create the object ProductService
            ProductService productService = new ProductService();

            //Create a object productsColletion to store the products using product service and prodc repository
            var productsCollection = productService.GetProducts();

            //Create a Virtual Model List object
            List<ProductVM> productVMs = new List<ProductVM>();

            //Using Mapper to copy the object 
            productVMs = Mapper.Map<List<Product>, List<ProductVM>>(productsCollection);

            //Bring the result of the GetProducts() using Json 
            return Json(productVMs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddProduct(Product prod)
        {
            //Create the object ProductService
            ProductService productService = new ProductService();

            //Boolean value 
            var productAdded = productService.AddProduct(prod);

            //Return Json response true if the product was added 
            return Json(productAdded, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductById(int id)
        {
            //Create the object ProductService
            ProductService productService = new ProductService();

            //Boolean value 
            var prodById = productService.GetProductById(id);

            //Return Json response true if the product was added 
            return Json(prodById, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateProduct(Product product)
        {
            //Create the object ProductService
            ProductService productService = new ProductService();

            //Boolean value
            var prodUpdated = productService.UpdateProduct(product);

            //Return Json response true if the product was added 
            return Json(prodUpdated, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteProduct(int prodId)
        {
            //Create the object ProductService
            ProductService productService = new ProductService();
            if (productService.DeleteProduct(prodId))
            {
                //Return Json response true if the product was added Produc
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}