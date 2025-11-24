using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nöjesparken
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private int _input = 0;

        private void Calculate(object sender, RoutedEventArgs e)
        {
            if (!CheckIfLengthIsOver140cm())

            {
                MessageBox.Show("Skriv i din längd i cm. Inga bokstäver!");
                txtBox.Clear();
                txtBox.Focus();
                return;
            }
            CheckWhichRidesYouCanUse();
        }

        private bool CheckIfLengthIsOver140cm()
        {
            bool isTrue = int.TryParse(txtBox.Text, out int input);
            if (!isTrue)
            {
                return false;
            }

            if (input > 139)
            {
                MessageBox.Show("Du är tillräckligt lång för att åka!\nGRATTIS!");
                return true;
            }

            else
            {
                MessageBox.Show("Tyvärr, du är inte tillräckligt lång för att åka.");
                return true;
            }
        }

        private void CheckWhichRidesYouCanUse()
        {
            string[] rides = ["Småbarnens karusell" , "Snurrande tekoppar",
                             "Flygande elefanter","Lilla berg-och-dal banan", "Stora berg-och-dal banan"];

            string[] allowedRides = new string[5];
            string show = "";
            int input = int.Parse(txtBox.Text);

            if (input >= 140)
            {
                allowedRides = [rides[0], rides[1], rides[2], rides[3], rides[4]];
                show = ShowRides(allowedRides);
            }

            else if (input < 140 && input > 130)
            {
                allowedRides = [rides[0], rides[1], rides[2], rides[3]];
                show = ShowRides(allowedRides);
            }

            else if (input < 130 && input > 110)
            {
                allowedRides = [rides[0], rides[1], rides[2]];
                show = ShowRides(allowedRides);
            }

            else if (input <= 110 && input > 89)
            {
                allowedRides = [rides[0], rides[1]];
                show = ShowRides(allowedRides);
            }

            else
            {
                show = rides[0];
            }

            MessageBox.Show($"Du får åka: {show}");
        }

        private string ShowRides(string[] allowedRides)
        {
            return String.Join(", ", allowedRides.Take(allowedRides.Count() - 1)) + " och " + allowedRides.Last();
        }
    }
}