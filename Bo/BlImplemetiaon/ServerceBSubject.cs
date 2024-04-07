using Bl.BlApi;
using Bl.Bo;
using Dal;
using Dal.DalApi;
using Dal.Do;


namespace Bl.BlImplemetiaon
{
    public class ServerceBSubject : IbSubject
    {
        private DalManager _dManager;
        private IdSubjects _dsobject;
        private IbCours _serverBCours;
        private IBInscribed _inscribed;
        private IbGivensubject _biGivenCours;
        public ServerceBSubject(IbGivensubject bServGivenCours, DalManager dM, IbCours serverBCours, IBInscribed inscribed)
        {
            _dManager = dM;
            _serverBCours = serverBCours;
            _inscribed = inscribed;
            _biGivenCours = bServGivenCours;
            _dsobject = dM.SSubject;
            
        }
        private List<BInscribed>? listGiven = new();
        public MySubject ConvertToDal(BSubject bSubject)
        {
            MySubject sub = new MySubject();
            sub.ContactMan = bSubject.ContactMan;
            sub.Place = bSubject.Place;
            sub.ContactManPhone = bSubject.ContactManPhone;
            if (bSubject.CodeSubject != null)
                sub.CodeSubject = (int)bSubject.CodeSubject;
            else sub.CodeSubject = 0;
            sub.SubjectName = bSubject.SubjectName;
            sub.Categury = bSubject.Categury;
            sub.City = bSubject.City;
            sub.Price = bSubject.Price;
            sub.SortStudents = bSubject.SortStudents;
            sub.MaxNumInscribed = bSubject.MaxNumInscribed;
            sub.NumInscribed = bSubject.NumInscribed;
            sub.LengthOf = bSubject.LengthOf;
            if (bSubject.SCourses != null) bSubject.SCourses.ForEach(x => _serverBCours.Post(x));
            if (bSubject.SInscribed != null) bSubject.SInscribed.ForEach(x => _inscribed.Post(x));
            if (bSubject.SGivenCourse != null)
                bSubject.SGivenCourse.ForEach(x => _biGivenCours.Post(x));
            //sub.GivenCourses.Add(((BServGivenCours)_biGivenCours).ConvertToDal(bSubject.SGivenCourse));
            return sub;
        }

        public BSubject ConvertToBl(MySubject Dsubject)
        {
            BSubject sub = new BSubject();
            sub.ContactMan = Dsubject.ContactMan;
            sub.Place = Dsubject.Place;
            sub.ContactManPhone = Dsubject.ContactManPhone;
            sub.CodeSubject = Dsubject.CodeSubject;
            sub.SubjectName = Dsubject.SubjectName;
            sub.Categury = Dsubject.Categury;
            sub.City = Dsubject.City;
            sub.Price = Dsubject.Price;
            sub.SortStudents = Dsubject.SortStudents;
            sub.MaxNumInscribed = Dsubject.MaxNumInscribed;
            sub.NumInscribed = Dsubject.NumInscribed;
            sub.LengthOf = Dsubject.LengthOf;
            sub.SCourses = ((ServerBCours)_serverBCours).ListToBl(Dsubject.Courses.ToList<Course>());
            //sub.SGivenCourse = ((BServGivenCours)_biGivenCours).ConvertToBl(Dsubject.GivenCourses.First(x => x.PhoneOfGivenCourses != null));
            sub.SGivenCourse = ((BServGivenCours)_biGivenCours).ListToBl(Dsubject.GivenCourses.ToList());
            sub.SInscribed = ((ServiceBInscribed)_inscribed).ListToBl(Dsubject.Inscribeds.ToList());
            return sub;
        }
        public List<BSubject> ListToBl(List<MySubject> list)
        {
            List<BSubject> lst = new List<BSubject>();
            list.ForEach(x => lst.Add(ConvertToBl(x)));
            return lst;
        }
        public List<BSubject> GetAll() =>
           ListToBl(_dsobject.GetAll());

        private List<BSubject> mapAll;


        //public List<BSubject> GetBySivog(SivogSubject sivog)
        //{
        //    mapAll = ListToBl(_dsobject.GetAll());
        //    if (sivog.City != null)
        //        mapAll = GetSivog(x => x.City == sivog.City);
        //    if (sivog.SortStudents != null)
        //        mapAll = GetSivog(x => x.SortStudents == sivog.SortStudents);
        //    if (sivog.Categury == null)
        //        mapAll = GetSivog(x => x.Categury == sivog.Categury);
        //    return mapAll;
        //}
        //private List<BSubject> GetSivog(Predicate<BSubject> sivog) =>
        //    ListToBl(_dsobject.GetAll().ToList<MySubject>()).FindAll(sivog);

        public List<BSubject>? GetByName(string name) =>
          ListToBl(_dsobject.GetByName(name));

        public int Post(BSubject subject)
        {
            int code = _dsobject.Post(ConvertToDal(subject));
            NewSubject.ListNewSubjectByCode.Add(subject);
            return code;
        }

        public List<BSubject>? GetSubjectClos()
        {
            List<BSubject> lst = new();
            bool flag1 = true;
            bool flag2 = true;
            foreach (BSubject Bsub in GetAll())
            {
                flag1 = true;
                flag2 = true;
                foreach (BCours cours in Bsub.SCourses)
                {
                    if (cours?.DateOfCourseEnd.Value.Month < DateTime.Today.Month)
                    {
                        flag1 = false;
                        break;
                    }
                    else if (cours?.DateOfCourseStart.Value.Month == DateTime.Today.Month + 1)
                    {
                        flag2 = false;
                    }
                }
                if (flag1 && !flag2)
                {
                    lst.Add(Bsub);
                }
            }
            return lst;
        }
        public List<BSubject>? GetNewSubject()=>     
             NewSubject.ListNewSubjectByCode;
          
  

        public bool Put(BSubject item) =>
            _dsobject.Put(ConvertToDal(item));

        public bool Delet(BSubject s)
        {
            var R = _dsobject?.GetAll()?.Find(X => X.CodeSubject.Equals(s.CodeSubject));
            return _dsobject.Delete(R);
        }
    }
}
