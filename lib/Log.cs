using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalBar
{
    public class Log
    {
        public Config config = null;

        public Log(Config config) { 
            this.config = config;
        }

        public void write(string message)
        {
#if DEBUG
            File.AppendAllText(this.config.logFile, message + "\n");
            Console.WriteLine(message);
#endif
        }

    }
}
