using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID bu yaptığımız şey solid'in içindeki o harfidir.
    //Open Closed Principle
    //yeni bir özellik ekliyorsan mevcuttaki hiçbir koduna dokunamazsın
    
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //IoC
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); //ben EfProductDal çalışıcam demek

            var result = productManager.GetProductDetails();
            if (result.Success==true)
            {
                foreach (var product in result.Data) //fiyatı 40 ve 100 arasındaki ürünleri filtreledik 
                {
                    Console.WriteLine(product.ProductName+ "/" +product.CategoryName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
