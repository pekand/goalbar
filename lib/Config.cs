using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalBar
{
    public class Config
    {

        public string logFile = "app.log";

#if DEBUG
        public bool isDebugMode = true;
        public string configFileName = "config.debug.xml";
#else
        public bool isDebugMode = false;
        public string configFileName = "config.xml";
#endif

        public string appName = "GoalApp";
        public string appRoamingDirectory = "";
        public string configPath = "";

        //window position       
        public int left = 100;
        public int top = 100;
        public int width = 300;
        public int height = 300;
        public bool topmost = false;

        //calendar       
        public int year = 2024;

        public List<Goal> goals = new List<Goal>();
    }
}
