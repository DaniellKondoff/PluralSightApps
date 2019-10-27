using Logic.Utils;
using System;

namespace Logic.Movies
{
    public class Movie : Entity
    {
        //public static readonly Expression<Func<Movie, bool>> IsSuitableForChildren = x => x.MpaaRating <= MpaaRating.PG;
        //public static readonly Expression<Func<Movie, bool>> HasCDVersion = x => x.ReleaseDate <= DateTime.Now.AddMonths(-6);
        public virtual string Name { get; }
        public virtual DateTime ReleaseDate { get; }
        public virtual MpaaRating MpaaRating { get; }
        public virtual string Genre { get; }
        public virtual double Rating { get; }
        public virtual Director Director { get; set; }

        protected Movie()
        {
        }
    }


    public enum MpaaRating
    {
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4
    }
}
