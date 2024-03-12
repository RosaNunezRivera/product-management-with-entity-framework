using AutoMapper;
using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDLL
{
    /// <summary>
    /// Product repository to perform CRUD product's operation
    /// </summary>
    public class ProductRepository
    {
        /// <summary>
        /// Method to retrieve all the productos from the table into a List 
        /// collection 
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductsRepo() 
        {
            PMSEntities pms = new PMSEntities();
            return pms.Products.ToList();
        }

        /// <summary>
        /// add new productos to the table 
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public bool AddProductRepo(Product prod) 
        {
            try 
            {
                //Get the collections of data 
                PMSEntities pms = new PMSEntities();
                if (prod != null)
                {
                    //add the new product
                    pms.Products.Add(prod);
                    pms.SaveChanges();
                    return true;
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
        /// Retrieve the product information using the id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductByIdRepo(int id) 
        {
           //Get the collections of data 
           PMSEntities pms = new PMSEntities();
           return pms.Products.FirstOrDefault(x => x.ProductID == id);
        }


        /// <summary>
        /// Update the product information with the news values enter by the user
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public bool UpdateProductRepo(Product prod) 
        {
            try 
            {
                //Get the collections of data 
                PMSEntities pms = new PMSEntities();
                Product prodToBeUpdated = pms.Products.FirstOrDefault(x => x.ProductID == prod.ProductID);

                if (prodToBeUpdated != null)
                {
                    // assign new or updated object to the existing object
                    // save changes
                    Mapper.Map(prod, prodToBeUpdated);
                    pms.SaveChanges();
                    return true;
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
        /// Delete a product using the Product ID
        /// </summary>
        /// <param name="prodId"></param>
        /// <returns></returns>
        public bool DeleteProductRepo(int prodId)
        {
            try 
            {
                //Get the collections of data 
                PMSEntities pms = new PMSEntities();

                //Find the product's registered
                var prod = pms.Products.Where(x => x.ProductID == prodId).FirstOrDefault();
                if (prod != null)
                {
                    //Remove the product's register & save changes
                    pms.Products.Remove(prod);
                    pms.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return false;
            }
        }
    }
}
