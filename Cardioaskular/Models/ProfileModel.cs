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
        //----------------------------------------------------------------------------------------->Ethnic group<
        // String-Eigenschaft zur Speicherung der Ethnic Group Auswahl
        private string ethnicGroup;
        public string EthnicGroup
        {
            get { return ethnicGroup; }
            set
            {
                if (ethnicGroup != value)
                {
                    ethnicGroup = value;
                    OnPropertyChanged(nameof(EthnicGroup));
                    UpdateEthnicGroupFlags(); // Methode, um bool-Werte zu setzen
                }
            }
        }

        // Bool-Werte für jede Ethnic Group
        public bool IsWhiteOrNotStated { get; private set; }
        public bool IsIndian { get; private set; }
        public bool IsPakistani { get; private set; }
        public bool IsBangladeshi { get; private set; }
        public bool IsOtherAsian { get; private set; }
        public bool IsBlackCaribbean { get; private set; }
        public bool IsBlackAfrican { get; private set; }
        public bool IsChinese { get; private set; }
        public bool IsOtherEthnicGroup { get; private set; }

        // Methode, um die bool-Werte basierend auf der EthnicGroup Auswahl zu setzen
        private void UpdateEthnicGroupFlags()
        {
            // Alle bool-Werte auf false setzen
            IsWhiteOrNotStated = false;
            IsIndian = false;
            IsPakistani = false;
            IsBangladeshi = false;
            IsOtherAsian = false;
            IsBlackCaribbean = false;
            IsBlackAfrican = false;
            IsChinese = false;
            IsOtherEthnicGroup = false;

            // switch-Anweisung zur Auswahl
            switch (ethnicGroup)
            {
                case "White or not stated":
                    IsWhiteOrNotStated = true;
                    break;
                case "Indian":
                    IsIndian = true;
                    break;
                case "Pakistani":
                    IsPakistani = true;
                    break;
                case "Bangladeshi":
                    IsBangladeshi = true;
                    break;
                case "Other Asian":
                    IsOtherAsian = true;
                    break;
                case "Black Caribbean":
                    IsBlackCaribbean = true;
                    break;
                case "Black African":
                    IsBlackAfrican = true;
                    break;
                case "Chinese":
                    IsChinese = true;
                    break;
                case "Other ethnic group":
                    IsOtherEthnicGroup = true;
                    break;
            }

            // Benachrichtigung über Änderungen an den bool-Werten
            OnPropertyChanged(nameof(IsWhiteOrNotStated));
            OnPropertyChanged(nameof(IsIndian));
            OnPropertyChanged(nameof(IsPakistani));
            OnPropertyChanged(nameof(IsBangladeshi));
            OnPropertyChanged(nameof(IsOtherAsian));
            OnPropertyChanged(nameof(IsBlackCaribbean));
            OnPropertyChanged(nameof(IsBlackAfrican));
            OnPropertyChanged(nameof(IsChinese));
            OnPropertyChanged(nameof(IsOtherEthnicGroup));
        }




        //----------------------------------------------------------------------------------------->BMI<
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
        //----------------------------------------------------------------------------------------->EventHandler<

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
