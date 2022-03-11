using System;
using System.Collections.Generic;
using System.Linq;

namespace PricingModel
    {
    class Program
        {

        /* The models are made using Dictionary Data structure, in which the key is the Upper limit , and the Value is the price variant for that range. 
        For two models, we've maintained  two dictionaries, each with the customer pricing tiers. 
        */

        public static Dictionary<int,double> Customer1()
            {
               return new Dictionary<int, double>()
                    {
                        { 100,1 },
                        { 1000,0.5 },
                        { 10000,0.25 },
                        { 100001,0.1 }
                   };   
            }

        public static Dictionary<int, double> Customer2()
            {
                return new Dictionary<int, double>()
                {
                    { 50,1 },
                    { 1000,0.5 },
                    { 100000,0.25 },
                    { 1000001,0.1 }
                };
            }

        /* We will check, if the storage is greater than te tier, upper limit, then, we will keep going and keep adding those tiers amount, util the bracket reached where no more further we have to look for. 

        For remaining, we will compute the price, with the tier we're at, and multiply it with remaining storage
        */

        public static int GetCustomerBill(long storage, Dictionary<int, double> model)
            {
                int bill,currentIndex;
                bill=currentIndex = 0;
                var currBracket = model.ElementAt(currentIndex);

                while (currentIndex < model.Count-1 && storage > currBracket.Key)
                {
                    bill = bill + Convert.ToInt32(currBracket.Value*currBracket.Key);
                    storage = storage - currBracket.Key;
                    currBracket = model.ElementAt(++currentIndex);
                }
            
                if (storage > 0)
                {
                    bill = bill + Convert.ToInt32(storage * (currBracket.Value));
                }

                return bill;
            }

        public static void CalculatePrice(long storage)
            {
                Console.WriteLine("Bill using customer 1 model is  : $ " + GetCustomerBill(storage, Customer1()) +
                "\nBill using customer 2 model is : $" + GetCustomerBill(storage, Customer2()));
            }
        static void Main(string[] args)
            {
            Console.WriteLine("Enter storage");
            long storage = Convert.ToInt64(Console.ReadLine());
            CalculatePrice(storage);

            /*
            OUTPUT : 
            Enter storage
            150
            Bill using customer 1 model is  : $ 125
            Bill using customer 2 model is : $100

            Time Complexity  : O(n) - Linear Time
            */

            }
        }
    }