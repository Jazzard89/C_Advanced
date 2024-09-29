using KindomSimClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KindomSimClassLibrary.DataAcces
{
    public static class EventData
    {
        private static List<Event> events = new List<Event>()
        {
            
        };
        

        public static Random random = new Random();

        public static Event GetRandomEvent()
        {
            return events[random.Next(1, events.Count)];
        }

        public static void LaadEventsVanBestand(string padNaarBestand)
        {
            events = new List<Event> { GetRandomEvent() };


            using (StreamReader sr = new StreamReader(padNaarBestand))
            {
                BeslissingEvent beslissingEvent;
                ProefEvent proefEvent;
                while (!sr.EndOfStream)
                {
                    string[] waarden = sr.ReadLine().Split('-');
                    
                    if (waarden[0] != "")
                    {
                        if (waarden[0] == "Trial ")
                        {
                            beslissingEvent = new BeslissingEvent(waarden[0].ToString() + waarden[1].ToString());
                        }
                        else
                        {
                            proefEvent = new ProefEvent(waarden[0].ToString() + waarden[1].ToString());
                        }
                    }
                }
                
            }
        }
    }
}
