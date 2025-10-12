using System;
using System.Text;
using System.Windows;

namespace lab3_3
{
    public partial class MainWindow : Window
    {
        private double[] arr;
        private int n;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                n = int.Parse(InputN.Text);
                if (n <= 0)
                {
                    MessageBox.Show("Введіть додатнє число", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                arr = new double[n];
                Random rnd = new Random();

                for (int i = 0; i < n; i++)
                    arr[i] = Math.Round(rnd.NextDouble() * (18.3 + 14.2) - 14.2, 1);

                OriginalArrayText.Text = string.Join("  ", arr);
                ResultText.Text = "";
                ReversedArrayText.Text = "";
            }
            catch
            {
                MessageBox.Show("Некоректне значення n", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProcessArray_Click(object sender, RoutedEventArgs e)
        {
            if (arr == null || arr.Length == 0)
            {
                MessageBox.Show("Спочатку згенеруйте масив", "Увага", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            int minIndex = 0, maxIndex = 0;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] < arr[minIndex]) minIndex = i;
                if (arr[i] > arr[maxIndex]) maxIndex = i;
            }

            int start = Math.Min(minIndex, maxIndex);
            int end = Math.Max(minIndex, maxIndex);

            int sumOfIndexes = 0;
            for (int i = start + 1; i < end; i++)
                sumOfIndexes += i;

            for (int left = start + 1, right = end - 1; left < right; left++, right--)
            {
                double temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Мінімальний елемент = {arr[minIndex]} (індекс {minIndex})");
            sb.AppendLine($"Максимальний елемент = {arr[maxIndex]} (індекс {maxIndex})");
            sb.AppendLine($"Сума індексів елементів між мінімальним і максимальним = {sumOfIndexes}");

            ResultText.Text = sb.ToString();
            ReversedArrayText.Text = string.Join("  ", arr);
        }
    }
}
