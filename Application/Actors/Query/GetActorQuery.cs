using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Actors.Query
{
    public class GetActorQuery : IRequest<Actor>
    {
        public string Id { get; set; }
    }

    public class GetActorQueryHandler : IRequestHandler<GetActorQuery, Actor>
    {
        private readonly IAppDbContext _context;

        public GetActorQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Actor> Handle(GetActorQuery request, CancellationToken cancellationToken)
        {
            return await _context.Actors.FindAsync(request.Id);
        }
    }
}
