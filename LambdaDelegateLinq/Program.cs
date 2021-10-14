using System;
using System.Collections.Generic;

namespace LambdaDelegateLinq {
    class Program {
        static void Main(string[] args) {

            Program p = new Program();
            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < 10; i++) {
                customers.Add(new Customer());
            }

            p.PrintCustomerList(customers);
            customers.ForEach(c => {
                if (c.Age <= 30) {
                    c.Highlight = true;
                    c.Balance += 210.0;
                }
            });
            p.NewLine();
            p.PrintCustomerList(customers);
            customers.RemoveAll(c => c.Age >= 40);

            p.NewLine();
            customers.ForEach(c => { c.Highlight = false; });
            p.PrintCustomerList(customers);
            Action<Customer, double> a = (a, b) => { a.Balance += b; };
            p.NewLine();
            foreach (Customer c in customers) a(c, 15.0);
            customers[2].Name = "Fulano da Silva Nome Comprido Pra Testar o Setter";
            p.PrintCustomerList(customers);
        }

        public void NewLine() {
            Console.WriteLine();
        }

        public void PrintCustomerList(List<Customer> customers) {

            if (customers != null) {
                foreach (Customer c in customers) {
                    if (c.Highlight) Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(c);
                    Console.ResetColor();
                }
            }
        }
    }
}
