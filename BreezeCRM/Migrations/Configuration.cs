using System;
using System.Collections.ObjectModel;
using System.Linq;
using BreezeCRM.Models;

namespace BreezeCRM.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CrmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CrmContext context)
        {
            if (context.Customers.Any())
            {
                return;
            }

            var randomOrderNumber = new Random(1000);
            var randomTotal = new Random(1);
            var randomDays = new Random();
            var me = new Customer
            {
                FirstName = "Noel", LastName = "Stieglitz", Orders = new Collection<Order>()
            };

            for (var i = 0; i < 200; i++)
            {
                me.Orders.Add(new Order
                {
                    Customer = me, 
                    DateOrdered = DateTime.Now.AddDays(-randomDays.Next(3000)), 
                    OrderNumber = randomOrderNumber.Next().ToString(), 
                    Total = randomTotal.Next(2000) * 1.3m
                });
            }

            context.Customers.AddOrUpdate(
              cust => cust.Id,
              me,
              new Customer { FirstName = "Jeffrey", LastName = "Richter" },
              new Customer { FirstName = "Jeff", LastName = "Prosise" },
              new Customer { FirstName = "John", LastName = "Robbins" }
            );
        }
    }
}
