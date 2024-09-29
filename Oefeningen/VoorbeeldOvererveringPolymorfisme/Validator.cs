using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VoorbeeldOvererveringPolymorfisme
{
    public static class Validator
    {

        public static string Title { get; set; }

        public static bool IsPresent(TextBox txtVak)
        {
            if (string.IsNullOrEmpty(txtVak.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidEmail(TextBox txtVak)
        {
            if ((!txtVak.Text.Contains("@")) || (!txtVak.Text.Contains(".")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}











//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Controls;

//namespace VoorbeeldOvererveringPolymorfisme
//{
//    public static class Validator
//    {

//        public static string Title { get; set; }

//        public static bool IsPresent(TextBox txtVak)
//        {
//            if (string.IsNullOrEmpty(txtVak.Text))
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }

//        public static bool IsValidEmail(TextBox txtVak)
//        {
//            if ((!txtVak.Text.Contains("@")) || (!txtVak.Text.Contains(".")))
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }
//    }
//}
