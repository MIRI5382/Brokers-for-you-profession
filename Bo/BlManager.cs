using Bl.BlApi;
using Bl.BlImplemetiaon;
using Bl.Bo;
using Dal;
using Microsoft.Extensions.DependencyInjection;

namespace Bo
{
    public class BlManager
    {
        public ISubject blsubjects { get;  }
        //public ServiceBInscribed serviceBInscribed { get; set; }
        public BlManager() 
        {
            //ריכוז של כל השרותים שצריך לרשימה אחת
            ServiceCollection servBCollection = new ServiceCollection();
            servBCollection.AddSingleton<DalManager>();
            servBCollection.AddSingleton<ISubject, ServerceBSubject>();
            servBCollection.AddSingleton<ServerBCours>();
            servBCollection.AddSingleton<NewSubject>();
            servBCollection.AddSingleton<ServiceBInscribed>();
            servBCollection.AddSingleton<BServGivenCours>();
            servBCollection.AddSingleton<ServiceBInscribed>();
            servBCollection.AddSingleton<SevicTime>();

            //בנית מנהל של סרויסים
            var servprovaider = servBCollection.BuildServiceProvider();

            //נגשים לאוביקט שהפרווידר מנהל
            blsubjects = servprovaider.GetRequiredService<ISubject>();
            //serviceBInscribed= servprovaider.GetRequiredService<ServiceBInscribed>();

        }


        



       

    }
}