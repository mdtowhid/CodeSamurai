using BJET.CodeSamurai.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BJET.CodeSamurai.Services
{
    public class DataReaderService
    {
        private string _baseUrl = "";
        public Data Data { get; set; } = new();
        string dir = "";

        public DataReaderService()
        {
            _baseUrl = Path.Combine(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath.Split(new string[] { "\\bin" }, StringSplitOptions.None)[0], $"Data\\");
            Data.TaskMapperList = ReadData("Task_Mapping_Data.json")["TaskMap"]!.ToObject<Dictionary<int, int[]>>()!;
            Data.TaskListData = ReadData("Task_List_Data.json")["taskList"]!.ToObject<Dictionary<int, TaskData>>()!;
            Data.ResouceListData = ReadData("Resource_List_Data.json")!.ToObject<Dictionary<int, ResouceListData>>()!;
            Data.ResourceMappingData = ReadData("Resource_Mapping_Data.json")!.ToObject<Dictionary<int, int[]>>()!;
            Data.ProjectListData = ReadData("Project_List_Data.json")!.ToObject<Dictionary<int, ProjectListData>>()!;
        }

        public Data GetData()
        {
            return Data;
        }

        public JObject ReadData(string fileName)
        {
            var json = File.ReadAllText(_baseUrl + fileName);
            return JObject.Parse(json);
        }
    }

    public class Data
    {
        public Dictionary<int, int[]> TaskMapperList { get; set; }
        public Dictionary<int, int[]> ResourceMappingData { get; set; }
        public Dictionary<int, TaskData> TaskListData { get; set; }
        public Dictionary<int, ResouceListData> ResouceListData { get; set; }
        public Dictionary<int, ProjectListData> ProjectListData { get; set; }
    }
}