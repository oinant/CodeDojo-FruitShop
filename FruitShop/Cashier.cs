using System;
using System.Collections.Generic;

namespace FruitShop
{
    public class Cashier
    {
        private int _total = 0;
        private int cherryPackCount = 0;
        private int bananasPackCount = 0;

        private int pommesPackCount = 0;
        private int melePackCount = 0;
        private int applessPackCount = 0;

        private int fruitsPackCount;

        public int Enter(string fruits)
        {
            foreach (var fruit in fruits.Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries))
            {
                EnterSingle(fruit);
            }
            return _total;
        }

        readonly List< string> applenames = new List<string>(){"Apples", "Pommes", "Mele"}; 

        private int EnterSingle(string fruit)
        {
            if (string.Equals(fruit, "Apples", StringComparison.OrdinalIgnoreCase))
            {
                fruitsPackCount++;
                _total += 100;
                applessPackCount++;
               
            }
            else if (string.Equals(fruit, "Mele", StringComparison.OrdinalIgnoreCase))
            {
                fruitsPackCount++;
                _total += 100;
                applessPackCount++;
                melePackCount++;
                if (melePackCount == 2)
                {
                    _total -= 100;
                    melePackCount = 0;
                }
            }
            else if (string.Equals(fruit, "Pommes", StringComparison.OrdinalIgnoreCase))
            {
                fruitsPackCount++;
                _total += 100;
                applessPackCount++;
                pommesPackCount++;
                if (pommesPackCount == 3)
                {
                    _total -= 100;
                    pommesPackCount = 0;
                }
            }
            else if (string.Equals(fruit, "Cherries", StringComparison.OrdinalIgnoreCase))
            {
                fruitsPackCount++;
                _total += 75;
                cherryPackCount++;
                if (cherryPackCount == 2)
                {
                    _total -= 20;
                    cherryPackCount = 0;
                }
            }
            else if (string.Equals(fruit, "Bananas", StringComparison.OrdinalIgnoreCase))
            {
                fruitsPackCount++;
                _total += 150;

                bananasPackCount++;
                if (bananasPackCount == 2)
                {
                    _total -= 150;
                    bananasPackCount = 0;
                }
            }

            if (applessPackCount == 4)
            {
                _total -= 100;
                applessPackCount = 0;
            }

            if (fruitsPackCount == 5)
            {
                _total -= 200;
                fruitsPackCount = 0;
            }
               
            return _total;
        }

        
    }
}
