using System;
using System.Collections.Generic;
using System.Text;

namespace OAUTHFACEBOOK
{
    public class Constantes
    { 

        public static string FacebookAndroidClientId = "221072325205041";

        public static string FacebookScope = "email";
        public static string FacebookAuthorizeUrl = "https://www.facebook.com/dialog/oauth/";
        public static string FacebookAccessTokenUrl = "https://consultas-f8e9c.firebaseapp.com";
        public static string FacebookUserInfoUrl = "https://graph.facebook.com/me?fields=email&access_token={accessToken}";

        public static string FacebookAndroidRedirectUrl = "https://consultas-f8e9c.firebaseapp.com";
    }
}
