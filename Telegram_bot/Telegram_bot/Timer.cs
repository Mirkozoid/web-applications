using PRS;
using SendingMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot;
using Varible;

namespace Timers
{
    class Timer : Variables
    {
        public static void SetTimer()
        {
            newsTimer = new System.Timers.Timer(60000);
            newsTimer.Elapsed += AlarmRandomNews;
            newsTimer.AutoReset = true;
            newsTimer.Enabled = true;
        }

        public static void AlarmRandomNews(object sender, ElapsedEventArgs e)
        {
            HTMLparsing.HTMLpars();
            SendingMessage.RandomNews();
        }
    }
}
