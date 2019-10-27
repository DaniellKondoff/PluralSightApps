using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows;
using CSharpFunctionalExtensions;
using Logic.Movies;
using UI.Common;

namespace UI.Movies
{
    public class MovieListViewModel : ViewModel
    {
        private readonly MovieRepository _repository;

        public Command SearchCommand { get; }
        public Command<long> BuyAdultTicketCommand { get; }
        public Command<long> BuyChildTicketCommand { get; }
        public Command<long> BuyCDCommand { get; }
        public IReadOnlyList<Movie> Movies { get; private set; }

        public bool ForKidsOnly { get; set; }
        public double MinimumRating { get; set; }
        public bool OnCD { get; set; }

        public MovieListViewModel()
        {
            _repository = new MovieRepository();

            SearchCommand = new Command(Search);
            BuyAdultTicketCommand = new Command<long>(BuyAdultTicket);
            BuyChildTicketCommand = new Command<long>(BuyChildTicket);
            BuyCDCommand = new Command<long>(BuyCD);
        }

        private void BuyCD(long movieId)
        {
            Maybe<Movie> movieOrNothing = _repository.GetOne(movieId);
            if (movieOrNothing.HasNoValue)
                return;

            Movie movie = movieOrNothing.Value;
            //var specification = new GenericSpesification<Movie>(m => m.ReleaseDate <= DateTime.Now.AddMonths(-6));
            var specification = new AvailableOnCDSpecification();
            if (!specification.IsSatisfiedBy(movie))
            {
                MessageBox.Show("The movie doesn't have a CD version", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("You've bought a ticket", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BuyChildTicket(long movieId)
        {
            Maybe<Movie> movieOrNothing = _repository.GetOne(movieId);
            if (movieOrNothing.HasNoValue)
                return;

            Movie movie = movieOrNothing.Value;
            //var specifiation = new GenericSpesification<Movie>(m => m.MpaaRating <= MpaaRating.PG);
            var specifiation = new MovieForKidsSpecification();
            if (!specifiation.IsSatisfiedBy(movie))
            {
                MessageBox.Show("The movie is not suitable for children", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            MessageBox.Show("You've bought a ticket", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BuyAdultTicket(long movieId)
        {
            MessageBox.Show("You've bought a ticket", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Search()
        {
            //Expression<Func<Movie, bool>> expression = ForKidsOnly ? Movie.IsSuitableForChildren: x => true;
            //var specifiation = new GenericSpesification<Movie>(m => m.MpaaRating <= MpaaRating.PG);
            //var forKids = new MovieForKidsSpecification();
            //var onCD = new AvailableOnCDSpecification();
            //var specs = onCD.And(forKids.Not());

            var specs = Specification<Movie>.All;

            if (ForKidsOnly)
            {
                specs = specs.And(new MovieForKidsSpecification());
            }
            if (OnCD)
            {
                specs = specs.And(new AvailableOnCDSpecification());
            }

            Movies = _repository.GetList(specs, MinimumRating);
            Notify(nameof(Movies));
        }
    }
}
