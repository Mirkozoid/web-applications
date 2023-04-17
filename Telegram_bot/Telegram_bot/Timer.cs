using System;
using System.Timers;
using Telegrambot;

namespace TelegramBot
{
    class Timer
    {
        public static DateTime TimeToAlarm = DateTime.Now.Date.AddHours(16).AddMinutes(00);
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
        public static void TimerNewsUpdate()
        {
            timer.Start();
            timer.Interval = 600000;
            timer.Elapsed += CallNewsUpdates;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        public static void CallNewsUpdates(object source, ElapsedEventArgs e)
        {
            NewsAPI.SearchNews();
        }
        public static void ChekingTime(object source, ElapsedEventArgs e)
        {
            TimeNow = DateTime.Now;
            if (TimeNow.Hour == TimeToAlarm.Hour && TimeNow.Minute == TimeToAlarm.Minute && TimeNow.Second == TimeToAlarm.Second)
            {
                SendMessage.NewsEveryDay();
            }
        }
    }
}
