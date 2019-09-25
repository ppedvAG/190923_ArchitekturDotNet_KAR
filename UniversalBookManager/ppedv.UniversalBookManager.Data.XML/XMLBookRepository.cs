using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ppedv.UniversalBookManager.Data.XML
{
    public class XMLBookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAll()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Book[]));

            FileStream stream = new FileStream("Books.xml", FileMode.Open);
            Book[] data = (Book[])serializer.Deserialize(stream);
            stream.Close();

            return data;
        }

        #region ToDo: XML-Features implementieren
        public void Add(Book item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book item)
        {
            throw new NotImplementedException();
        }

        public Book GetBookWithHighestPrice()
        {
            throw new NotImplementedException();
        }

        public Book GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public int GetTotalAmountOfBooksInCirculation(Book b)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> Query()
        {
            throw new NotImplementedException();
        }

        public void Update(Book item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
