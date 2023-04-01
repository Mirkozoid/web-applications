using SendingMessages;
using System;
using System.Timers;

namespace Timers
{
    class Timer
    {
        public static DateTime TimeToAlarm = DateTime.Now.Date.AddHours(16).AddMinutes(37);
        public static DateTime TimeNow;
        public static System.Timers.Timer timer = new System.Timers.Timer();
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
                SendingMessage.NewsEveryDay();
                return;
            }
        }
    }
}
