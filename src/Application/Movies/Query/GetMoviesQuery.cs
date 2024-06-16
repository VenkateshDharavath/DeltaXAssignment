using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Utilities;
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
    public class GetMoviesQuery : IRequest<PaginatedList<Movie>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, PaginatedList<Movie>>
    {
        private readonly IAppDbContext _context;

        public GetMoviesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Movie> query = _context.Movies.Include(e => e.Producer).Include(ent => ent.Actors);
            return await query.PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
