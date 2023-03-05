using PRS;
using SendingMessages;
using System;
using System.Timers;
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
                return;
            }
        }
    }
}
