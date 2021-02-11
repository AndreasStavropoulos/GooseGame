﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheGooseGame
{
    public class Dice
    {
        public Random random = new Random();

        public List<int> Throw(int dice = 2)
        {
            List<int> throws = new List<int>();
            for (int i = 0; i <dice; i++)
            {
                throws.Add(random.Next(1, 7));
            }
            return throws;
        }
    }
}
