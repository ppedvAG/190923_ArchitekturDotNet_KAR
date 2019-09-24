using ppedv.UniversalBookManager.Data.EF;
using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Logic;
using ppedv.UniversalBookManager.UI.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.UniversalBookManager.UI.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        // Andere Variante: Fody/PropertyChanged
        public MainViewModel()
        {
            // Kontrollfreak-Antipattern
            core = new Core(new EFRepository(new EFContext()));
            GetAllBooksCommand = new Command(GetAllBooks);
        }
        private readonly Core core;

        // ObservableCollection() -> NotifyPropertyChanged für:
        // Add(),Sort(), Remove(), Clear() o.ä

        // BindingList() -> NotifyPropertyChanged
        // --> Auch für Änderungen der Elemente selbst
        // -> z.B. Title wird im DataGrid umgeändert 

        private Book[] books;
        public Book[] Books
        {
            get => books;
            set => SetValue(ref books, value);
        }
        public Command GetAllBooksCommand { get; set; }
        private void GetAllBooks()
        {
            Books = core.GetAllBooks();
        }
    }
}
