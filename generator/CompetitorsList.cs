using System;

namespace generator
{
    public class CompetitorsList
    {
        Competitor[] list;
        public Competitor[] List
        {
            set { list = value; }
            get { return list; }
        }

        public CompetitorsList(int compNum)
        {
            if (compNum>=0)
            {
                list = new Competitor[compNum];
            }
            else
            {
                throw new ArgumentException("Parameter cannot be smaller then zero", "compNum");
            }
        }

        public Competitor getCompetitor(int index)
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

        public void setCompetitor(Competitor member, int index)
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
