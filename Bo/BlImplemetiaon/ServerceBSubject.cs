using Bl.BlApi;
using Bl.Bo;
using Dal.Do;
using Bo;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlImplemetiaon
{
    public class ServerceBSubject : ISubject
    {
        public DalManager _dManager;

        public ServerceBSubject(DalManager dM)
        {
            _dManager = dM;
        }
        public List<MySubject> GetAll()=>        
          _dManager.SSubject.GetAll();

        //public List<MySubject> GetBySivog(MySubject sivog)=>    
        //    _dManager.SSubject.GetBySivog(sivog);
        private List<MySubject> mapAll;
        public List<MySubject> GetBySivog(MySubject sivog)
        {
            List<MySubject> all = _dManager.SSubject.GetAll().ToList<MySubject>();
            if (sivog.City != null)
                mapAll = GetSivog(x => x.City == sivog.City);
            if (sivog.SortStudents != null)
                mapAll = GetSivog(x => x.SortStudents == sivog.SortStudents);
            if (sivog.Categury == null)
                mapAll = GetSivog(x => x.Categury == sivog.Categury);
            return mapAll;
        }
       // private List<MySubject> GetSivog(Func<string, List<MySubject>> sivog) =>


        private List<MySubject> GetSivog(Predicate<MySubject> sivog) =>
             _dManager.SSubject.GetAll().ToList<MySubject>().FindAll(sivog);

        public List<MySubject>? GetByName(string name) =>
          _dManager.SSubject.GetByName(name);

        public int Post(MySubject subject)=>
           _dManager.SSubject.Post(subject);



    }
}
