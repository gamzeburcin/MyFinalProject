using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal() //constructor
        {
            //aşağıdaki ürn bilgileri Oracle,Sql Server, Postgre veya MongoDb'den geliyoemuş gibi davranıyoruz elle simüle ettik. 
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15 },
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3 },
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2 },
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65 },
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=15, UnitsInStock=1 }

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        { 
            //LINQ-Language Integrated Query
            //silerken adrese bakılarak silinir.
            //p=> bu işarete lambda denir
            //SingleOrDefault method
            Product productToDelete=_products.SingleOrDefault(p=>p.ProductId==product.ProductId); //p=> bu kod tek tek dolaşmayı sağlıyor. bu kod satırı aynı döngü gibi geziyor adreslere bakıyor silinecek ürünün adresini tespit ediyor.
            _products.Remove(productToDelete);
            
        }

        public List<Product> GetAll() //veritabnındaki datayı businessa vermem lazım
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürüm id'sine sahip olan listedeki ürünü bul demek. Ki güncelleme işlemini yapabilelim
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName; //productToUpdate'nin  name'ini gönderdiğim product'ın name'i yapabilirsin demek.
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId ).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
