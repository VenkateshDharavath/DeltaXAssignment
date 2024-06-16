using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Movies.Query
{
    public class GetMovieQuery : IRequest<Movie>
    {
        public string Id { get; set; }
    }

    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, Movie>
    {
        private readonly IAppDbContext _context;

        public GetMovieQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Movie> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            return await _context.Movies.Include(e => e.Producer).Include(ent => ent.Actors).Where(ent => ent.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
