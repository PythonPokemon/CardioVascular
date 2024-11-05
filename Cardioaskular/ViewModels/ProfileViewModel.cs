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
Warum diese Namensgebung sinnvoll ist:

1.bmiProfileData:   Das private Feld hat jetzt eine intuitive Benennung, die sofort deutlich macht, dass es sich um die BMI-Daten des Profils handelt.
2.BmiProfileData:   Die öffentliche Eigenschaft BmiProfileData ist konsistent benannt und beschreibt klar, dass sie die BMI-bezogenen Daten des Profils speichert.
3.SelectedBmiProfileData: Diese Eigenschaft drückt genau aus, dass es sich um die ausgewählten BMI-bezogenen Profildaten handelt. Das macht den Zweck dieser Eigenschaft sehr klar.

Vorteile der vorgeschlagenen Namensgebung:

Konsistenz: Alle Variablen und Eigenschaften folgen einem einheitlichen Namensschema, was die Lesbarkeit und Wartbarkeit des Codes verbessert.
Klarheit:   Der Bezug zu den BMI-Daten ist sofort erkennbar, was besonders in größeren Codebasen oder bei der Zusammenarbeit mit anderen Entwicklern hilfreich ist.
Präzision:  Die Namen sind präzise und beschreiben genau, welche Art von Daten die Variablen und Eigenschaften enthalten.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

private ProfileModel bmiProfileData;

// Eine private Instanzvariable (Feld) vom Typ ProfileModel
// "ProfileModel" ist eine benutzerdefinierte Klasse, die vermutlich Daten für ein Profil speichert, z.B. Gewicht, Größe, BMI, usw.
// Diese Variable ist "private", was bedeutet, dass sie nur innerhalb dieser Klasse zugänglich ist.
// Speichert intern die aktuellen BMI-bezogenen Profildaten
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

public ProfileModel BmiProfileData { get; set; } 

// Zugriff auf BMI-bezogene Daten des Profils von außen möglich
// Eine öffentliche Eigenschaft vom Typ ProfileModel
// Eigenschaften wie diese werden in der Regel verwendet, um Daten an die Benutzeroberfläche zu binden.
// "public" bedeutet, dass diese Eigenschaft von außerhalb der Klasse zugänglich ist.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

public ProfileModel SelectedBmiProfileData
{
    get { return bmiProfileData; } // Gibt den Wert von "bmiProfileData" zurück
    set
    {
        bmiProfileData = value; // Setzt den Wert von "bmiProfileData"
        OnPropertyChanged(nameof(SelectedBmiProfileData)); // Benachrichtigt die Benutzeroberfläche über die Änderung
    }
}

// Eine weitere öffentliche Eigenschaft vom Typ ProfileModel
// Diese Eigenschaft gibt den Wert von "bmiProfileData" zurück oder setzt ihn.
// "OnPropertyChanged" informiert die Benutzeroberfläche darüber, dass sich der Wert geändert hat.
// Dies ist wichtig für die Datenbindung in WPF, damit die UI aktualisiert wird.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

public ProfileViewModel()
{
    SelectedBmiProfileData = new ProfileModel(); // Erstellt ein neues Objekt vom Typ "ProfileModel" und weist es "SelectedBmiProfileData" zu
    BmiProfileData = new ProfileModel(); // Erstellt ein weiteres neues Objekt vom Typ "ProfileModel" und weist es "BmiProfileData" zu
}

// Konstruktor der Klasse "ProfileViewModel"
// Ein Konstruktor ist eine spezielle Methode, die aufgerufen wird, wenn ein Objekt der Klasse erstellt wird.
// Hier werden zwei Instanzen der Klasse "ProfileModel" erstellt und den Eigenschaften zugewiesen.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 */

namespace CardioVaskular.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        



        // Zuständig für den BMI Wert-----------------------------------------------------
        private ProfileModel bmiProfileData;                // Field
        public ProfileModel BmiProfileData  { get; set; }   // Property
        public ProfileModel SelectedBmiProfileData
        {
            get { return bmiProfileData; }
            set
            {
                bmiProfileData = value;
                OnPropertyChanged(nameof(SelectedBmiProfileData));
            }
        }

        // Konstruktor des ProfileViewModel 
        public ProfileViewModel()
        {
            SelectedBmiProfileData = new ProfileModel{};    // Erstellt eine neue Instanz von ProfileModel und weist sie SelectedBmiProfileData zu
            BmiProfileData  = new ProfileModel();           // Erstellt eine weitere neue Instanz von ProfileModel und weist sie 'BmiProfileData' zu, wird in der 'View' gebunden!
        }
        /*
        Was passiert hier?:
        Beim Erstellen eines ProfileViewModel-Objekts werden zwei neue Instanzen von ProfileModel erstellt. Diese Instanzen speichern die Daten für Height, Weight, und Bmi.
        Die View ist an die BmiProfileData-Eigenschaft des ProfileViewModel gebunden. 
        Wenn Sie in der Benutzeroberfläche z.B. die Größe (Height) oder das Gewicht (Weight) ändern, wird der Wert im ProfileModel-Objekt aktualisiert, 
        und der BMI wird automatisch neu berechnet.

        Zusammengefasst:
        Das ViewModel (ProfileViewModel) hält eine Referenz auf das Model (ProfileModel), indem es Instanzen davon in den Eigenschaften BmiProfileData und SelectedBmiProfileData speichert.
        Die View (Ihre XAML-Datei) ist an die Eigenschaften im ViewModel gebunden. Die Änderungen in der Benutzeroberfläche werden automatisch auf das Model übertragen.
        Die BMI-Berechnung erfolgt im Model (ProfileModel), und das ViewModel sorgt dafür, dass diese Berechnung in der Benutzeroberfläche angezeigt wird.
         */
        // Zuständig für den BMI Wert-----------------------------------------------------




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

