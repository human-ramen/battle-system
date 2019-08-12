using System;

namespace BattleSystem
{
    public class Logger
    {
        private string _from;

        public Logger(string from)
        {
            _from = from;
        }

        public void Debug(string log)
        {
            Console.WriteLine("DEBUG: {0} - {1}", _from, log);
        }

        public void Info(string log)
        {
            Console.WriteLine("INFO: {0} - {1}", _from, log);
        }

        public void Warn(string log)
        {
            Console.WriteLine("WARN: {0} - {1}", _from, log);
        }
    }
}
