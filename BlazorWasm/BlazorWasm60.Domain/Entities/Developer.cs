using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm60.Domain.Entities
{
    public class Developer : IIdentifiable
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public int BirthYear { get; set; }

        public List<VideoGame> VideoGames { get; } = new();
    }
}
