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
            HideAllOutputs(); 

            if (!double.TryParse(txtA.Text, out double a) ||
                !double.TryParse(txtB.Text, out double b) ||
                !double.TryParse(txtC.Text, out double c))
            {
                MessageBox.Show("Введіть коректні числа", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (a == 0)
            {
                MessageBox.Show("Це не квадратне рівняння (a = 0).", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double d = b * b - 4 * a * c;

            lblD.Content = $"Дискримінант D = {d}";
            lblD.Visibility = Visibility.Visible; 

            if (d > 0)
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);

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

                lblX1.Visibility = Visibility.Visible;
                txtX1.Visibility = Visibility.Visible;

                txtX1.Text = x.ToString();
            }
            else
            {
                lblNoSolutions.Content = "Рівняння не має дійсних розв'язків.";
                lblNoSolutions.Visibility = Visibility.Visible;
            }
        }

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
