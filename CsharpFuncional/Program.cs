using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpFuncional
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new DbLogger();
            //  logger.Log(new LogMessage());

            TimerHelper.Timer(logger.QuantoTempo, c => Console.WriteLine($"Tempo Gasto {c} ms"));

            Console.Read();
        }





    }
}
