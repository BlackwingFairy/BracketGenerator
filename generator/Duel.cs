using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator
{
    struct Duel
    {
        public int compNum1;
        public int compNum2;
        public int duelNum;

        public Duel(int compNum1,int compNum2,int duelNum)
        {
            this.compNum1 = compNum1;
            this.compNum2 = compNum2;
            this.duelNum = duelNum;
        }

        override
        public String ToString()
        {
            return "First competitor number:" + compNum1 + "\nSecong competitor number: " +
                compNum2 + "\nDuel number: " + duelNum;
        }
    }
}
