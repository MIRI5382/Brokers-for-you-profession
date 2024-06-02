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
    public class ServerBQrashteb:IbQreshten
    {
        private IDQweshten _idQweshten;
        public ServerBQrashteb(DalManager idQweshten) 
        {
            _idQweshten=idQweshten.SIdqweshten;
        }
        public BQreshten ConvertToBl(Qrashten dqrashten)
        {
            if (dqrashten == null) return null;
            BQreshten bqrashten = new BQreshten();
            bqrashten.CodeTest = dqrashten.CodeTest;
            bqrashten.CodeQrashten = dqrashten.CodeQrashten;
            bqrashten.Qrashten1 = dqrashten.Qrashten1;
            return bqrashten;
        }
        public Qrashten ConvertToDal(BQreshten bqrashten)
        {
            Qrashten dqrashten = new Qrashten();
            dqrashten.CodeTest = bqrashten.CodeTest;
            dqrashten.CodeQrashten = bqrashten.CodeQrashten;
            dqrashten.Qrashten1 = bqrashten.Qrashten1;
            return dqrashten;
        }
        public List<BQreshten> ListToBl(List<Qrashten> list)
        {
            List<BQreshten> lst = new List<BQreshten>();
            list.ForEach(x => lst.Add(ConvertToBl(x)));
            return lst;
        }

        public List<BQreshten>? GetAll()=>
            ListToBl(_idQweshten.GetAll());

        public int Post(BQreshten t)=>
           _idQweshten.Post(ConvertToDal(t));

        public bool Put(BQreshten t)=>
            _idQweshten.Put(ConvertToDal(t));
    }
}
