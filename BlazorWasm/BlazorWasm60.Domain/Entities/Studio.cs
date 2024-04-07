using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm60.Domain.Entities
{
    public class Studio:IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FoundYear { get; set; }

        public List<VideoGame> VideoGames { get; set; }= new (); 
    }
}
