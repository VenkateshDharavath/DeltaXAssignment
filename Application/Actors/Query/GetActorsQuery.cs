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

namespace Application.Actors.Query
{
    public class GetActorsQuery : IRequest<PaginatedList<Actor>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetActorsQueryHandler : IRequestHandler<GetActorsQuery, PaginatedList<Actor>>
    {
        private readonly IAppDbContext _context;

        public GetActorsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Actor>> Handle(GetActorsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Actors.PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
