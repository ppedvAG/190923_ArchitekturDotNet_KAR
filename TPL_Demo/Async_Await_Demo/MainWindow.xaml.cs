using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

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
            // t = new Timer(UhrzeitStellen,null,0,1000);

            //BackgroundWorker worker = new BackgroundWorker();
            // worker.DoWork += WorkerMachtWas;

            //worker.RunWorkerAsync();

            DispatcherTimer timer = new DispatcherTimer(); // Quasi wie Timer inkl UI-Thread (somit kein Dispatcher.Invoke notwendig !!!!)
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += DispatcherTimer_Tick;

            timer.Start();

            // Parallel
            // Auf 2 Kerne beschränken:
            // Parallel.For(0, 100, new ParallelOptions { MaxDegreeOfParallelism = 2 }, i => { });
        
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            textBlockUhr.Text = DateTime.Now.ToLongTimeString();
        }

        //private void WorkerMachtWas(object sender, DoWorkEventArgs e)
        //{
        //    MessageBox.Show("Worker macht was ...");
        //}

        //private Timer t;

        //private void UhrzeitStellen(object state)
        //{
        //    Dispatcher.Invoke(() => textBlockUhr.Text = DateTime.Now.ToLongTimeString());
        //}

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


            // async Task
            // async Task<T>
            // async void  <==== Rückwärtskompatiblität für EventHandler (signatur ist: void(object,eventargs))

            // Beispiel:

            string demo = await Task<string>.Run(() =>
            {
                return DateTime.Now.ToLongTimeString();
            });

            await Task.Delay(5000); // 5 sec warten vor dem ergebnis
            MessageBox.Show(demo);

            MessageBox.Show("Ende");
        }

        public Task MachEtwasMitDerProgressbar()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    Dispatcher.Invoke(() => progressBarWert.Value = i);
                    // "UI-Thread...bitte mach für mich xyz"
                }
            });
        }
    }
}
