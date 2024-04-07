using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm60.Domain.Entities
{
    public class VideoGame : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; }
        public List<Developer> Developers { get; } = new ();

    }
}
