using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Village_of_Testing_Jens_Kjellberg
{
    public class RandomClass
    {
        Random random = new Random();

        public virtual int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
