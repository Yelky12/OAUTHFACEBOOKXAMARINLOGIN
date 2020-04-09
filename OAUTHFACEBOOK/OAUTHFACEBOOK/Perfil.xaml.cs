using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OAUTHFACEBOOK
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        vmPerfil vmPerfil;

        public Perfil()
        {
            InitializeComponent();

            FacebookProfile.Profile profile = JsonConvert.DeserializeObject<FacebookProfile.Profile>(Preferences.Get("usuarioActual", ""));

            vmPerfil = new vmPerfil { 
            
                Name=(profile??new FacebookProfile.Profile()).Name,
                Email= (profile ?? new FacebookProfile.Profile()).Email,
                Url= (profile ?? new FacebookProfile.Profile()).Picture.Data.Url
            };


            BindingContext = vmPerfil;
        }
    }
}