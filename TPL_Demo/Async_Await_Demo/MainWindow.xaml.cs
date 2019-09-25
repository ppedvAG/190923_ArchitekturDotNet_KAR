using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Async_Await_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public event EventHandler TaskBeendetEvent;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Start");

            //Task t1 = MachEtwasMitDerProgressbar()
            //await t1; // warten, wie bei t1.Wait();... aber mit dem Unterschied

            textBoxEingabe.Text = "Vor dem Task"; // Zugriff auf ein Element vom UI-Thread aus

            await MachEtwasMitDerProgressbar(); //.ConfigureAwait(false);

            textBoxEingabe.Text = "Nach dem Task"; // Zugriff auf ein Element vom UI-Thread aus
            // ^ mit ConfigureAwait -> Exception, weil wir hier nicht mehr im UI-Thread sind !!!!!

            MessageBox.Show("Ende");
        }

        public Task MachEtwasMitDerProgressbar()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(200);
                    Dispatcher.Invoke(() => progressBarWert.Value = i);
                    // "UI-Thread...bitte mach für mich xyz"
                }
            });
        }
    }
}
