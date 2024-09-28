using Fabiola_Prism.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fabiola_Prism.Helpers
{
    [ContentProperty("Text")]

    public class TranslationExtension : IMarkupExtension
    {
        private readonly CultureInfo ci;
        private const string ResourceId = "Fabiola_Prism.Resources.Resource";
        private static readonly Lazy<ResourceManager> ResMgr =
            new Lazy<ResourceManager>(() => new ResourceManager(
                ResourceId,
                typeof(TranslationExtension).GetTypeInfo().Assembly));

        public TranslationExtension()
        {
            ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if(Text == null)
            {
                return "";
            }

            string translation = ResMgr.Value.GetString(Text, ci);

            if(translation == null)
            {
                throw new ArgumentException(
                    string.Format(
                        "Key '{0}' was not found in resources '{1}' for culture '{2}'.",
                        Text, ResourceId, ci.Name), "Text");
            }

            return translation;
        }
    }
}
