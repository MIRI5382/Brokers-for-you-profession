using Bl.BlApi;
using Bl.BlImplemetiaon;
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
            //servBCollection.AddSingleton<ServiceBInscribed>();

            //בנית מנהל של סרויסים
            var servprovaider= servBCollection.BuildServiceProvider();

            //נגשים לאוביקט שהפרווידר מנהל
            blsubjects = servprovaider.GetRequiredService<ISubject>();
            //serviceBInscribed= servprovaider.GetRequiredService<ServiceBInscribed>();

        }


        



       

    }
}