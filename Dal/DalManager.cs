using Dal.Do;
using Dal.DalImplemetaion;
using Microsoft.Extensions.DependencyInjection;
using Dal.DalApi;

namespace Dal
{
    public class DalManager
    {
        public ISubjects SSubject { get; set; }
        public ICourses SCourses { get; set; }
        public IGivenCourses SCurrsesManagers { get; set; }
        public IInscribed SInscribed { get; }
        public IdTime SItime { get; }

        public DalManager()
        { 
            //ריכוז של כל השרותים שצריך לרשימה אחת
            ServiceCollection servCollect =new ServiceCollection();
            servCollect.AddSingleton<dbcontext>();
            servCollect.AddSingleton<IInscribed, InscribedServer>();
            servCollect.AddSingleton<ICourses, ServerCourses>();
            servCollect.AddSingleton<IGivenCourses, ServerCurrsesManagers>();
            servCollect.AddSingleton<ISubjects, ServerSubject>();
            servCollect.AddSingleton<IdTime, ServerTime>();
            //בנית מנהל של סרויסים
            var serviceprovider= servCollect.BuildServiceProvider();
            //נגשים לאוביקט שהפרווידר מנהל
            SSubject = serviceprovider.GetRequiredService<ISubjects>();
            SCourses = serviceprovider.GetRequiredService<ICourses>();
            SCurrsesManagers = serviceprovider.GetRequiredService<IGivenCourses>();
            SInscribed = serviceprovider.GetRequiredService<IInscribed>();
            SItime = serviceprovider.GetRequiredService<IdTime>();

        }
        
    }
}