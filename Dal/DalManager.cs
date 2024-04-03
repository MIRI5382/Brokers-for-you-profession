using Dal.Do;
using Dal.DalImplemetaion;
using Microsoft.Extensions.DependencyInjection;
using Dal.DalApi;

namespace Dal
{
    public class DalManager
    {
        public IdSubjects SSubject { get; set; }
        public IdCourses SCourses { get; set; }
        public IdGivenCourses SCurrsesManagers { get; set; }
        public IdInscribed SInscribed { get; }
        public IdTime SItime { get; }
        public IdTest SIdtest { get; }
        public IDQweshten SIdqweshten { get; }
        public IdAnswor SIdAnswor { get; }

        public DalManager()
        { 
            //ריכוז של כל השרותים שצריך לרשימה אחת
            ServiceCollection servCollect =new ServiceCollection();
            servCollect.AddSingleton<dbcontext>();
            servCollect.AddSingleton<IdInscribed, InscribedServer>();
            servCollect.AddSingleton<IdCourses, ServerCourses>();
            servCollect.AddSingleton<IdGivenCourses, ServerCurrsesManagers>();
            servCollect.AddSingleton<IdSubjects, ServerSubject>();
            servCollect.AddSingleton<IdTime, ServerTime>();
            servCollect.AddSingleton<IdTest, ServerTest>();
            servCollect.AddSingleton<IDQweshten, ServerQrashten>();
            servCollect.AddSingleton<IdAnswor, ServerAnswor>();
            //בנית מנהל של סרויסים
            var serviceprovider = servCollect.BuildServiceProvider();
            //נגשים לאוביקט שהפרווידר מנהל
            SSubject = serviceprovider.GetRequiredService<IdSubjects>();
            SCourses = serviceprovider.GetRequiredService<IdCourses>();
            SCurrsesManagers = serviceprovider.GetRequiredService<IdGivenCourses>();
            SInscribed = serviceprovider.GetRequiredService<IdInscribed>();
            SItime = serviceprovider.GetRequiredService<IdTime>();
            SIdtest = serviceprovider.GetRequiredService<IdTest>();
            SIdqweshten = serviceprovider.GetRequiredService<IDQweshten>();
            SIdAnswor = serviceprovider.GetRequiredService<IdAnswor>();

        }

    }
}