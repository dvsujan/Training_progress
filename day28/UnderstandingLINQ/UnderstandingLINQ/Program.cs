using UnderstandingLINQ.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UnderstandingLINQ
{
    internal class Program
    {
        void PrintTitleIdQuantityAndOrderId()
        {
            PubsContext context = new PubsContext();
            var orders = context.Sales
                            .GroupBy(s => s.TitleId)
                            .Select(s => new
                            {
                                Id = s.Key,
                                OrderDetails = s.Select(s => new
                                {
                                    OrderId = s.OrdNum,
                                    Quantity = s.Qty
                                })
                            });
            foreach (var order in orders)
            {
                Console.WriteLine("Title is");
                Console.WriteLine(order.Id);

                Console.WriteLine("Order details are ");
                foreach (var item in order.OrderDetails)
                {
                    Console.WriteLine(item.OrderId);
                    Console.WriteLine(item.Quantity);
                }
            }
        }
        void PrintTheBooksPulisherwise()
        {
            PubsContext context = new PubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t.Pub, (pid, title) => new { Key = pid, TitleCount = title.Count() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
            }
        }
        void PrintNumberOfBooksFromType(string type)
        {
            PubsContext context = new PubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            PubsContext context = new PubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }
        
        static void Main(string[] args)
        {
            Program program = new Program();
            program.PrintTitleIdQuantityAndOrderId(); 
        }
    }
}
