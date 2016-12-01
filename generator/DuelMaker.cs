using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator
{
    class DuelMaker
    {
        public static DuelList createDuels(CompetitorsList compList, int dNum = 0)   //create new duel list
        {
            if(dNum>=0)
            {
                int compNum = compList.getSize();
                DuelList myList = new DuelList(compNum / 2);
                for (int first = 0, last = compNum; (first <= compNum / 2) && (last > compNum / 2); first++, last--)
                {
                    Duel newDuel = new Duel(first, last, dNum);
                    myList.setDuel(newDuel, dNum);
                    dNum++;
                }
                return myList;
            }
            else
            {
                throw new ArgumentException("Parameter cannot be smaller then zero", "dNum");
            }
        }
    }
}
