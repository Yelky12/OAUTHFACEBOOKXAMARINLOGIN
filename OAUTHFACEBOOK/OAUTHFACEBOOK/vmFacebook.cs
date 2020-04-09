using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Xamarin.Auth;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OAUTHFACEBOOK
{
   public  class vmFacebook
    {
        public Page Page { get; set; }
        public Command LoginFacebook { get; set; }

        public vmFacebook(Page pa)
        {
            

        
            Page = pa;

            LoginFacebook = new Command(() => login());
        }


        private void login()
        {
            var authenticator = new OAuth2Authenticator(
                Constantes.FacebookAndroidClientId,
                Constantes.FacebookScope,
                new Uri(Constantes.FacebookAuthorizeUrl),
                new Uri(Constantes.FacebookAccessTokenUrl),
                null);

            authenticator.Completed += Authenticator_Completed; ;
            authenticator.Error += Authenticator_Error; 

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();

            presenter.Login(authenticator);
        }

        private void Authenticator_Error(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= Authenticator_Completed;
                authenticator.Error -= Authenticator_Error;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }

        private async void Authenticator_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= Authenticator_Completed;
                authenticator.Error -= Authenticator_Error;
            }

            if (e.IsAuthenticated)
            {
                if (authenticator.AuthorizeUrl.Host == "www.facebook.com")
                {

                    var httpClient = new HttpClient();

                    var json = await httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=id,name,first_name,last_name,email,picture.type(large)&access_token=" + e.Account.Properties["access_token"]);


                    Preferences.Set("usuarioActual", json);

                     await Page.Navigation.PushModalAsync(new Perfil());
                }
            }
        }









    }
}
