using Bl.BlApi;
using Bl.Bo;
using Dal.Do;
using Dal;


namespace Bl.BlImplemetiaon
{
    public class ServerceBSubject : ISubject
    {
        private DalManager _dManager;
        private ServerBCours _serverBCours;
        private ServiceBInscribed _serviceBInscribed;
        private BServGivenCours _bServGivenCours;
        public ServerceBSubject(BServGivenCours bServGivenCours, DalManager dM, ServerBCours serverBCours, ServiceBInscribed serviceBInscribed)
        {
            _dManager = dM;
            _serverBCours= serverBCours;
            _serviceBInscribed = serviceBInscribed;
            _bServGivenCours = bServGivenCours;
        }
        private List<BInscribed>? listGiven = new();
        public MySubject ConvertToDal(BSubject bSubject)
        {
            MySubject sub=new MySubject();
            sub.ContactMan = bSubject.ContactMan;
            sub.Place=bSubject.Place;
            sub.ContactManPhone = bSubject.ContactManPhone;
            if(bSubject.CodeSubject != null)
                sub.CodeSubject =(int) bSubject.CodeSubject;
            else sub.CodeSubject = 0;
            sub.SubjectName = bSubject.SubjectName;
            sub.Categury = bSubject.Categury;
            sub.City = bSubject.City;
            sub.Price = bSubject.Price;
            sub.SortStudents = bSubject.SortStudents;
            sub.Tests = bSubject.Tests;
            sub.MaxNumInscribed = bSubject.MaxNumInscribed;
            sub.NumInscribed = bSubject.NumInscribed;
            sub.LengthOf = bSubject.LengthOf;
            if (bSubject.SCourses!=null)  bSubject.SCourses.ForEach(x=> _serverBCours.Post(x));
            if(bSubject.SInscribed!=null) bSubject.SInscribed.ForEach(x=> _serviceBInscribed.Pust(x));
            if (bSubject.SGivenCourse != null)  
            sub.GivenCourses.Add(_bServGivenCours.ConvertToDal(bSubject.SGivenCourse));
            return sub;
        }

        public BSubject ConvertToBl(MySubject Dsubject)
        {
            BSubject sub = new BSubject();
            sub.ContactMan = Dsubject.ContactMan;
            sub.Place = Dsubject.Place;
            sub.ContactManPhone = Dsubject.ContactManPhone;
            sub.CodeSubject= Dsubject.CodeSubject;
            sub.SubjectName= Dsubject.SubjectName;
            sub.Categury= Dsubject.Categury;
            sub.City= Dsubject.City;
            sub.Price= Dsubject.Price;
            sub.SortStudents= Dsubject.SortStudents;
            sub.Tests= Dsubject.Tests;
            sub.MaxNumInscribed= Dsubject.MaxNumInscribed;  
            sub.NumInscribed=Dsubject.NumInscribed;
            sub.LengthOf=Dsubject.LengthOf;
            sub.SCourses = _serverBCours.ListToBl(Dsubject.Courses.ToList<Course>());         
            sub.SGivenCourse =_bServGivenCours.ConvertToBl(Dsubject.GivenCourses.First(x=>x.PhoneOfGivenCourses!=null));
            sub.SInscribed = _serviceBInscribed.ListToBl(Dsubject.Inscribeds.ToList());
            return sub;
        }
        public List<BSubject> ListToBl(List<MySubject> list) { 
          List<BSubject> lst=new List<BSubject>();
          list.ForEach(x=> lst.Add(ConvertToBl(x)));
          return lst;
        }
        public List<BSubject> GetAll()=>        
           ListToBl(_dManager.SSubject.GetAll());

        private List<BSubject> mapAll;
        

        public List<BSubject> GetBySivog(SivogSubject sivog)
        {
            mapAll = ListToBl(_dManager.SSubject.GetAll());
            if (sivog.City != null)
                mapAll = GetSivog(x => x.City == sivog.City);
            if (sivog.SortStudents != null)
                mapAll = GetSivog(x => x.SortStudents == sivog.SortStudents);
            if (sivog.Categury == null)
                mapAll = GetSivog(x => x.Categury == sivog.Categury);
            return mapAll;
        }
        private List<BSubject> GetSivog(Predicate<BSubject> sivog) =>
            ListToBl( _dManager.SSubject.GetAll().ToList<MySubject>()).FindAll(sivog);

        public List<BSubject>? GetByName(string name) =>
          ListToBl(_dManager.SSubject.GetByName(name));

        public int Post(BSubject subject) =>   
          _dManager.SSubject.Post(ConvertToDal(subject));
       

        public List<BSubject>? GetSubjectClos()
        {
            List<BSubject> lst = new();
            bool flag1 = true;
            bool flag2 = true;
            foreach (BSubject Bsub in GetAll())
            {
                flag1 = true;
                flag2 = true;
                foreach(BCours cours in Bsub.SCourses)
                {
                    if (cours.DateOfCourseEnd.Value.Month < DateTime.Today.Month )
                    {
                        flag1 = false;
                        break;
                    }
                   else if (cours.DateOfCourseStart.Value.Month == DateTime.Today.Month+1)
                    {
                        flag2 = false;
                    }
                }
                if (flag1&&!flag2)
                {
                    lst.Add(Bsub);  
                }
            }          
            return lst;
        }




    }
}
