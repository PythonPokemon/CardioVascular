using CardioVaskular.Models;
using Xunit;

namespace ModulTest
{
    public class UnitTest1
    {
        [Fact]
        public void Bmi_Calculation_IsCorrect()
        {
            // Arrange
            var profile = new ProfileModel();
            double height = 1.75; // Größe in Metern
            double weight = 70;   // Gewicht in Kilogramm

            // Act
            profile.Height = height;
            profile.Weight = weight;

            // Expected BMI = weight / (height^2) == 22.86 Bmi
            double expectedBmi = Math.Round(weight / Math.Pow(height, 2), 2);

            // Assert
            Assert.Equal(expectedBmi, profile.Bmi);
        }
    }
}
