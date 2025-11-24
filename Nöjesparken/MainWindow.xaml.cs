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
            MessageBox.Show($"{Passengers()}");
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

            if (input < 129 && checkBoxAdult.IsChecked == true)
            {
                allowedRides = [rides[0], rides[1], rides[2]];
            }

            else if (input >= 140)
            {
                allowedRides = [rides[0], rides[1], rides[2], rides[3], rides[4]];
            }

            else if (input < 140 && input > 130)
            {
                allowedRides = [rides[0], rides[1], rides[2], rides[3]];
            }

            else if (input < 130 && input > 110)
            {
                allowedRides = [rides[0], rides[1], rides[2]];
            }

            else if (input <= 110 && input > 89)
            {
                allowedRides = [rides[0], rides[1]];
            }

            else
            {
                show = rides[0];
                MessageBox.Show($"Du får åka: {show}");
                return;
            }

            show = ShowRides(allowedRides);
            MessageBox.Show($"Du får åka: {show}");
        }

        private string ShowRides(string[] allowedRides)
        {
            return String.Join(", ", allowedRides.Take(allowedRides.Length - 1)) + " och " + allowedRides.Last();
        }

        private int Passengers()
        {
            int people = 0;
            int[] lengths = [
            186, 147, 175, 94, 171, 132, 145, 198, 104, 197,
            157, 198, 92, 129, 175, 124, 94, 185, 89, 106,
            135, 197, 103, 68, 136, 130, 197, 143, 102, 112,
            116, 175, 169, 140, 189, 194, 172, 182, 112, 163,
            164, 178, 168, 190, 143, 154, 168, 181, 157, 84,
            203, 188, 105, 175, 155, 140, 174, 203, 139, 106,
            173, 177, 195, 136, 166, 202, 161, 95, 181, 198,
            100, 141, 182, 97, 100, 191, 68, 101, 160, 93,
            146, 178, 74, 172, 184, 173, 138, 96, 144, 91,
            139, 104, 106, 142, 100, 179, 159, 160, 128, 121
            ];

            for (int i = 0; i < lengths.Length; i++)
            {
                if (lengths[i] <= 139 && lengths[i] >= 130)
                {
                    people++;
                }
            }
            return people;
        }
    }
}