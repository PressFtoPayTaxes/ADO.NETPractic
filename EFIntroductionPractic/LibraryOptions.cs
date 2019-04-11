using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFIntroductionPractic
{
    static class LibraryOptions
    {
        public static List<Client> GetDebtors()
        {
            List<Client> debtors = new List<Client>();

            using (var context = new AppContext())
            {
                foreach (var client in context.Clients)
                    if (client.IsDebtor)
                        debtors.Add(client);
            }

            return debtors;
        }

        public static List<Author> GetThirdBookAuthors()
        {
            int thirdBookIndex = 2;
            List<Author> thirdBookAuthors = new List<Author>();
            Guid thirdBookId;

            using (var context = new AppContext())
            {
                thirdBookId = context.Books.ElementAt(thirdBookIndex).Id;
                foreach (var item in context.AuthorsAndBooks)
                    if (item.Book.Id == thirdBookId)
                        thirdBookAuthors.Add(item.Author);
            }

            return thirdBookAuthors;
        }

        public static List<Book> GetAvailableBooks()
        {
            List<Book> availableBooks = new List<Book>();

            using (var context = new AppContext())
            {
                foreach (var book in context.Books)
                {
                    bool isAvailable = true;
                    foreach (var client in context.Clients)
                    {
                        if (isAvailable)
                            foreach (var unavailableBook in client.Books)
                            {
                                if (book.Id == unavailableBook.Id)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }
                        else break;
                    }

                    if (isAvailable)
                        availableBooks.Add(book);
                }
            }

            return availableBooks;
        }

        public static List<Book> GetSecondClientBooks()
        {
            List<Book> secondClientBooks = new List<Book>();
            int secondClientsIndex = 1;

            using (var context = new AppContext())
            {
                secondClientBooks.AddRange(context.Clients.ElementAt(secondClientsIndex).Books);
            }

            return secondClientBooks;
        }

        public static void SetDebtersToZero()
        {
            using (var context = new AppContext())
            {
                foreach (var client in context.Clients)
                    if (client.IsDebtor)
                        client.IsDebtor = false;
            }
        }
    }
}
