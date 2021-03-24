﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MoodlePortal
{
    class RadSaBazom
    {
        public static MySqlConnection sqlcon;
        public static bool nadjiStudenta(int br_indeksa)
        {

            String query = String.Format("SELECT * FROM studenti WHERE br_indeksa='{0}'", br_indeksa);

            sqlcon = DbConnection.GetConnection();
            //sqlcon = con;
        //    try
        //    {
                sqlcon.Open();
                MySqlCommand cmd = new MySqlCommand(query, sqlcon);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    sqlcon.Close();
                    return false;
                }
                else
                {
                    sqlcon.Close();
                    return true; //ako ne vratimo ovde true onda nije dobro
                }
          //  }
        //    catch (Exception exc)
        //    {

        //    }
  

      //      return false;
        }

        public static bool Insert(int br_indeksa, string ime, string prezime, string email)
        {
            String query = String.Format("INSERT INTO studenti(br_indeksa, ime, prezime, email) values('{0}', '{1}','{2}', '{3}')", br_indeksa, ime, prezime, email);
            sqlcon = DbConnection.GetConnection();
            try
            {
                sqlcon.Open();
                MySqlCommand cmd = new MySqlCommand(query, sqlcon);

                MySqlDataReader reader = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();
                sqlcon.Close();
                return true;

            }
            catch (Exception exc)
            {
                
            }
            return false;
        }

        public static bool Obrisi(int br_indeksa)
        {
            String query = String.Format("DELETE FROM studenti WHERE br_indeksa='{0}'", br_indeksa);
            sqlcon = DbConnection.GetConnection();

            try
            {
                sqlcon.Open();
                MySqlCommand cmd = new MySqlCommand(query, sqlcon);

                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception exc)
            {

            }
            return false;

        }

        internal static Dictionary<int, String> SpisakStudenata()
        {
            String query = "SELECT * FROM studenti";
            Dictionary<int, String> studenti = new Dictionary<int, String>();

            sqlcon = DbConnection.GetConnection();
            //sqlcon = con;
        //    try
         //   {
        //        sqlcon.Open();
                MySqlCommand cmd = new MySqlCommand(query, sqlcon);

                MySqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                String podaciOStudentu = "Broj indeksa=" + rd[0].ToString() + ", " + rd[1] + " " + rd[2];
                studenti.Add(int.Parse(rd[0].ToString()), podaciOStudentu);
                //int i = 33;
                    // studenti.Add(int.Parse(rd[0].ToString()), "m");
            }

                sqlcon.Close();
                return studenti;
      //      }
      //      catch (Exception exc)
      //      {

       //     }

          // return studenti;
        }
    }
}
