using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm40.Application.Utils
{
    internal class IteratorFormating:IIteratorFormating
    {
        public string ExportIteratorToString<T>(IEnumerable<T> values)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool first=true;
            foreach(var item in values)
            {
                if(!first )
                    stringBuilder.Append(",");
                stringBuilder.Append(item.ToString());
                first = false;
            }
            return stringBuilder.ToString();
        }
    }
}
