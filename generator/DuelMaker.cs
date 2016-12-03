using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator
{
    public class DuelMaker
    {
        public static DuelList createDuels(CompetitorsList compList, int dNum = 0)   //create new duel list
        {
            if(dNum>=0)
            {
                int compNum = compList.getSize();
                DuelList myList = new DuelList(compNum / 2);
                for (int first = 0, last = compNum-1; (first <= compNum / 2) && (last > compNum / 2); first++, last--)
                {
                    Duel newDuel = new Duel(compList.getCompetitor(first), compList.getCompetitor(last), dNum);
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

        public static DuelList duelDispose(DuelList dlist)
        {
            int counter = dlist.getSize();
            DuelList sort = new DuelList(counter);
            for (int i=0, first = 0, last = counter-1; (first <= counter / 2) && (last > counter / 2) && (i<counter-1); i+=2, first++, last--)
            {
                sort.setDuel(dlist.getDuel(first),i);
                sort.setDuel(dlist.getDuel(last), i + 1);
            }
            return sort;
        }
    }
}
