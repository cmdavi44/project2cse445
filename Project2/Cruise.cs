using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project2
{
    public delegate void priceCutEvent(Int32 pr);
    internal class Cruise
    {
        static Random rng = new Random();
        public static event priceCutEvent priceCut;
        private static Int32 cruisePrice = 100;
        public Int32 getPrice()
        {
            return cruisePrice;
        }

        public static void changePrice(Int32 price)
        {
            if (price < cruisePrice)
            {
                if(priceCut != null)
                {
                    priceCut(price); 
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
                Console.WriteLine("New price is: {0}", p);

                Cruise.changePrice(p);
            }
        }
    }
}
