using CardioVaskular.Models;
using System;
using System.IO;
using System.Text.Json;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CardioVaskular.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        



        // Zuständig für den BMI Wert-----------------------------------------------------
        private ProfileModel _currentProfileModel;
        public ProfileModel MyModel { get; set; }
        public ProfileModel CurrentProfileModel
        {
            get { return _currentProfileModel; }
            set
            {
                _currentProfileModel = value;
                OnPropertyChanged(nameof(CurrentProfileModel));
            }
        }

        public ProfileViewModel()
        {
            CurrentProfileModel = new ProfileModel
            {
                
            };
            MyModel = new ProfileModel();
        }
        // Zuständig für den BMI Wert-----------------------------------------------------




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

