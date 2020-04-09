using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OAUTHFACEBOOK
{
    public class vmPerfil : INotifyPropertyChanged
    {
        private string name;
        private string email;
        private string url;

        public string Name { get => name; set { name = value; NotifyPropertyChanged(nameof(Name)); } }

        public string Email { get => email; set { email = value; NotifyPropertyChanged(nameof(Email)); } }

        public string Url { get => url; set { url = value; NotifyPropertyChanged(nameof(Url)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
