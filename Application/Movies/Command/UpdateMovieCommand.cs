using Application.Common.Interfaces;
using Application.Common.Utilities;
using Application.Common.ViewModels;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Movies.Command
{
    public class UpdateMovieCommand : IRequest<Movie>
    {
        public string Id { get; set; }
        public MovieViewModel movie { get; set; }
    }

    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Movie>
    {
        private readonly IAppDbContext _context;

        public UpdateMovieCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Movie> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            // Check if movie and new producer exists, else return with error
            var movie = await _context.Movies.Include(ent => ent.Producer).FirstOrDefaultAsync(e => e.Id == request.Id); // .Include(ent => ent.Actors)
            var newProducer = await _context.Producers.FindAsync(request.movie.Producer);
            if (movie == null)
                throw new CustomException(404, "Movie does not exist");
            if (newProducer == null)
            {
                throw new CustomException(404, "New Producer does not exist");
            }

            // populate actors
            List<Actor> actors = new List<Actor>();
            foreach (var act in request.movie.Actors)
            {
                var actor = await _context.Actors.FindAsync(act);
                if (actor != null)
                    actors.Add(actor);
            }

            // Update existing movie with updated fileds
            if (actors.Count > 0)
                movie.Actors = actors;
            if (request.movie.DateofRelease != null)
                movie.DateofRelease = request.movie.DateofRelease;
            if (request.movie.Name != null)
                movie.Name = request.movie.Name.Trim();
            if (request.movie.Plot != null)
            movie.Plot = request.movie.Plot.Trim();
            if (request.movie.Poster != null && request.movie.Poster.Trim() != movie.Poster)
            {
                // Delete existing poster and update with new poster
                FileUtility.DeleteFile(movie.Poster);
                movie.Poster = request.movie.Poster.Trim();
            }
            if(movie.Producer.Id != request.movie.Producer)
                movie.Producer = newProducer;

            // update 
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync(cancellationToken);

            return movie;
        }
    }
}
