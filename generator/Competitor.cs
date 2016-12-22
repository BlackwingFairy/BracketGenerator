namespace generator
{
    public class Competitor
    {
        public string tournir;
        public int ratingNum;
        public string name;
        public bool exist;

        public Competitor(int ratingNum, string name, bool exist,string tournir)
        {
            this.ratingNum = ratingNum;
            this.name = name;
            this.exist = exist;
            this.tournir = tournir;
        }

        override
        public string ToString()
        {
            return "Rating number: " + ratingNum + "\nName: " +
                name + "\nIs it a real competitor: " + exist;
        }
    }
}
