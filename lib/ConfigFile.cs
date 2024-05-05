using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Microsoft.VisualBasic.Logging;
using System.Reflection;

namespace GoalBar
{
    public class ConfigFile
    {
        Config config = null;
        Log log = null;

        public ConfigFile(Config config, Log log) { 
            this.config = config;
            this.log = log;
            this.SetupConfigDirectory();
        }

        public bool IsInProgramFilesDirectory() {
            string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            bool isInProgramFiles = appDirectory.StartsWith(programFiles, StringComparison.OrdinalIgnoreCase) ||
                                    appDirectory.StartsWith(programFilesX86, StringComparison.OrdinalIgnoreCase);

            return isInProgramFiles;
        }

        public void SetupConfigDirectory()
        {
            string confidDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
 
            string appRoamingDirectory = Path.Combine(confidDirectory, this.config.appName);

            if (!Directory.Exists(appRoamingDirectory))
            {
                Directory.CreateDirectory(appRoamingDirectory);
            }

            this.config.appRoamingDirectory = appRoamingDirectory;

            this.config.configPath = Path.Combine(
                this.config.appRoamingDirectory,
                this.config.configFileName
            );

        }

        public void Load() {

            if (!File.Exists(this.config.configPath)) {
                return;
            }

            XmlReaderSettings xws = new XmlReaderSettings
            {
                CheckCharacters = false
            };

            // load config file
            string xml = File.ReadAllText(this.config.configPath);

            try
            {
                using (XmlReader xr = XmlReader.Create(new StringReader(xml), xws))
                {

                    XElement root = XElement.Load(xr);
                    foreach (XElement element in root.Elements())
                    {
                        if (element.HasElements)
                        {

                            if (element.Name.ToString() == "window") 
                            {
                                foreach (XElement el in element.Descendants())
                                {
                                    try
                                    {

                                        if (el.Name.ToString() == "left")
                                        {
                                            this.config.left = Int32.Parse(el.Value);
                                        }

                                        if (el.Name.ToString() == "top")
                                        {
                                            this.config.top = Int32.Parse(el.Value);
                                        }

                                        if (el.Name.ToString() == "width")
                                        {
                                            this.config.width = Int32.Parse(el.Value);
                                        }

                                        if (el.Name.ToString() == "height")
                                        {
                                            this.config.height = Int32.Parse(el.Value);
                                        }

                                        if (el.Name.ToString() == "topmost")
                                        {
                                            this.config.topmost = (el.Value == "1");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        this.log.write(ex.Message);
                                    }
                                }
                            }

                            if (element.Name.ToString() == "goals")
                            {

                                this.config.goals.Clear();

                                foreach (XElement el in element.Descendants())
                                {

                                    if (el.Name.ToString() == "goal")
                                    {
                                        Goal goal = new Goal();

                                        foreach (XElement elGoal in el.Descendants())
                                        {
                                            try
                                            {

                                                if (elGoal.Name.ToString() == "name")
                                                {
                                                    goal.name = elGoal.Value;
                                                }

                                                if (elGoal.Name.ToString() == "min")
                                                {
                                                    goal.min = Int32.Parse(elGoal.Value);
                                                }

                                                if (elGoal.Name.ToString() == "max")
                                                {
                                                    goal.max = Int32.Parse(elGoal.Value);
                                                }

                                                if (elGoal.Name.ToString() == "value")
                                                {
                                                    goal.value = Int32.Parse(elGoal.Value);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                this.log.write(ex.Message);
                                            }
                                        }

                                        this.config.goals.Add(goal);
                                    }
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.log.write(ex.Message);
            }
        }


        public void Save()
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings xws = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                CheckCharacters = false,
                Indent = true
            };


            XElement root = new XElement("config");

            XElement itemsWindow = new XElement("window");
            itemsWindow.Add(new XElement("left", this.config.left.ToString()));
            itemsWindow.Add(new XElement("top", this.config.top.ToString()));
            itemsWindow.Add(new XElement("width", this.config.width.ToString()));
            itemsWindow.Add(new XElement("height", this.config.height.ToString()));
            itemsWindow.Add(new XElement("topmost", this.config.topmost ? "1" : "0"));
            root.Add(itemsWindow);

            XElement itemsGoals = new XElement("goals");

            foreach (Goal goal in this.config.goals)
            {
                XElement itemGoal = new XElement("goal");

                itemGoal.Add(new XElement("name", goal.name));
                itemGoal.Add(new XElement("min", goal.min.ToString()));
                itemGoal.Add(new XElement("max", goal.max.ToString()));
                itemGoal.Add(new XElement("value", goal.value.ToString()));

                itemsGoals.Add(itemGoal);
            }
           
            root.Add(itemsGoals);

            try
            {

                using (XmlWriter xw = XmlWriter.Create(sb, xws))
                {
                    root.WriteTo(xw);
                }

            }
            catch (Exception ex)
            {
               this.log.write(ex.Message);
            }


            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(this.config.configPath);
                file.Write(sb.ToString());
                file.Close();

            }
            catch (System.IO.IOException ex)
            {
                this.log.write(ex.Message);
            }
            catch (Exception ex)
            {
                this.log.write(ex.Message);
            }

        }

    }
}
