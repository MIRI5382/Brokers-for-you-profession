using Bl.Bo;
using Dal;
using Dal.Do;


namespace Bl.BlImplemetiaon
{    
    public class ServiceBInscribed
    {
        private DalManager _dm;

        public ServiceBInscribed(DalManager dm)
        {
            _dm =dm ;
        }
        public Inscribed ConvertToDal(BInscribed bInscribed)
        {
            Inscribed inscribed = new Inscribed();
            inscribed.SortInscribed = bInscribed.SortInscribed;
            inscribed.PhoneInscribed = bInscribed.PhoneInscribed;
            inscribed.TzInscribed = bInscribed.TzInscribed;
            inscribed.InscribedName = bInscribed.InscribedName;
            inscribed.InscribedSubjectCode = bInscribed.InscribedSubjectCode;
            inscribed.Age = bInscribed.Age;
            inscribed.Tests = bInscribed.Tests;
            return inscribed;
        }
        public BInscribed ConvertToBl(Inscribed bInscribed)
        {
            BInscribed inscribed = new BInscribed();
            inscribed.SortInscribed = bInscribed.SortInscribed;
            inscribed.PhoneInscribed = bInscribed.PhoneInscribed;
            inscribed.TzInscribed = bInscribed.TzInscribed;
            inscribed.InscribedName = bInscribed.InscribedName;
            inscribed.InscribedSubjectCode = bInscribed.InscribedSubjectCode;
            inscribed.Age = bInscribed.Age;
            inscribed.Tests = bInscribed.Tests;
            return inscribed;
        }
        public List<BInscribed> ListToBl(List<Inscribed> list) 
        {
            List<BInscribed> ls = new();
            list.ForEach(x => ls.Add( ConvertToBl(x)));
            return ls;
        }
        public int Pust(BInscribed i)=>   
            _dm.SInscribed.Post(ConvertToDal(i));
        
    }
}
