using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Helpers
{
    public class InfoMessage
    {
        public static void Show(string message)
        {
            BaseMessage.Show(message, ConsoleColor.Blue);
        }
    }
}
