using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator
{
    public class DataWorker
    {
        static string databaseName = @"appdata.db";

        

        public static List<string> Get_Tournirs()
        {
            SQLiteConnection connect = new SQLiteConnection("Data Source="+databaseName);
            connect.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Tournirs';", connect);
            SQLiteDataReader reader = command.ExecuteReader();
            List<string> Tournirs = new List<string>();
            foreach (DbDataRecord record in reader)
            {
                string id = record["Id"].ToString();
                string tournir = record["Tournir"].ToString();
                Tournirs.Add(tournir);
            }
            connect.Close();
            return Tournirs;
        }


        public static void Add_Tournir(string Name)
        {
            
            SQLiteConnection connect = new SQLiteConnection("Data Source="+ databaseName);
            connect.Open();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO 'Tournirs' ('Tournir') VALUES ('"+ Name+"');", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        public static CompetitorsList Load_Competitors(string Tournir)
        {
            SQLiteConnection connect = new SQLiteConnection("Data Source=" + databaseName);
            connect.Open();
            //SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Competitors' WHERE 'Tournir'='"+Tournir+"';", connect);
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Competitors';", connect);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Competitor> CompList = new List<Competitor>();
            foreach (DbDataRecord record in reader)
            {
                string tournir = record["Tournir"].ToString();
                if (tournir == Tournir)
                {
                    string id = record["Id"].ToString();
                    int rnum = Convert.ToInt32(record["RatingNum"].ToString());
                    string name = record["Name"].ToString();
                    bool exist = Convert.ToBoolean(record["Exist"].ToString());

                    CompList.Add(new Competitor(rnum, name, exist, tournir));
                }
                
            }
            connect.Close();
            CompetitorsList RList = new CompetitorsList(CompList.Count);
            RList.List = CompList.ToArray();
            return RList;
        }


        public static void Add_Competitors(CompetitorsList List)
        {
            SQLiteConnection connect = new SQLiteConnection("Data Source="+databaseName);
            connect.Open();
            for (int i = 0;i<List.getSize();i++)
            {
                Competitor c = List.getCompetitor(i);
                SQLiteCommand command = new SQLiteCommand("INSERT INTO 'Competitors' ('RatingNum',"+
                    "'Name','Exist','Tournir') VALUES (" + (i+1) + ",'" + c.name +
                    "','"+c.exist+"','"+c.tournir+"');", connect);
                command.ExecuteNonQuery();
            }
            
            connect.Close();
        }
    }
}
