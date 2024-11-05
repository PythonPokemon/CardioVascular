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

                    // Automatisch 'Female' auf 'false' setzen, wenn 'Male' true ist
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
                    OnPropertyChanged(nameof(Female));

                    // Automatisch 'Male' auf 'false' setzen, wenn 'Male' true ist
                    if (female)
                    {
                        Male = false;
                    }
                }
            }
        }

        //Frage wie man den Wert Speichert? der steht garnicht zur auswahl???
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
        private string? ethnicGroup;
        public string? EthnicGroup
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
        //----------------------------------------------------------------------------------------->Townsend quintile<

        // String-Eigenschaft zur Speicherung der 'Townsend quintile' Auswahl
        private string? townsendQuintile;
        public string? TownsendQuintile
        {
            get { return townsendQuintile; }
            set
            {
                if (townsendQuintile != value)
                {
                    townsendQuintile = value;
                    OnPropertyChanged(nameof(TownsendQuintile));
                    UpdateTownsendQuintileFlags(); // Methode, um bool-Werte zu setzen
                }
            }
        }

        // Bool-Werte für jede 'Townsend quintile' auswahl
        public bool IsVeryAffluent { get; private set; }
        public bool IsAffluent { get; private set; }
        public bool IsAverage { get; private set; }
        public bool IsBelowAverage { get; private set; }
        public bool IsLeastAffluent { get; private set; }


        // Methode, um die bool-Werte basierend auf der 'Townsend quintile' Auswahl zu setzen
        private void UpdateTownsendQuintileFlags()
        {
            // Alle bool-Werte auf false setzen
            IsVeryAffluent = false;
            IsAffluent = false;
            IsAverage = false;
            IsBelowAverage = false;
            IsLeastAffluent = false;
            

            // switch-Anweisung zur Auswahl
            switch (townsendQuintile)
            {
                case "Very affluent":
                    IsVeryAffluent = true;
                    break;
                case "Affluent":
                    IsAffluent = true;
                    break;
                case "Average":
                    IsAverage = true;
                    break;
                case "Below average":
                    IsBelowAverage = true;
                    break;
                case "Least affluent":
                    IsLeastAffluent = true;
                    break;
            }

            // Benachrichtigung über Änderungen an den bool-Werten
            OnPropertyChanged(nameof(IsVeryAffluent));
            OnPropertyChanged(nameof(IsAffluent));
            OnPropertyChanged(nameof(IsAverage));
            OnPropertyChanged(nameof(IsBelowAverage));
            OnPropertyChanged(nameof(IsLeastAffluent));
            
        }

        //----------------------------------------------------------------------------------------->Terms and Conditions<
        //sind in der code behind datei von 'ProfileView.xaml.cs'

        //----------------------------------------------------------------------------------------->Do you smoke<
        // String-Eigenschaft zur Speicherung der 'do you smoke' Auswahl
        private string? doYouSmoke;
        public string? DoYouSmoke
        {
            get { return doYouSmoke; }
            set
            {
                if (doYouSmoke != value)
                {
                    doYouSmoke = value;
                    OnPropertyChanged(nameof(DoYouSmoke));
                    UpdateDoYouSmokeFlags(); // Methode, um bool-Werte zu setzen
                }
            }
        }

        // Bool-Werte für jede 'do you smoke' Auswahl
        public bool IsNo { get; private set; }
        public bool IsQuit { get; private set; }
        public bool IsSLT10PerDay { get; private set; }
        public bool IsSLT20PerDay { get; private set; }
        public bool IsSmokeOver20PerDay { get; private set; }


        // Methode, um die bool-Werte basierend auf der 'do you smoke' Auswahl zu setzen
        private void UpdateDoYouSmokeFlags()
        {
            // Alle bool-Werte auf false setzen
            IsNo = false;
            IsQuit = false;
            IsSLT10PerDay = false;
            IsSLT20PerDay = false;
            IsSmokeOver20PerDay = false;


            // switch-Anweisung zur Auswahl
            switch (townsendQuintile)
            {
                case "No":
                    IsNo = true;
                    break;
                case "I quit":
                    IsQuit = true;
                    break;
                case "I smoke less than 10/day":
                    IsSLT10PerDay = true;
                    break;
                case "I smoke less than 20/day":
                    IsSLT20PerDay = true;
                    break;
                case "Least affluent":
                    IsSmokeOver20PerDay = true;
                    break;
            }

            // Benachrichtigung über Änderungen an den bool-Werten
            OnPropertyChanged(nameof(IsNo));
            OnPropertyChanged(nameof(IsQuit));
            OnPropertyChanged(nameof(IsSLT10PerDay));
            OnPropertyChanged(nameof(IsSLT20PerDay));
            OnPropertyChanged(nameof(IsSmokeOver20PerDay));

        }

        //----------------------------------------------------------------------------------------->Cholesterol & Blood Pressure (mmil/L & mg/dL)<
        private double totalCholesterol;
        public double TotalCholesterol
        {
            get { return totalCholesterol; }
            set
            {
                if (totalCholesterol != value)
                {
                    totalCholesterol = Math.Round(value, 2);
                    if (totalCholesterol != 0)
                    {
                        NonHDLCholesterol = Math.Round(weight / Math.Pow(totalCholesterol, 2), 2);
                        OnPropertyChanged(nameof(NonHDLCholesterol));
                    }
                    // System.Diagnostics.Debug.WriteLine(height);
                }
            }
        }

        private double hdlCholesterol;

        public double HdlCholesterol
        {
            get { return hdlCholesterol; }
            set
            {
                if (hdlCholesterol != value)
                {
                    hdlCholesterol = Math.Round(value, 2);
                    if (hdlCholesterol != 0)
                    {
                        NonHDLCholesterol = Math.Round(hdlCholesterol / Math.Pow(totalCholesterol, 2), 2);
                        OnPropertyChanged(nameof(NonHDLCholesterol));
                    }
                    // System.Diagnostics.Debug.WriteLine(weight);
                }
            }
        }

        private double nonHDLCholesterol;

        public double NonHDLCholesterol
        {
            get { return nonHDLCholesterol; }
            set
            {
                if (nonHDLCholesterol != value)
                {
                    nonHDLCholesterol = Math.Round(value, 2);
                    // System.Diagnostics.Debug.WriteLine(bmi);
                }
            }
        }


        //----------------------------------------------------------------------------------------->Lots of CheckBoxes (right side)<
        // Eigenschaften für jede CheckBox 
        // Checkbox 1
        private bool receivedBloodPressureTreatment;
        public bool ReceivedBloodPressureTreatment
        {
            get { return receivedBloodPressureTreatment; }
            set
            {
                if (receivedBloodPressureTreatment != value)
                {
                    receivedBloodPressureTreatment = value;
                    OnPropertyChanged(nameof(ReceivedBloodPressureTreatment));
                }
            }
        }

        // Checkbox 2
        private bool sufferFromDiabetes;
        public bool SufferFromDiabetes
        {
            get {return sufferFromDiabetes; }
            set
            {
                if (sufferFromDiabetes != value)
                {
                    sufferFromDiabetes = value;
                    OnPropertyChanged(nameof(SufferFromDiabetes));
                }
            }
        }

        // Checkbox 3
        private bool relativeSuffersFromCVD;
        public bool RelativeSuffersFromCVD
        {
            get { return relativeSuffersFromCVD; }
            set
            {
                if (relativeSuffersFromCVD != value)
                {
                    relativeSuffersFromCVD = value;
                    OnPropertyChanged(nameof(RelativeSuffersFromCVD));
                }
            }
        }

        // Checkbox 4
        private bool chronicKidneyDisease;
        public bool ChronicKidneyDisease
        {
            get { return chronicKidneyDisease; }
            set
            {
                if (chronicKidneyDisease != value)
                {
                    chronicKidneyDisease = value;
                    OnPropertyChanged(nameof(ChronicKidneyDisease));
                }
            }
        }

        // Checkbox 5
        private bool sufferedAtrialFibrillation;
        public bool SufferedAtrialFibrillation
        {
            get { return sufferedAtrialFibrillation; }
            set
            {
                if (sufferedAtrialFibrillation != value)
                {
                    sufferedAtrialFibrillation = value;
                    OnPropertyChanged(nameof(SufferedAtrialFibrillation));
                }
            }
        }

        // Checkbox 6
        private bool rheumatoidArthritis;
        public bool RheumatoidArthritis
        {
            get { return rheumatoidArthritis; }
            set
            {
                if (rheumatoidArthritis != value)
                {
                    rheumatoidArthritis = value;
                    OnPropertyChanged(nameof(RheumatoidArthritis));
                }
            }
        }

        // Methode, um alle ausgewählten CheckBoxen als Liste von Strings zurückzugeben
        public List<string> GetSelectedConditions()
        {
            var selectedConditions = new List<string>();

            if (ReceivedBloodPressureTreatment)
                selectedConditions.Add("Received blood pressure treatment");
            if (SufferFromDiabetes)
                selectedConditions.Add("Suffer from diabetes");
            if (RelativeSuffersFromCVD)
                selectedConditions.Add("Relative suffers from CVD");
            if (ChronicKidneyDisease)
                selectedConditions.Add("Chronic kidney disease");
            if (SufferedAtrialFibrillation)
                selectedConditions.Add("Suffered atrial fibrillation");
            if (RheumatoidArthritis)
                selectedConditions.Add("Rheumatoid arthritis");

            return selectedConditions;
        }

        //----------------------------------------------------------------------------------------->Save / Load / Next<
        // sind in der code behind datei von 'ProfileView.xaml.cs'

        //----------------------------------------------------------------------------------------->EventHandler<

        // Event, das ausgelöst wird, wenn sich eine Eigenschaft ändert, oder auch anders formuliert, ein  Event für die Benachrichtigung der Benutzeroberfläche
        public event PropertyChangedEventHandler? PropertyChanged;

        // Methode zum Auslösen des PropertyChanged-Events, oder auch anders formuliert, eine Methode zur Benachrichtigung der UI über Änderungen
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
