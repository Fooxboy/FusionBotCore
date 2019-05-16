using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fooxboy.FusionBot.BotsLongPoll
{
    public static class BackgroundTasks
    {
        public static int Timer = 0;

        public static void StartUpdateTimerNewTsAndServer()
        {
            Log.Wr("Старт таймера для обновления Key, Server, Ts...");
            Task.Run(() =>UpdateTask());
        }

        public static void UpdateTask()
        {
            Thread.Sleep(60000);
            Timer += 1;
        }
    }
}
