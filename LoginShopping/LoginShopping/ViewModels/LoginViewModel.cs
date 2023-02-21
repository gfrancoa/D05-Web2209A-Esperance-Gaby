using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginShopping.ViewModels
{
    class LoginViewModel:INotifyPropertyChanged
    {
        private string propertyName;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
