using System;

namespace generator
{
    public class DuelList
    {
        private Duel[] list;
        public Duel[]List
        {
            set { list = value; }
            get { return list; }
        }

        public DuelList(int duelNum)
        {
            if (duelNum >= 0)
            {
                list = new Duel[duelNum];
            }
            else
            {
                throw new ArgumentException("Parameter cannot be smaller then zero", "duelNum");
            }
        }

        public Duel getDuel(int index)
        {
            try
            {
                return list[index];
            }
            catch (IndexOutOfRangeException ex)
            {
                ArgumentException argEx = new ArgumentException("Index is out of range", "index", ex);
                throw argEx;
            }
        }

        public void setDuel(Duel member, int index)
        {
            try
            {
                list[index] = member;
            }
            catch (IndexOutOfRangeException ex)
            {
                ArgumentException argEx = new ArgumentException("Index is out of range", "index", ex);
                throw argEx;
            }
        }

        public int getSize()
        {
            return list.Length;
        }
    }
}
