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

/*

 */

namespace CardioVaskular.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {

        // Zuständig für den BMI-Wert
        private ProfileModel model;                // Field
        public ProfileModel Model  { get; set; }   // Property

        

        // Konstruktor des ProfileViewModel 
        public ProfileViewModel()
        {
            // Initialisierung der 'Model' Instanzen
            Model  = new ProfileModel();           // Erstellt eine weitere neue Instanz von ProfileModel und weist sie 'Model' zu, wird in der 'View' gebunden!

           
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

