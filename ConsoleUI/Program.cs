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
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); //ben EfProductDal çalışıcam demek
            foreach (var product in productManager.GetProductDetails()) //fiyatı 40 ve 100 arasındaki ürünleri filtreledik 
            {
                Console.WriteLine(product.ProductName+ "/" +product.CategoryName);
            }
        }
    }
}
