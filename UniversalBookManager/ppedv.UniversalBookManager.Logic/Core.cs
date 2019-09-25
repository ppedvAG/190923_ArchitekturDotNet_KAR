﻿using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.UniversalBookManager.Logic
{
    public class Core // Geschäftslogik
    {
        public Core(IUnitOfWork UoW)
        {
            this.UoW = UoW;
        }
        public IUnitOfWork UoW { get; set; } // Relevant wenn andere Klasse über Core.Repository auf die DB zugreifen müssen

        // Geschäftslogik
        public void GenerateTestData()
        {
            Book b1 = new Book { Title = "Mein Garten", Author = "Tom Ate", Pages = 100, Price = 9.99m };
            Book b2 = new Book { Title = "Urlaub in der Karibik", Author = "Anna Nass", Pages = 200, Price = 19.99m };
            Book b3 = new Book { Title = "Küchen 1 mal 1", Author = "Peter Silie", Pages = 12, Price = 4.98m };
            Book b4 = new Book { Title = "Reiseführer Paris", Author = "Franz Ose", Pages = 300, Price = 39.99m };
            Book b5 = new Book { Title = "Faktencheck: Namen", Author = "Rainer Zufall", Pages = 40, Price = 0.99m };

            Store s1 = new Store();
            s1.Name = "Liesels Bücherladen";
            s1.Address = "Hauptstraße 1";
            s1.Inventory.Add(new Inventory { Book = b1, Amount = 15 });
            s1.Inventory.Add(new Inventory { Book = b2, Amount = 50 });
            s1.Inventory.Add(new Inventory { Book = b3, Amount = 10 });

            Store s2 = new Store();
            s2.Name = "Morawa";
            s2.Address = "Seitengasse 2";
            s2.Inventory.Add(new Inventory { Book = b2, Amount = 7 });
            s2.Inventory.Add(new Inventory { Book = b3, Amount = 8 });
            s2.Inventory.Add(new Inventory { Book = b4, Amount = 9 });

            Store s3 = new Store();
            s3.Name = "Thalia";
            s3.Address = "Feldweg 3";
            s3.Inventory.Add(new Inventory { Book = b3, Amount = 27 });
            s3.Inventory.Add(new Inventory { Book = b4, Amount = 28 });
            s3.Inventory.Add(new Inventory { Book = b5, Amount = 29 });

            UoW.StoreRepository.Add(s1);
            UoW.StoreRepository.Add(s2);
            UoW.StoreRepository.Add(s3);
            UoW.Save(); // Store mit Inventory-Einträgen mit Bücher
        }

        public Book[] GetAllBooks()
        {
            // Spezialvariante
            return UoW.BookRepository.GetAll().ToArray();

            // Universalvariante
            // return UoW.GetRepository<Book>().GetAll().ToArray();
        }
    }
}
