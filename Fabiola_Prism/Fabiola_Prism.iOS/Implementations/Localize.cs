using Fabiola_Prism.Helpers;
using Fabiola_Prism.Interfaces;
using Foundation;
using Intents;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Fabiola_Prism.iOS.Implementations.Localize))]
namespace Fabiola_Prism.iOS.Implementations
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            string netLanguage = "en";
            if(NSLocale.PreferredLanguages.Length > 0 )
            {
                string pref = NSLocale.PreferredLanguages[0];
                netLanguage = iOSToDotnetLanguage(pref);
            }
            // this gets called a lot - try/catch can be expensive so consider catching or something
            CultureInfo ci = null;
            try
            {
                ci = new System.Globalization.CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException)
            {
                //iOS locale not valid .NEt culture (eg. "en-ES" : English in Spain)
                // fall back to first characters, in this case "en"
                try
                {
                    string fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    ci = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException)
                {
                    // iOS language not valid .NET culture, falling back to English
                    ci = new CultureInfo("en");
                }
            }

            return ci;
        }       

        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        private string iOSToDotnetLanguage(string iOSLanguage)
        {
            string netLanguage = iOSLanguage;
            //certain languages need to be converted to CultureInfo equivalent
            switch (iOSLanguage)
            {
                case "ms-MY":
                case "ms-SG":
                    netLanguage = "ms";
                    break;
                case "gsw-CH":
                    netLanguage = "de-CH";
                    break;
            }
            return netLanguage;
        }

        private string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            string netLanguage = platCulture.LanguageCode;
            switch (platCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT";
                    break;
                case "gsw":
                    netLanguage = "de-CH";
                    break;
            }

            return netLanguage;
        }
    }
}