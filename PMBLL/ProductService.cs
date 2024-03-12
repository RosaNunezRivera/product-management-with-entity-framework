using PMDLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PMBLL
{
    /// <summary>
    /// Class to create the produc services method to implemented the 
    /// CRUD operations 
    /// </summary>
    public class ProductService
    {
        /// <summary>
        /// GetProducts method that retrieve all the Productos from the table
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts() 
        {
            //Creating the object from Repository 
            ProductRepository pr = new ProductRepository();
            return pr.GetProductsRepo();
        }

        /// <summary>
        /// Retrieve the product using the prodid parameter 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id) 
        {
            ProductRepository pr = new ProductRepository();
            return pr.GetProductByIdRepo(id);
        }


        /// <summary>
        /// Add a new product after applied a validation to avoud null values and 
        /// negative values in price and quantity 
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public bool AddProduct(Product prod)
        {
            try
            {
                ProductRepository pr = new ProductRepository();
                //Add validation 
                if (ValidateProducts(prod.Name, prod.Category, prod.Supplier, prod.Quantity, prod.Price))
                    return pr.AddProductRepo(prod);
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Update information in a product after to validate if each value 
        /// met all the requierements (To avoid null values and negatives values)
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public bool UpdateProduct(Product prod) 
        {
            try
            {
                ProductRepository pr = new ProductRepository();
                if (ValidateProducts(prod.Name, prod.Category, prod.Supplier, prod.Quantity, prod.Price))
                {
                    return pr.UpdateProductRepo(prod);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Method to implemented a validation to avoid null values in name, 
        /// category, supplir and to avoid negative values in price and quantity 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="supplier"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool ValidateProducts(string name, string category, string supplier,int? quantity, decimal? price) 
        {
            try
            {
                bool validName = !string.IsNullOrEmpty(name);
                bool validCategory = !string.IsNullOrEmpty(category);
                bool validSupplier = !string.IsNullOrEmpty(supplier);

                //.HasValue check if not a null value 
                bool validQuantity = quantity.HasValue && quantity > 0;
                bool validPrice = price.HasValue && price > 0;

                return validName && validCategory && validSupplier && validQuantity && validPrice;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Delete product using the productid
        /// </summary>
        /// <param name="prodId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int prodId) 
        {
            try 
            {
                ProductRepository pr = new ProductRepository();
                //Delete product using code in Repository 
                return pr.DeleteProductRepo(prodId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return false;
            }
        }
    }
}
