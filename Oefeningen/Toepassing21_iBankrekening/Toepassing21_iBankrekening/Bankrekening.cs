using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Toepassing21_iBankrekening
{
    internal class Bankrekening : IBankrekening
    {
        private string naam;
        private int rekennummer;
        private double saldo;

        ///////////////////////////////////////

        public string Naam { get; set; }
        public int Rekeningnummer { get; set; }
        public double Saldo { get; set; }

        public Bankrekening(string Naam, int Rekeningnummer, double Saldo)
        {
            this.Naam = Naam;
            this.Saldo = Saldo;
            this.Rekeningnummer = Rekeningnummer;


        }

        public void Opname(double withdrawal)
        {
            if (-withdrawal > Saldo)
            {
                MessageBox.Show("Onvoldoende geld op rekening");


            }
            else
            {
                Saldo += withdrawal;

            }



        }

        public void Storting(double deposit)
        {
            Saldo += deposit;


        }
    }
}
