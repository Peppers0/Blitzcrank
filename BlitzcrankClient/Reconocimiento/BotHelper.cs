using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlitzcrankClient.Reconocimiento
{
    class BotHelper
    {
        /*
         * In milliseconds
         */
        private const int IDLE_DELAY = 150;

        public static void Wait(int ms)
        {
            Thread.Sleep(ms);
        }
        public static void InputIdle()
        {
            Thread.Sleep(IDLE_DELAY);
        }
    }
}
