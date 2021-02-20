using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint
    //class:referans tip
    //IEntity: IEntity olabiliir veya IEMtity implemente eden bir nesne olabilir.
    //new(): new'lenebilir olmalı
    public interface IEntityRepository<T>where T:class, IEntity, new()  //<T> generic yapı T burada değişken gibi bu yapı nerede kullanılıyorsa T yerine oradaki değer yazılacak
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //linq expression kullanarak hepsi için ayrı ayrı category ıd getir productname getir diye yazmamıza gerek kalmayacak.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
