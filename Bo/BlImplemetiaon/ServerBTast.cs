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
    public class ServerBTast : IbTest
    {
        private IdTest _idtast;
        public ServerBTast(DalManager dalManager) 
        {
            _idtast = dalManager.SIdtest;
        }
        public BTast ConvertToBl(Test dtast)
        {
            if (dtast == null) return null;
            BTast btast = new BTast();
            btast.CodeSubject = dtast.CodeSubject;
            btast.CodeTest= dtast.CodeTest;
            return btast;
        }
        public Test ConvertToDal(BTast tast)
        {
            Test dtast = new Test();
            dtast.CodeSubject = tast.CodeSubject;
            dtast.CodeTest = tast.CodeTest;
            return dtast;
        }
        public List<BTast> ListToBl(List<Test> list)
        {
            List<BTast> lst = new List<BTast>();
            list.ForEach(x => lst.Add(ConvertToBl(x)));
            return lst;
        }
        public List<BTast>? GetAll()=>
            ListToBl(_idtast.GetAll());

        public int Post(BTast t)=>
            _idtast.Post(ConvertToDal(t));


        public bool Put(BTast t)=>
            _idtast.Put(ConvertToDal(t));


    }
}
