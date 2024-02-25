using Bl.BlApi;
using Bl.Bo;
using Bl.Do;
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

        public List<MySubject>? GetByName(string name) =>
          _dManager.SSubject.GetByName(name);

        public int Post(MySubject subject)=>
           _dManager.SSubject.Post(subject);



    }
}
