using ppedv.UniversalBookManager.Data.EF;
using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Logic;
using ppedv.UniversalBookManager.UI.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.UniversalBookManager.UI.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            // Kontrollfreak-Antipattern
            core = new Core(new EFRepository(new EFContext()));
            GetAllBooksCommand = new Command(GetAllBooks);
        }
        private readonly Core core;

        public event PropertyChangedEventHandler PropertyChanged;

        public Book[] Books { get; set; }
        public Command GetAllBooksCommand { get; set; }
        private void GetAllBooks()
        {
            Books = core.GetAllBooks();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Books"));
        }
    }
}
