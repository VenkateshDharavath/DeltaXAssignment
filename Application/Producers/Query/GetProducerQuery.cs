using Application.Common.Interfaces;
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
 
    public class GetProducerQuery : IRequest<Producer>
    {
        public string Id { get; set; }
    }

    public class GetProducerQueryHandler : IRequestHandler<GetProducerQuery, Producer>
    {
        private readonly IAppDbContext _context;

        public GetProducerQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Producer> Handle(GetProducerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Producers.FindAsync(request.Id);
        }
    }
}
