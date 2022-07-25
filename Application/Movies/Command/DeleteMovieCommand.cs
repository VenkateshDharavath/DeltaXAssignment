using Application.Common.Interfaces;
using Application.Common.Utilities;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Movies.Command
{
    public class DeleteMovieCommand : IRequest<int>
    {
        public string Id { get; set; }
    }

    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, int>
    {
        private readonly IAppDbContext _context;

        public DeleteMovieCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(request.Id);
            if (movie == null)
                throw new CustomException(404, "Movie does not exist");

            // Delete Poster
            FileUtility.DeleteFile(movie.Poster);

            // Delete the movie itself
            _context.Movies.Remove(movie);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
