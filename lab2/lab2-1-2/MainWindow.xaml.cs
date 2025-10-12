using System.Windows;

namespace lab2_1_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!double.TryParse(txtX.Text, out double x))
                {
                    MessageBox.Show("x введено неправильно",
                        "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!double.TryParse(txtY.Text, out double y))
                {
                    MessageBox.Show("у введено неправильно",
                        "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!double.TryParse(txtZ.Text, out double z))
                {
                    MessageBox.Show("z введено неправильно",
                        "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (Math.Abs(x - y) < 1e-12)
                {
                    MessageBox.Show("х не має дорівнювати у",
                        "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (z <= 0)
                {
                    MessageBox.Show("Помилка, має бути z > 0",
                        "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double s = Math.Round(
                    (y - x) * ((Math.Cos(y) - Math.Log(z)) / (x - y)) / (1 + Math.Pow(x - z, 2)),
                    3
                );
                txtRes.Text = $"s = {s}";
            }
        
    }
    }
}