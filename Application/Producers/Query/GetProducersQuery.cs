using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Utilities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Producers.Query
{

    public class GetProducersQuery : IRequest<PaginatedList<Producer>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetProducersQueryHandler : IRequestHandler<GetProducersQuery, PaginatedList<Producer>>
    {
        private readonly IAppDbContext _context;

        public GetProducersQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Producer>> Handle(GetProducersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Producers.PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
