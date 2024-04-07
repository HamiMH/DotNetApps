using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm40.Application.Utils
{
    public interface IIteratorFormating
    {
        string ExportIteratorToString<T>(IEnumerable<T> values);
    }
}
