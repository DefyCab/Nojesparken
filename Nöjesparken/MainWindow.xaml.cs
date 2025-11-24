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
                txtBox.Clear();
                txtBox.Focus();
                return true;
            }
        }
    }
}