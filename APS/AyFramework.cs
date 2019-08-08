using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApplication4.APS
{
    public class AyFramework
    {
        public bool timeoutID = false;
        public static bool isContinue = false;
        public static Canvas canvas;
        public static DispatcherTimer timer = new DispatcherTimer();
        public static void Start(Action func)
        {
            isContinue = true;
            timer = AyTime.setInterval(10, func);
        }


        public static void clearCanvas()
        {
            canvas.Children.Clear();
        }
        public static void stop()
        {
            timer.Stop();
            isContinue = false;
        }

        public static void ClearCanvasTimer()
        {

        }

        //function stop()
        //{
        //    clearTimeout(timeoutID);
        //    isContinue = false;
        //}

    }
}
