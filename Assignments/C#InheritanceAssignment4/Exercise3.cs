using System;
using System.Collections.Generic;
using System.Text;

namespace C_InheritanceAssignment4
{
    class Order
    {
        public int OrderId { get; set; }
        public double OrderAmount { get; set; }

        public virtual double CalculateShippingCost()
        {
            return 50;
        }
    }

    class StandardOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 50;
        }
    }

    class ExpressOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 100;
        }
    }

    class InternationalOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 500;
        }
    }

    internal class Exercise3
    {
        static void Main()
        {
            List<Order> orders = new List<Order>();

            orders.Add(new StandardOrder());
            orders.Add(new ExpressOrder());
            orders.Add(new InternationalOrder());

            foreach (Order order in orders)
            {
                Console.WriteLine("Shipping Cost: " + order.CalculateShippingCost());
            }
        }
    }
}
