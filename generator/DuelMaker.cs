using System;

namespace generator
{
    public class DuelMaker
    {
        public static DuelList createDuels(CompetitorsList compList, int dNum = 0)   //create new duel list
        {
            if (dNum >= 0)
            {
                int compNum = compList.getSize();
                DuelList myList = new DuelList(compNum / 2);
                for (int i = 0; i < myList.getSize(); i++)
                {
                    Duel newDuel = new Duel(compList.getCompetitor(i), compList.getCompetitor(compNum - (i + 1)), dNum);
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
            for (int i = 0; i < counter - 1; i += 2)
            {
                sort.setDuel(dlist.getDuel(i), i);
                sort.setDuel(dlist.getDuel(counter - (i + 1)), i + 1);
            }
            return sort;
        }
    }
}
