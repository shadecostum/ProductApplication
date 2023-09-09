using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplication.Models
{
    internal class Customer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public Customer(int id, string name, List<Order> orders)
        {
            Id = id;
            Name = name;
            Orders = orders;
        }

        public int GetOrderCount()
        {
            return Orders.Count;
        }

        public double GetTotalOrderPrice()
        {
            double totalCost = 0;
            foreach (var order in Orders)
            {
                totalCost += order.CalculateOrderPrice();
            }
            return totalCost;
        }

        public string PrintCustomer()
        {
            string customeDetails = $"Customer Id: {Id}\n";
            customeDetails += $"Customer Name: {Name}\n";
            customeDetails += $"Total Orders: {GetOrderCount()}\n";

            for (int i = 0; i < Orders.Count; i++)
            {
                Order order = Orders[i];
                customeDetails += $"Order No. {i + 1}\n"+$"Order Id: {order.Id}\n"+ $"Order Date: {order.Date}\n\n";

                customeDetails += "LineItemId\tProductId\t" +
                    "ProductName\t" +"Quantity\t" +
                    "UnitPrice\t" +"Discount%\t" +
                    "UnitCostAfterDiscount\t" + "TotalLineItemCost\n";
           

                foreach (var item in order.Items)
                {
                    var product = item.Product;
                    customeDetails += $"{item.Id,-12}\t{product.Id,-12}\t{product.Name,-12}\t" +
                        $"{item.Quantity,-8}\t{product.Price,-12}\t{product.DiscountPercent}%\t\t" +
                        $"{product.CalculateDiscountedPrice()}\t\t\t{item.CalculateLineItemCost()}\n";
                }
                customeDetails += "\n";

                double orderCost = order.CalculateOrderPrice();
           

                string orderCostLine = $"Order Cost: {orderCost}";
             
                

                customeDetails += new string(' ', 120) + orderCostLine + "\n";
            }

            return customeDetails;
        }
    }
}
