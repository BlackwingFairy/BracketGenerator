using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator
{
    public struct Competitor
    {
        public int ratingNum;
        public string name;
        public bool exist;

        public Competitor(int ratingNum, string name, bool exist)
        {
            this.ratingNum = ratingNum;
            this.name = name;
            this.exist = exist;
        }

        override
        public string ToString()
        {
            return "Rating number: " + ratingNum + "\nName: " +
                name + "\nIs it a real competitor: " + exist;
        }
    }
}
