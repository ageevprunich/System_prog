using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        public Form1()
        {
            InitializeComponent();
            // Ініціалізуємо прогресбар
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Створення токена скасування
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            button1.Enabled = false;
            var progress = new Progress<int>(percent =>
            {
                progressBar1.Value = percent;
                label2.Text = $"{percent} %";
            });
            // Запуск асинхронної задачі, яка повертає результат
            try
            {
                int result = await Task.Run(() =>
                {
                    int sum = 0;
                    for (int i = 1; i <= 100; i++)
                    {
                        if (token.IsCancellationRequested)
                            token.ThrowIfCancellationRequested();

                        sum += i;
                        (progress as IProgress<int>)?.Report(i);
                        Thread.Sleep(20);
                    }
                    return sum;
                }, token);
                // Виводимо результат у label після завершення
                label1.Text = $"Сума чисел від 1 до 100: {result}";
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Операцію було скасовано.");
                label1.Text = "Скасовано";
                progressBar1.Value = 0;
                label2.Text = "0";
            }
            button1.Enabled = true;
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}

