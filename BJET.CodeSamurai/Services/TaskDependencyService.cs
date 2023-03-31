using BJET.CodeSamurai.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJET.CodeSamurai.Services
{
    public class TaskDependencyService
    {
        private DataReaderService _context { get; set; }
        public TaskDependencyService()
        {
            _context = new DataReaderService();
        }

        public void TaskThread()
        {
            Data data = _context.GetData();
            var taskMapperList = data.TaskMapperList;
            var taskListData = data.TaskListData;

            foreach (KeyValuePair<int, int[]> map in taskMapperList)
            {
                var key = map.Key;
                var taskList = map.Value;
                string depends = @$"Project {key}";

                foreach (var task in taskList)
                {
                    var singleTask = taskListData.FirstOrDefault(x => x.Key == task);
                    string dependsOn = singleTask.Value.DependsOn;
                    string[] spDependsOn = dependsOn.Split(',');

                    if (!string.IsNullOrEmpty(dependsOn))
                    {
                        if (spDependsOn.Length > 0)
                        {
                            foreach (var taskId in spDependsOn)
                            {
                                depends += "<-" + task;
                            }
                        }
                    }
                    else
                    {
                        depends += "\n" + task;
                    }
                }
                Console.WriteLine(depends);
                depends = string.Empty;
            }
        }
    }
}
