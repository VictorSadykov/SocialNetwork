using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Helpers
{
    public class BaseMessage
    {
        public static void Show(string message, ConsoleColor Color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }
    }
}
