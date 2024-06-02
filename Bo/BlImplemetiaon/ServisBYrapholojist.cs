using Bl.BlApi;
using Bl.Bo;
using Dal;
using Dal.DalApi;
using Dal.Do;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlImplemetiaon
{
    public class ServisBYrapholojist:IBYrapholojist
    {
        private IdYrapholojist _dYrapholojist;
        private IbToMatch _toMatch;
        public ServisBYrapholojist(DalManager dYrapholojist, IbToMatch toMatch)
        {
            _toMatch = toMatch;
            _dYrapholojist =dYrapholojist.SIdYrapholojist;
        }
        public BYrapholojist ConvertToBl(Yrapholojist y)
        {
            BYrapholojist t = new BYrapholojist();
            t.TzYrapholojist = y.TzYrapholojist;
            t.Sort = y.Sort;
            t.YToMatches = ((ServicBToMatch)_toMatch).ConvertTimeListToBl(y.ToMatches.ToList());
            return t;
        }
        public Yrapholojist ConvertToDal(BYrapholojist y)
        {
            Yrapholojist t = new Yrapholojist();
            t.TzYrapholojist = y.TzYrapholojist;
            t.Sort = y.Sort;
            if (y.YToMatches != null) y.YToMatches.ForEach(x => _toMatch.Post(x));          
            return t;
        }
        public List<BYrapholojist> ListToBl(List<Yrapholojist> list)
        {
            List<BYrapholojist> lst = new List<BYrapholojist>();
            list.ForEach(x => lst.Add(ConvertToBl(x)));
            return lst;
        }
        public List<Yrapholojist> ListToDal(List<BYrapholojist> list)
        {
            List<Yrapholojist> lst = new List<Yrapholojist>();
            list.ForEach(x => lst.Add(ConvertToDal(x)));
            return lst;
        }
        public List<BYrapholojist>? GetAll()=>
            ListToBl(_dYrapholojist.GetAll());

        public int Post(BYrapholojist item)=>
            _dYrapholojist.Post(ConvertToDal(item));

        public bool Put(BYrapholojist item)=>
            _dYrapholojist.Put(ConvertToDal(item));

    }
}
