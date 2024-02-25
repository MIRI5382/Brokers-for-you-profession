using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dal.DalApi
{
    public interface ICrud<T>
    {
        public List<T> GetAll();
        //public T? GetById(T t);
        public bool Put(T t);//עדכון
        public int Post(T t);
        public bool Delete(T t);


    }
}
