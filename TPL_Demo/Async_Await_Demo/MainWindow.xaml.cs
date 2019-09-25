﻿using System;
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
            TaskBeendetEvent += Callback;
        }

        private void Callback(object sender, EventArgs e)
        {
            MessageBox.Show("Ende");
        }

        public event EventHandler TaskBeendetEvent;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Start");

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(200);
                    Dispatcher.Invoke(() => progressBarWert.Value = i);
                    // "UI-Thread...bitte mach für mich xyz"
                }
                TaskBeendetEvent?.Invoke(this, e);
            });

        
        }
    }
}
