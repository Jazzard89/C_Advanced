using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using KindomSimClassLibrary.Entities;

namespace KindomSimClassLibrary.DataAcces
{
    public static class ScoreData
    {
        private static string SCORE_BESTANDS_NAAM = "gechiedenis.xml";
        private static string SCORE_TABEL_NAAM = "geschiedenis";
        private static DataSet scoreDataSet = new DataSet();



        public static DataTable ScoreDataTable 
        {
            get
            {
                DataTable tableX;
                if (scoreDataSet == null)
                {
                    tableX = new DataTable(SCORE_TABEL_NAAM);
                    try
                    {
                        FileStream fsr = new FileStream($"{SCORE_BESTANDS_NAAM}", FileMode.Open, FileAccess.Read);

                        //vul databases
                        using (StreamReader sr = new StreamReader($"{SCORE_BESTANDS_NAAM}"))
                        {
                            while (!sr.EndOfStream)
                            {
                                string[] waarden = sr.ReadLine().Split(',');

                                if (waarden[0] != "")
                                {
                                    tableX.Rows.Add(waarden[0], waarden[1], waarden[2]);
                                }

                            }
                        }
                        

                        
                    }
                    catch
                    {
                        DataColumn id = new DataColumn("id ", typeof(int)); //PK
                        DataColumn NaamDc = new DataColumn("naam", typeof(string));
                        DataColumn AantalDagenDc = new DataColumn("aantal_dagen", typeof(int));

                        //add de koloms
                        tableX.Columns.Add(id);
                        tableX.Columns.Add(NaamDc);
                        tableX.Columns.Add(AantalDagenDc);


                        //PrimaryKey
                        tableX.PrimaryKey = new DataColumn[] { tableX.Columns["id"] };


                        //Dataset in Database zetten
                        scoreDataSet.Tables.Add(tableX);



                        // vul databases
                        using (StreamReader sr = new StreamReader($"{SCORE_BESTANDS_NAAM}"))
                        {
                            while (!sr.EndOfStream)
                            {
                                string[] waarden = sr.ReadLine().Split(',');

                                if (waarden[0] != "")
                                {
                                    tableX.Rows.Add(waarden[0], waarden[1], waarden[2]);
                                }

                            }
                        }
                    }


                }
                else
                {
                    tableX = new DataTable();
                }
                return tableX;

            }
        }

        public static void AddScore(Speler speler, int aantalDagen)
        {
            ScoreDataTable.Rows.Add($"{SCORE_TABEL_NAAM}");
            using (StreamWriter sw = new StreamWriter($"{SCORE_BESTANDS_NAAM}"))
            {
                sw.WriteLine($"{GetNextId()};{speler};{aantalDagen}");
            }
        }
        private static int GetNextId()
        {
            int highestId = 0;
            for (int i = 0; i < scoreDataSet.Tables.Count; i++)
            {
                if (Convert.ToInt32(scoreDataSet.Tables[0].Rows[i][0]) < highestId)
                {
                    scoreDataSet.Tables[0].Rows[i][0] = Convert.ToInt32(scoreDataSet.Tables[0].Rows[i][0]) + 1;
                }
            }
            return highestId;

        }


    }
}
