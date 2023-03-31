using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJET.CodeSamurai.Services
{
    public class NewResourseTypeService
    {
        private DataReaderService _context { get; set; }
        private string[] _types = new string[] { "BE", "FE", "DB", "MGR", "AI", "BC", "DOPS" };
        private List<string> _typeList = new List<string>();

        public NewResourseTypeService()
        {
            _context = new DataReaderService();
            _typeList= _types.ToList(); 
        }

        public void Check()
        {
            Data data = _context.Data;

            var resouceListData =  data.ResouceListData;

            foreach (var resourse in resouceListData)
            {
                var tempType = resourse.Value.Type;
                var isExist = _types.FirstOrDefault(x => x == tempType);
                if(!string.IsNullOrEmpty(isExist))
                {
                    bool isEx = _typeList.FindIndex(x => x == tempType) == -1;
                    if(isEx)
                        _typeList.Add(tempType);
                }
            }
            string res = "";
            foreach (var type in _typeList)
            {
                res += @$"{type} ";
            }

            Console.WriteLine(res);
        }

    }
}
