using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJET.CodeSamurai.Models
{
    public class TaskData
    {
        public string Title { get; set; }
        public int EstimatedHours { get; set; }
        public string DependsOn { get; set; }
        public string ResourceType { get; set; }
    }
}
