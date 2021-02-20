using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Çıplak class kalmasın standardı
    public class Category:IEntity //bu class hiçbir inheritance ya da interface almıyorsa ilerde problemler yaşanır işte biz b varlıklarımızı işaretleme yani gruplamaya gideriz. Concrete klasöründeki sınıflar bir veritabanı tablosuna karşılık geliyor. 
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
