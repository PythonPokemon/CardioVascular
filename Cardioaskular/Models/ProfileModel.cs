using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    Good to Know Goody 
 
 */
namespace CardioVaskular.Models
{
    // Die Klasse implementiert INotifyPropertyChanged
    public class ProfileModel : INotifyPropertyChanged
    {
        //----------------------------------------------------------------------------------------->DATUM<
        private int day;    // field
        public int Day      // property
        {
            get { return day; }
            set
            {
                if (day != value)   // Überprüft, ob der neue Wert anders ist
                {
                    day = value;    // Setzt den neuen Wert
                    OnPropertyChanged(nameof(Day));  // Benachrichtigt die UI, dass sich die Eigenschaft geändert hat
                    OnPropertyChanged(nameof(DateOfBirth)); // Aktualisiert auch DateOfBirth
                }
            }
        }

        private int month;

        public int Month

        {
            get { return month; }
            set
            {
                if (month != value)
                {
                    month = value; 
                    OnPropertyChanged(nameof(Month));
                    OnPropertyChanged(nameof(DateOfBirth)); // Aktualisiert auch DateOfBirth
                }
            }
        }

        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                if (year != value)
                {
                    year = value;
                    OnPropertyChanged(nameof(Year));
                    OnPropertyChanged(nameof(DateOfBirth)); // Aktualisiert auch DateOfBirth
                }
            }
        }

        // Berechnete Eigenschaft, die das Datum aus Day, Month und Year zusammensetzt
        public DateTime DateOfBirth
        {
            get
            {
                try
                {
                    return new DateTime(year, month, day); // Erstellt ein DateTime-Objekt
                }
                catch
                {
                    // Rückgabe eines Standardwerts, wenn das Datum ungültig ist
                    return DateTime.MinValue;
                }
            }
        }
        //----------------------------------------------------------------------------------------->Gender<

        private bool male;
        public bool Male

 
        {
            get { return male; }
            set
            {
                if (male != value)
                {
                    male = value;
                    OnPropertyChanged(nameof(Male));

                    // Automatisch auf 'Female' setzen, wenn 'Male' true ist
                    if (male)
                    {
                        Female = false;
                    }
                }
            }
        }

        private bool female;
        public bool Female


        {
            get { return female; }
            set
            {
                if (female != value)
                {
                    female = value;
                }
            }
        }

        private bool gender;
        public bool Gender


        {
            get { return gender; }
            set
            {
                if (gender != value)
                {
                    gender = value;
                }
            }
        }


        //-----------------------------------------------------------------------------------------
        private double height;
        private double weight;
        private double bmi;

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (height != value)
                {
                    height = Math.Round(value, 2);
                    if (height != 0)
                    {
                        Bmi = Math.Round(weight / Math.Pow(height, 2), 2);
                        OnPropertyChanged(nameof(Bmi));
                    }
                    // System.Diagnostics.Debug.WriteLine(height);
                }
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (weight != value)
                {
                    weight = Math.Round(value, 2);
                    if (weight != 0)
                    {
                        Bmi = Math.Round(weight / Math.Pow(height, 2), 2);
                        OnPropertyChanged(nameof(Bmi));
                    }
                    // System.Diagnostics.Debug.WriteLine(weight);
                }
            }
        }

        public double Bmi
        {
            get
            {
                return bmi;
            }
            set
            {
                if (bmi != value)
                {
                    bmi = Math.Round(value, 2);
                    // System.Diagnostics.Debug.WriteLine(bmi);
                }
            }
        }
        //-----------------------------------------------------------------------------------------

        // Event, das ausgelöst wird, wenn sich eine Eigenschaft ändert
        public event PropertyChangedEventHandler PropertyChanged;

        // Methode zum Auslösen des PropertyChanged-Events
        protected virtual void OnPropertyChanged(string propertyName)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (this.PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, e);
            }

        }


    }   
}
