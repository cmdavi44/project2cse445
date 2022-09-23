using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project2
{
    public delegate void priceCutEvent(double price, double oldPrice);
    internal class Cruise
    {
        private Int32 counter = 0;
        static Random rng = new Random();
        public static event priceCutEvent priceCut;
        private static double cruisePrice = 100;
        public double getPrice()
        {
            return cruisePrice;
        }

        // Pricut cut 
        public static void changePrice(double price)
        {
            if (price < cruisePrice)
            {
                if(priceCut != null)
                {
                    priceCut(price, cruisePrice); 
                }
            }
            cruisePrice = price;
        }

        // This will have to be updated to take in different parameters to calculate the price.
        public void priceModel()
        {
            // Implement the seasons by having an array of 4 seasons, then randomly picking which season out of that array
            // Use same logic to implement the available tickets
            for (Int32 i = 0; i < 20; i++)
            {
                Thread.Sleep(500);
                Int32 p = rng.Next(40, 200);
                counter++;
                Console.WriteLine("New price is: {0} for price cut {1}", p, counter);

                Cruise.changePrice(p);
            }
        }
    }
}
