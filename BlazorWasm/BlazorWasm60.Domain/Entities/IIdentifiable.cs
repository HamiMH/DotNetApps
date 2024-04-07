using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm60.Domain.Entities
{
    public interface IIdentifiable
    {
        int Id { get; }
    }
}
