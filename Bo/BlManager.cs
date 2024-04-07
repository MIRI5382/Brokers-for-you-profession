using Bl.BlApi;
using Bl.BlImplemetiaon;
using Dal;
using Dal.DalApi;
using Dal.DalImplemetaion;
using Microsoft.Extensions.DependencyInjection;

namespace Bo
{
    public class BlManager
    {
        public IbSubject blsubjects { get;  }
        public IbCours blcours { get;  }
        public IbGivensubject blgivensubject { get; }
        public IbTime bltime { get; }
        public IBInscribed blinscribed { get; }
        public IbTest bltast { get; }
        public IbQreshten blqrashten { get; }
        public IBAnswor blanswor { get; }
        public IBYrapholojist blYrapholojist { get; }
        public IbToMatch blToMatch { get; }
        public BlManager() 
        {
            //ריכוז של כל השרותים שצריך לרשימה אחת
            ServiceCollection servBCollection = new ServiceCollection();
            servBCollection.AddSingleton<DalManager>();
            servBCollection.AddSingleton<IbSubject, ServerceBSubject>();
            servBCollection.AddSingleton<IbCours,ServerBCours>();
            servBCollection.AddSingleton<IBInscribed, ServiceBInscribed>();
            servBCollection.AddSingleton<IbGivensubject,BServGivenCours>();
            servBCollection.AddSingleton<IbTime, SevicTime>();
            servBCollection.AddSingleton<IbTest, ServerBTast>();
            servBCollection.AddSingleton<IbQreshten, ServerBQrashteb>();
            servBCollection.AddSingleton<IBAnswor, ServerBAnswor>();
            servBCollection.AddSingleton<IBYrapholojist, ServisBYrapholojist>();
            servBCollection.AddSingleton<IbToMatch, ServicBToMatch>();
            servBCollection.AddSingleton<IbToMatch, ServicBToMatch>();

            //בנית מנהל של סרויסים
            var servprovaider = servBCollection.BuildServiceProvider();

            //נגשים לאוביקט שהפרווידר מנהל
            
            blsubjects = servprovaider.GetRequiredService<IbSubject>();
            blcours= servprovaider.GetRequiredService<IbCours>();
            blgivensubject = servprovaider.GetRequiredService<IbGivensubject>();
            bltime=servprovaider.GetRequiredService<IbTime>();
            blinscribed=servprovaider.GetRequiredService<IBInscribed>();
            bltast = servprovaider.GetRequiredService<IbTest>();
            blqrashten = servprovaider.GetRequiredService<IbQreshten>();
            blanswor = servprovaider.GetRequiredService<IBAnswor>();
            blYrapholojist = servprovaider.GetRequiredService<IBYrapholojist>();
            blToMatch = servprovaider.GetRequiredService<IbToMatch>();

        }








    }
}