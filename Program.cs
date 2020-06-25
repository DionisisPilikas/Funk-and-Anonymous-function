using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates
{
    delegate decimal mydelegate(List<Laptop> list);

    class Laptop
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class DataBase
    {
        public List<Laptop> Laptops { get; set; }

        public DataBase()
        {
            Laptop l1 = new Laptop { Name = "sumsung1", Price = 100m };
            Laptop l2 = new Laptop { Name = "sumsung2", Price = 80m };
            Laptop l3 = new Laptop { Name = "sumsung3", Price = 200m };
            Laptop l4 = new Laptop { Name = "sumsung4", Price = 150m };
            Laptop l5 = new Laptop { Name = "sumsung5", Price = 120m };

            List<Laptop> list = new List<Laptop>() { l1, l2, l3, l4, l5 };

            Laptops = list;
        }
    }
    class backEnd
    {
        DataBase db = new DataBase();
        
        public List<Laptop> GetallLaptops()
        {
            var allLaptops = db.Laptops.ToList();
            return allLaptops;

        }
        public decimal GetTheMaxPrice()
        {
            var allLaptops = db.Laptops.ToList();

            decimal maxPrice = allLaptops[0].Price; 
            foreach(var laptop in allLaptops)
            {
                if(laptop.Price >maxPrice )
                {
                    maxPrice = laptop.Price;
                }
            }
            return maxPrice;
        }


        //whitoutdelegate
        public decimal GetMaxPriceB(List<Laptop> list)
        {
            decimal maxPrice = list[0].Price;
            foreach (var laptop in list)
            {
                if (laptop.Price > maxPrice)
                {
                    maxPrice = laptop.Price;
                }
            }
            return maxPrice;

        }
        //with delegate
        //public decimal GetMaxPriceDelegate(mydelegate elegxos)
        //{
        //    var allLaptops = db.Laptops.ToList();
        //    decimal maxPrice = elegxos(allLaptops);
         
        //    return maxPrice;
        //}

        public decimal GetMaxPriceDelegate(Func<List<Laptop>, decimal> elegxos)
        {
            var allLaptops = db.Laptops.ToList();
            decimal maxPrice = elegxos(allLaptops);

            return maxPrice;
        }

        public decimal GetAveragePrice()
        {
            var allLaptops = db.Laptops.ToList();
            decimal Average;
            decimal sum = 0;

            foreach(var laptop in allLaptops)
            {

                sum = sum + laptop.Price; 
            }
            Average = sum / allLaptops.Count();

            return Average;
        }
    }
    class FrontEnd
    {
        backEnd b = new backEnd();

        public void PrintAll()
        {
            var all = b.GetallLaptops();

            foreach(var laptop in all)
            {
                Console.WriteLine("name= " + laptop.Name + " Price = " + laptop.Price);
            }
        }
        public void PrintMaxValue()
        {
            decimal max = b.GetTheMaxPrice();
            Console.WriteLine("h max timh einai : " + max);

        }

        public void PrintAverageValue()
        {
            decimal Av = b.GetAveragePrice();
            Console.WriteLine("H Average einai : " + Av);
        }
        public void GetMaxB()
        {
            var all = b.GetallLaptops();

            decimal max = b.GetMaxPriceB(all);
            Console.WriteLine("h max timh einai : " + max);
        }



        mydelegate check = MaxCondition;

        static decimal MaxCondition(List<Laptop> list)
        {
            decimal max = 0;
            foreach (var laptop in list)
            {

                if (laptop.Price > max)
                {
                    max = laptop.Price;

                }
            }
            return max;
        }

        //Func<List<Laptop>, decimal> checkFunc = MaxCondition;


        //Func<List<Laptop>, decimal> checkFunc = delegate (List<Laptop> list)
        //{
        //    decimal max = 0;
        //    foreach (var laptop in list)
        //    {

        //        if (laptop.Price > max)
        //        {
        //            max = laptop.Price;

        //        }
        //    }
        //    return max;

        //};


        Func<List<Laptop>, decimal> checkFunc = (list) =>
        {      
            decimal max = 0;
            foreach (var laptop in list)
            {

                if (laptop.Price > max)
                {
                    max = laptop.Price;

                }
            }
            return max;
        };




        public void PrintMaxNew()
        {
            var all = b.GetallLaptops();
            decimal maxPRICE = b.GetMaxPriceDelegate(checkFunc);

            Console.WriteLine(maxPRICE);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FrontEnd f = new FrontEnd();

            f.PrintAll();
            f.PrintMaxValue();
            f.PrintAverageValue();

            f.GetMaxB();
            Console.WriteLine("================");
            f.PrintMaxNew();
        }
    }
}
