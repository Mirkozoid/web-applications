using System;
using System.Timers;

namespace Telegram_Bot
{
    class Timer
    {
        public static DateTime TimeToAlarm = DateTime.Now.Date.AddHours(21).AddMinutes(42);
        public static DateTime TimeNow;
        public static System.Timers.Timer timer = new System.Timers.Timer();
        public static void TimerNews()
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
                SendMessage.NewsEveryDay();
                return;
            }
        }
    }
}
