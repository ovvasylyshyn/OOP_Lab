//using System;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Animation;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace lab2_2_2
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();
//        }

//        private void CalcButton_Click(object sender, RoutedEventArgs e)
//        {
//                HideAllOutputs();

//                if (!double.TryParse(txtA.Text, out double a) ||
//                    !double.TryParse(txtB.Text, out double b) ||
//                    !double.TryParse(txtC.Text, out double c))
//                {
//                    MessageBox.Show("Введіть коректні числа!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
//                    return;
//                }

//                if (a == 0)
//                {
//                    MessageBox.Show("Це не квадратне рівняння (a = 0).", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
//                    return;
//                }

//                double d = b * b - 4 * a * c;
//                lblD.Content = $"Дискримінант D = {d}";
//                lblD.Visibility = Visibility.Visible;

//                if (d > 0)
//                {
//                    double x1 = (-b + Math.Sqrt(d)) / (2 * a);
//                    double x2 = (-b - Math.Sqrt(d)) / (2 * a);

//                    lblX1.Visibility = Visibility.Visible;
//                    txtX1.Visibility = Visibility.Visible;
//                    lblX2.Visibility = Visibility.Visible;
//                    txtX2.Visibility = Visibility.Visible;

//                    txtX1.Text = x1.ToString();
//                    txtX2.Text = x2.ToString();
//                }
//                else if (d == 0)
//                {
//                    double x = -b / (2 * a);

//                    lblX1.Visibility = Visibility.Visible;
//                    txtX1.Visibility = Visibility.Visible;

//                    txtX1.Text = x.ToString();
//                }
//                else
//                {
//                    lblNoSolutions.Content = "Рівняння не має дійсних розв'язків.";
//                    lblNoSolutions.Visibility = Visibility.Visible;
//                }
//            }

//        private void HideAllOutputs()
//        {
//            lblD.Visibility = Visibility.Collapsed;
//            lblX1.Visibility = Visibility.Collapsed;
//            txtX1.Visibility = Visibility.Collapsed;
//            lblX2.Visibility = Visibility.Collapsed;
//            txtX2.Visibility = Visibility.Collapsed;
//            lblNoSolutions.Visibility = Visibility.Collapsed;
//        }


//    }
//    }




using System;
using System.Windows;

namespace lab2_2_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HideAllOutputs();
        }

        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            HideAllOutputs(); // спочатку все ховаємо

            // зчитування та перевірка введення
            if (!double.TryParse(txtA.Text, out double a) ||
                !double.TryParse(txtB.Text, out double b) ||
                !double.TryParse(txtC.Text, out double c))
            {
                MessageBox.Show("Введіть коректні числа!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (a == 0)
            {
                MessageBox.Show("Це не квадратне рівняння (a = 0).", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double d = b * b - 4 * a * c;

            lblD.Content = $"Дискримінант D = {d}";
            lblD.Visibility = Visibility.Visible; // показуємо дискримінант завжди

            // обробка випадків
            if (d > 0)
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);

                // показуємо обидва розв’язки
                lblX1.Visibility = Visibility.Visible;
                txtX1.Visibility = Visibility.Visible;
                lblX2.Visibility = Visibility.Visible;
                txtX2.Visibility = Visibility.Visible;

                txtX1.Text = x1.ToString();
                txtX2.Text = x2.ToString();
            }
            else if (d == 0)
            {
                double x = -b / (2 * a);

                // показуємо лише перший розв’язок
                lblX1.Visibility = Visibility.Visible;
                txtX1.Visibility = Visibility.Visible;

                txtX1.Text = x.ToString();
            }
            else
            {
                // немає дійсних розв’язків
                lblNoSolutions.Content = "Рівняння не має дійсних розв'язків.";
                lblNoSolutions.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Метод для приховування всіх вивідних елементів.
        /// </summary>
        private void HideAllOutputs()
        {
            lblD.Visibility = Visibility.Hidden;
            lblX1.Visibility = Visibility.Hidden;
            txtX1.Visibility = Visibility.Hidden;
            lblX2.Visibility = Visibility.Hidden;
            txtX2.Visibility = Visibility.Hidden;
            lblNoSolutions.Visibility = Visibility.Hidden;
        }
    }
}
