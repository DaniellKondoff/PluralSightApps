using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Movies
{
    public class MovieDto
    {
        public int Id { get; set; }
        public virtual string Name { get; }
        public virtual DateTime ReleaseDate { get; }
        public virtual string MpaaRating { get; }
        public virtual string Genre { get; }
        public virtual double Rating { get; }
        public virtual string Director { get; set; }
    }
}
