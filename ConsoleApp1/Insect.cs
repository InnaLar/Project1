using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Insect
    {
        private string name;
        private int legsAmount;
        private int wingsAmount;
        private double lifetimeInYear;
        private int childPerYear;
        private const int minLegsAmount = 1;
        private const int minWingsAmount = 1;
        public Insect(string name, int legsAmount, int wingsAmount, double lifetimeInYear, int childPerYear)
        {
            if (legsAmount < 0) throw new Exception("Legs can't be less than 0!");
            if (wingsAmount < 0) throw new Exception("Wings can't be less than 0!");
            if (lifetimeInYear < 0) throw new Exception("Lifetime can't be less than 0!");
            if (childPerYear < 0) throw new Exception("Birthrate can't be less than 0!");
            this.name = name;
            this.legsAmount = legsAmount;
            this.wingsAmount = wingsAmount;
            this.lifetimeInYear = lifetimeInYear;
            this.childPerYear = childPerYear;
        }
        ~Insect() => Console.WriteLine("I was a pretty insect! I'll be reborn!");
        public override string ToString() => 
           $"Insect {name} has {legsAmount} legs, {wingsAmount} wings; it's lifetime is {lifetimeInYear} years; birthrate is {childPerYear} a year" ;
        public static Insect operator +(Insect x, Insect y) 
        {
            string[] arrayNameY = y.name.Split(';');
            string resultName = x.name;
            foreach (string name in arrayNameY)
            {
                resultName += ";+"+name;
            }
            Insect resultInsect = new Insect(resultName,x.legsAmount+y.legsAmount, x.wingsAmount + y.wingsAmount, x.lifetimeInYear + y.lifetimeInYear,x.childPerYear+y.childPerYear);
            return resultInsect;
        }
        public static Insect operator -(Insect x, Insect y)
        {
            string[] arrayNameY = y.name.Split(';');
            string resultName = x.name;
            foreach (string name in arrayNameY)
            {
                resultName += ";-" + name;
            }
            int resultLegs = Math.Abs(x.legsAmount - y.legsAmount ) < minLegsAmount ? minLegsAmount : Math.Abs(x.legsAmount - y.legsAmount);
            int resultWings = Math.Abs(x.wingsAmount - y.wingsAmount) < minWingsAmount ? minWingsAmount : Math.Abs(x.wingsAmount - y.wingsAmount);
            double resultLifetime = Math.Abs(x.lifetimeInYear - y.lifetimeInYear) < 0 ? 0 : Math.Round(Math.Abs(x.lifetimeInYear - y.lifetimeInYear),1);
            int resultChildPerYear = Math.Abs(x.childPerYear - y.childPerYear) < 0 ? 0 : Math.Abs(x.childPerYear - y.childPerYear);
            Insect resultInsect = new Insect(resultName, resultLegs, resultWings, resultLifetime, resultChildPerYear);
            return resultInsect;
        }

        public static bool operator true(Insect x) => x.legsAmount % 2 == 0 && x.wingsAmount % 2 == 0;
        public static bool operator false(Insect x) => x.legsAmount % 2 == 1 && x.wingsAmount % 2 == 1;
        public int this[int i] 
        {
            get 
            {
                if (i >= 0)
                {
                    return i * childPerYear;
                }
                else return 0;
            }
        }
        public int ProductivityPerLife() => (Int32)Math.Round(lifetimeInYear*childPerYear,1);
    }
}
