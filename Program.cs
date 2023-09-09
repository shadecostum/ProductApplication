using ProductApplication.Models;
using System.Globalization;
using System.Text;

namespace ProductApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Product dress = new Product(110, "T-shirt", 1000, 10);
            Product Bag = new Product(220, "Bag", 800, 20);
           

      
            LineItem LineItem1 = new LineItem(11, 2, dress);           
            LineItem LineItem2 = new LineItem(22, 1, Bag);      

           // LineItem LineItem3 = new LineItem(3, 6, dress);          
                    

            
            Order customerOrder1 = new Order(1, DateTime.Now, new List<LineItem> { LineItem1, LineItem2});
            Order customerOrder2 = new Order(2, DateTime.Now, new List<LineItem> { LineItem2});

       
            List<Order> customerOrders1 = new List<Order> { customerOrder1,new Order(3, DateTime.Now, new List<LineItem> { LineItem1})};

            
            Customer customer1 = new Customer(101, "Akash santhosh", customerOrders1);
            Customer customer2 = new Customer(102, "Babu", new List<Order> { customerOrder2 });

           

         
            Console.WriteLine(customer1.PrintCustomer());

            Console.WriteLine("==================================================================================================================================");
            Console.WriteLine(customer2.PrintCustomer());
        }
    }
}