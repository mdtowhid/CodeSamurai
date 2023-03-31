using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJET.CodeSamurai.Services
{
    public class EstimatedHourService
    {
        private DataReaderService _context { get; set; }
        public EstimatedHourService()
        {
            _context = new DataReaderService();
        }

        public void EstimatedHourCalculation()
        {
            Data data = _context.GetData();
            var taskMapperList = data.TaskMapperList;
            var taskListData = data.TaskListData;

            foreach (KeyValuePair<int, int[]> map in taskMapperList)
            {
                var key = map.Key;
                var taskList = map.Value;
                string depends = @$"Project {key}";
                int dependentHours = 0;
                int inDependentHours = 0;

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
                            dependentHours += singleTask.Value.EstimatedHours;
                        }
                    }
                    else
                    {
                        Console.WriteLine(@$"Independent task ID: {task}");
                        Console.WriteLine(@$"Estimated hours: {singleTask.Value.EstimatedHours}");
                    }
                }
                Console.WriteLine(@$"Dependancy graph: {depends}");
                Console.WriteLine(@$"Total estimated hours: {dependentHours}");
                depends = string.Empty;
            }
        }
    }
}
