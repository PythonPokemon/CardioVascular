using CardioVaskular.ViewModels;
using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace CardioVaskular.Views
{
    public partial class ProfileView : UserControl
    {
        // Bildpfaden für die ComboBox anzeige
        private readonly string[] imagePaths =
        {
            @"C:\Users\jakob.derzapf\Pictures\Screenshots\bild1.png",
            @"C:\Users\jakob.derzapf\Pictures\Screenshots\bild2.png",
            @"C:\Users\jakob.derzapf\Pictures\Screenshots\bild3.png",
            @"C:\Users\jakob.derzapf\Pictures\Screenshots\bild4.png",
            @"C:\Users\jakob.derzapf\Pictures\Screenshots\bild5.png"
        };
        public ProfileView()
        {
            InitializeComponent();
            this.DataContext = new ProfileViewModel(); // Hiermit wird das ViewModel gesetzt
        }

        // Event-Handler für die Auswahländerung in der ComboBox
        private void ImageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Index des ausgewählten Items holen
            int selectedIndex = ImageComboBox.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < imagePaths.Length)
            {
                // Bildpfad anhand des Indexes laden
                var imagePath = imagePaths[selectedIndex];

                // Bild im Image-Control anzeigen
                SelectedImage.Source = new BitmapImage(new Uri(imagePath));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Danke das du dir die Zeit zum durchlesen der AGB's nimmst:-)");
        }

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            CardioVaskular.ViewModels.ProfileViewModel ProfileViewModelObject =
               new CardioVaskular.ViewModels.ProfileViewModel();


            DataContext = ProfileViewModelObject;
        }

        // CheckBoxen | Next Button aktivieren, wenn beide CheckBoxen ausgewählt sind
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            NextButton.IsEnabled = TermsCheckBox1.IsChecked == true && TermsCheckBox2.IsChecked == true;
        }

        

        // Save Button
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            // Sammle die Daten, die gespeichert werden sollen
            var dataToSave = new
            {
                HasCardiovascularDisease = TermsCheckBox1.IsChecked == true,
                HasAcceptedTerms = TermsCheckBox2.IsChecked == true,
                //DateOfBirthDay = DayTextBox.Text,
                //DateOfBirthMonth = MonthTextBox.Text,
                //DateOfBirthYear = YearTextBox.Text,
                //EthnicGroup = EthnicComboBox.SelectedItem?.ToString(),
                //Height = HeightTextBox.Text,
                //Weight = WeightTextBox.Text

                // Weitere Felder nach Bedarf hinzufügen
            };

            // Erstelle einen JSON-String aus den Daten
            string json = JsonSerializer.Serialize(dataToSave);

            // SaveFileDialog verwenden, um den Speicherort auszuwählen
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.FileName = "userSettings.json";

            // Zeige den Dialog an und überprüfe, ob der Benutzer einen Pfad gewählt hat
            if (saveFileDialog.ShowDialog() == true)
            {
                // Speichere die Datei am gewählten Speicherort
                File.WriteAllText(saveFileDialog.FileName, json);
                MessageBox.Show("Daten erfolgreich gespeichert!", "Speichern", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void LoadButtonClick(object sender, RoutedEventArgs e)
        {
            // OpenFileDialog verwenden, um die Datei auszuwählen
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            openFileDialog.DefaultExt = "json";

            // Zeige den Dialog an und überprüfe, ob der Benutzer eine Datei ausgewählt hat
            if (openFileDialog.ShowDialog() == true)
            {
                // Dateiinhalt lesen
                string json = File.ReadAllText(openFileDialog.FileName);

                // JSON-Daten in ein dynamisches Objekt parsen
                using (JsonDocument document = JsonDocument.Parse(json))
                {
                    var root = document.RootElement;

                    // Daten aus dem JSON-Dokument in die Steuerelemente laden
                    TermsCheckBox1.IsChecked = root.GetProperty("HasCardiovascularDisease").GetBoolean();
                    TermsCheckBox2.IsChecked = root.GetProperty("HasAcceptedTerms").GetBoolean();
                    //DayTextBox.Text = root.GetProperty("DateOfBirthDay").GetString();
                    //MonthTextBox.Text = root.GetProperty("DateOfBirthMonth").GetString();
                    //YearTextBox.Text = root.GetProperty("DateOfBirthYear").GetString();
                    //EthnicComboBox.SelectedItem = root.GetProperty("EthnicGroup").GetString();
                    //HeightTextBox.Text = root.GetProperty("Height").GetString();
                    //WeightTextBox.Text = root.GetProperty("Weight").GetString();

                    // Weitere Felder nach Bedarf laden
                }

                // Optional: Benachrichtigung an den Benutzer
                MessageBox.Show("Daten erfolgreich geladen!", "Laden", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
