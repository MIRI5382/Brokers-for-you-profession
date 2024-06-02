using Bl.BlApi;
using Bl.Bo;
using Dal;
using Dal.DalApi;
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlImplemetiaon
{
    public class ServerBAnswor : IBAnswor
    {
        private IdAnswor _idanswor;
        public ServerBAnswor(DalManager idanswor) 
        {
            _idanswor = idanswor.SIdAnswor;
        }
        public BAnswor ConvertToBl(Answor danswor)
        {
            if (danswor == null) return null;
            BAnswor banswor = new BAnswor();
            banswor.CodAnswor = danswor.CodAnswor;
            banswor.GredToAnswor = danswor.GredToAnswor;
            banswor.Aswor = danswor.Aswor;
            return banswor;
        }
        public Answor ConvertToDal(BAnswor banswor)
        {
            Answor danswor = new Answor();
            danswor.CodAnswor = banswor.CodAnswor;
            danswor.GredToAnswor = banswor.GredToAnswor;
            danswor.Aswor = banswor.Aswor;
            return danswor;
        }
        public List<BAnswor> ListToBl(List<Answor> list)
        {
            List<BAnswor> lst = new List<BAnswor>();
            list.ForEach(x => lst.Add(ConvertToBl(x)));
            return lst;
        }
        public List<BAnswor>? GetAll()=>
           ListToBl(_idanswor.GetAll());
       
        public int Post(BAnswor t)=>        
            _idanswor.Post(ConvertToDal(t));       

        public bool Put(BAnswor t)=>
           _idanswor.Put(ConvertToDal(t));
        
    }
}
