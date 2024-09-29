using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//dit moet er staan voor bestanden in te lezen
//de file moet ook in de debug bin zitten
using System.IO;

namespace TextInladen
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    StreamReader sr = new StreamReader("KommaBestand.txt");
        //    try 
        //    { 

        //    //indien we de map opvragen op een andere pad moeten we dit schrijven met een @
        //    //omdat we \ gebruiken
        //    //StreamReader sr = new StreamReader(@"..\..\KommaBestand.txt");
        //    //voor lokale bestanden kunnen we de @ weglaten als we de andere slash gebruiken
        //    //StreamReader sr = new StreamReader(../../KommaBestand.txt");

        //    //zolang het bestand niet op het einde is gaan we dit afspelen.
        //    string[] velden;


        //    while(!sr.EndOfStream)
        //    {
        //        //array is maar 2 velden hoog, deze gaat de hele tijd leeg gemaakt en word iedere keer geleegd
        //        velden = sr.ReadLine().Split();
        //        Console.WriteLine($"{velden[0]} woont in {velden[1]}");
        //         // {naam} woont in {stad}
        //    }
        //    //close is verplicht
        //    sr.Close();
        //    Console.ReadLine();
        //    }
        //    catch(Exception ex) 
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        sr.Close();
        //    }





        //static void Main(string[] args)
        //{

        //    try
        //    {
        //        using (StreamReader sr = new StreamReader("KommaBestand.txt")) //als we using gebruiken moeten we niet closen
        //        {

        //            string[] velden;


        //            StreamWriter sw = new StreamWriter("KommaBestand.txt", true);
        //            sw.WriteLine("Nieuwe Regel, TestHasselt");
        //            sw.Close();


        //            while (!sr.EndOfStream)
        //            {
        //                //array is maar 2 velden hoog, deze gaat de hele tijd leeg gemaakt en word iedere keer geleegd
        //                velden = sr.ReadLine().Split();
        //                Console.WriteLine($"{velden[0]} woont in {velden[1]}");
        //            }
        //            Console.ReadLine();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //}

        static void Main(string[] args)
        {

            try
            {
                StreamReader sr2 = new StreamReader("VastBestand.txt");
                while (!sr2.EndOfStream)
                {
                    //string naam = sr2.ReadLine().Substring(0, 20);
                    //string voornaam = sr2.ReadLine().Substring(21, 10);
                    //string stad = sr2.ReadLine().Substring(31, 10);

                    string lijn = sr2.ReadLine();
                    string voornaam = lijn.Substring(0, 20).Trim();
                    string naam = lijn.Substring(20, 10).Trim() ;
                    string stad = lijn.Substring(30, 25).Trim() ;

                    Console.WriteLine($"{naam} {voornaam} woont in {stad}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }
    }
}
