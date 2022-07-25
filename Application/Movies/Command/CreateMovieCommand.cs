using Application.Common.Interfaces;
using Application.Common.ViewModels;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Movies.Command
{
    public class CreateMovieCommand : IRequest<Movie>
    {
        public MovieViewModel movie { get; set; }
    }

    class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Movie>
    {
        private readonly IAppDbContext _context;

        public CreateMovieCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var producer = await _context.Producers.FindAsync(request.movie.Producer);
            if (producer == null)
                throw new CustomException(404, "Producer is not found");

            List<Actor> actors = new List<Actor>();
            foreach(var act in request.movie.Actors)
            {
                var actor = await _context.Actors.FindAsync(act);
                if (actor != null)
                    actors.Add(actor);
            }

            var movie = new Movie();
            movie.Id = Guid.NewGuid().ToString();
            movie.Actors = actors;
            movie.DateofRelease = request.movie.DateofRelease;
            movie.Name = request.movie.Name.Trim();
            movie.Plot = request.movie.Plot.Trim();
            movie.Poster = request.movie.Poster.Trim();
            movie.Producer = producer;

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync(cancellationToken);

            return movie;
        }
    }
}
