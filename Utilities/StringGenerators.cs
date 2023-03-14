using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTest.Utilities
{
    internal class StringGenerators
    {
        public static string RandomStringGenerator()
        {
            Random random = new Random();
            int symbolsQuantity = random.Next(10, 22);
            string text = "";
            for (int i = 0; i < symbolsQuantity; i++)
            {
                text += (char)random.Next(33, 127);
            }
            return text;
        }
        public static string SubjectGenerator()
        {
            return $"Letter from {DateTime.Now}";
        }
    }
}
