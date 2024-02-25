using Bl.Do;
using Dal.DalImplemetaion;
using Microsoft.Extensions.DependencyInjection;

namespace Dal
{
    public class DalManager
    {
        public ServerSubject SSubject { get; set; }
        public ServerCourses SCourses { get; set; }
        public ServerCurrsesManagers SCurrsesManagers { get; set; }
        public InscribedServer SInscribed { get; set; }
       
        public DalManager()
        { 
            //ריכוז של כל השרותים שצריך לרשימה אחת
            ServiceCollection servCollect =new ServiceCollection();
            servCollect.AddSingleton<dbcontext>();
            servCollect.AddSingleton<InscribedServer>();
            servCollect.AddSingleton<ServerCourses>();
            servCollect.AddSingleton<ServerCurrsesManagers>();
            servCollect.AddSingleton<ServerSubject>();
            //בנית מנהל של סרויסים
            var serviceprovider= servCollect.BuildServiceProvider();
            //נגשים לאוביקט שהפרווידר מנהל
            SSubject = serviceprovider.GetRequiredService<ServerSubject>();
            SCourses = serviceprovider.GetRequiredService<ServerCourses>();
            SCurrsesManagers = serviceprovider.GetRequiredService<ServerCurrsesManagers>();
            SInscribed = serviceprovider.GetRequiredService<InscribedServer>();

        }
        
    }
}