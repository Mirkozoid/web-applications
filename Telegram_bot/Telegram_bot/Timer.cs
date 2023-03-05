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
            timer.Start();
            timer.Interval = 1000;
            timer.Elapsed += ChekingTime;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public static void ChekingTime(object source, ElapsedEventArgs e)
        {
            TimeNow = DateTime.Now;
            if (TimeNow.Hour == TimeToAlarm.Hour && TimeNow.Minute == TimeToAlarm.Minute && TimeNow.Second == TimeToAlarm.Second)
            {
                HTMLparsing.HTMLpars();
                SendingMessage.NewsEveryDay();
                
            }
        }
    }
}
