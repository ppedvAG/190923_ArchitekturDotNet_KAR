using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.UniversalBookManager.Domain;

namespace ppedv.UniversalBookManager.Data.EF.Tests
{
    [TestClass]
    public class EFContextTests
    {
        [TestMethod]
        public void EFContext_can_create_context()
        {
            EFContext context = new EFContext();
        }
        // testm + TAB + TAB

        [TestMethod]
        public void EFContext_can_create_Database()
        {
            EFContext context = new EFContext();
            context.Database.CreateIfNotExists();
        }

        // Create, Read, Update, Delete
        // CRUD - Tests

        [TestMethod]
        public void EFContext_can_CRUD_Book()
        {
            Book b1 = new Book { Author = "Michi Z", Title = "Basics Unit-Tests", Pages = 200, Price = 9.99m };
            string newTitle = "Mehr Unit Tests";

            // Create
            using (EFContext context = new EFContext())
            {
                context.Book.Add(b1); // --->  Insert-SQL-Befehl
                context.SaveChanges();
            } // .Dispose() -> context geschlossen

            // Check für Create
            using (EFContext context = new EFContext())
            {
                // Read -> wir können auslesen
                Book loadedBook = context.Book.Find(b1.ID);
                Assert.IsNotNull(loadedBook); // Check für Read
                Assert.IsTrue(loadedBook.Title == b1.Title); // Korrekte Variante: ObjectGraph-Vergleich
                                                             // Assert -> Annahmen für den Test -> Wenn die Annahme nicht stimmt, schlägt der Test fehl

                // Update
                loadedBook.Title = newTitle;
                context.SaveChanges();
            }


            // Check für Update
            using (EFContext context = new EFContext())
            {
                Book loadedBook = context.Book.Find(b1.ID);
                Assert.IsTrue(loadedBook.Title == newTitle);

                // Delete
                context.Book.Remove(loadedBook);
                context.SaveChanges();
            }

            using (EFContext context = new EFContext())
            {
                Book loadedBook = context.Book.Find(b1.ID);
                Assert.IsNull(loadedBook); // Check für Delete
            } 
        }
    }
}
