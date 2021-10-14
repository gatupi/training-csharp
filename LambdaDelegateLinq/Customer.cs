using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace LambdaDelegateLinq {
    class Customer {

        private string _name;

        private static uint _count = 0;
        private const string _defaultName = "Customer";
        private const int _nameMaxLength = 30;

        public Customer() : this(NextName(), new Random().Next(18, 61), (Sexes)new Random().Next(0,2), 100.0) { }

        public Customer(string name, int age, Sexes sex, double balance) {
            Name = name;
            Age = age;
            Sex = sex;
            Balance = balance;
            _count++;
        }

        public enum Sexes { Male, Female }
        public string Name {
            get => _name;
            set {
                _name = value.Length > _nameMaxLength ?
                    value.Substring(0, _nameMaxLength) :
                    (value.Length < 2 ? NextName() : value);
            }
        }
        public int Age { get; set; }
        public Sexes Sex { get; set; }
        public double Balance { get; set; }

        public bool Highlight { get; set; }

        private static string NextName() {
            return $"{_defaultName} {_count + 1}";
        }

        public override string ToString() {
            return
                $"{Name,-_nameMaxLength}, " +
                $"{Age,3} yo, " +
                $"{Sex.ToString()[0]}, " +
                $"R${Balance.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
