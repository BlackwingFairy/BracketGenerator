using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator
{
    public struct Duel
    {
        public Competitor comp1;
        public Competitor comp2;
        public int duelNum;

        public Duel(Competitor comp1,Competitor comp2,int duelNum)
        {
            this.comp1 = comp1;
            this.comp2 = comp2;
            this.duelNum = duelNum;
        }

        override
        public String ToString()
        {
            return "First competitor\n" + comp1.ToString() + "\nSecong competitor\n" +
                comp2.ToString() + "\n\nDuel number: " + duelNum;
        }
    }
}
