using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJET.CodeSamurai.Models
{
    public class TaskMapper
    {
        public string Key { get; set; }
        public TaskMap Value { get; set; }
        public Dictionary<int, List<int>> TaskMapperDictionary { get; set; }

    }

    public class TaskMap
    {
        public int key { get; set; }
        public int[] value { get; set; }
    }
}
