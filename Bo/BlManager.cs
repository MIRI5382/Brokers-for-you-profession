using Bl.BlApi;
using Bl.BlImplemetiaon;
using Dal;
using Microsoft.Extensions.DependencyInjection;

namespace Bo
{
    public class BlManager
    {
        public ISubject blsubjects { get;  }
        public ServerBCours blcours { get; }
        //public ServiceBInscribed serviceBInscribed { get; set; }
        public BlManager() 
        {
            //ריכוז של כל השרותים שצריך לרשימה אחת
            ServiceCollection servBCollection = new ServiceCollection();
            servBCollection.AddSingleton<DalManager>();
            servBCollection.AddSingleton<ISubject, ServerceBSubject>();
            servBCollection.AddSingleton<ServerBCours>();
            servBCollection.AddSingleton<ServiceBInscribed>();
            servBCollection.AddSingleton<BServGivenCours>();
            servBCollection.AddSingleton<ServiceBInscribed>();
            servBCollection.AddSingleton<SevicTime>();

            //בנית מנהל של סרויסים
            var servprovaider = servBCollection.BuildServiceProvider();

            //נגשים לאוביקט שהפרווידר מנהל
            try { 
            blsubjects = servprovaider.GetRequiredService<ISubject>();
            blcours= servprovaider.GetRequiredService<ServerBCours>();
            }
            catch (Exception ex) { }
            //serviceBInscribed= servprovaider.GetRequiredService<ServiceBInscribed>();

        }


        



       

    }
}