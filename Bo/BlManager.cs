using Bl.BlApi;
using Bl.BlImplemetiaon;
using Dal;
using Microsoft.Extensions.DependencyInjection;

namespace Bo
{
    public class BlManager
    {
        public ISubject blsubjects { get;  }
        public ICours blcours { get;  }
        public IGivensubject blgivensubject { get; }
        public ITime bltime { get; }
        public IBInscribed blinscribed { get; }
        public BlManager() 
        {
            //ריכוז של כל השרותים שצריך לרשימה אחת
            ServiceCollection servBCollection = new ServiceCollection();
            servBCollection.AddSingleton<DalManager>();
            servBCollection.AddSingleton<ISubject, ServerceBSubject>();
            servBCollection.AddSingleton<ICours,ServerBCours>();
            servBCollection.AddSingleton<IBInscribed, ServiceBInscribed>();
            servBCollection.AddSingleton<IGivensubject,BServGivenCours>();
            servBCollection.AddSingleton<ITime, SevicTime>();

            //בנית מנהל של סרויסים
            var servprovaider = servBCollection.BuildServiceProvider();

            //נגשים לאוביקט שהפרווידר מנהל
            
            blsubjects = servprovaider.GetRequiredService<ISubject>();
            blcours= servprovaider.GetRequiredService<ICours>();
            blgivensubject = servprovaider.GetRequiredService<IGivensubject>();
            bltime=servprovaider.GetRequiredService<ITime>();
            blinscribed=servprovaider.GetRequiredService<IBInscribed>();
            

        }


        



       

    }
}