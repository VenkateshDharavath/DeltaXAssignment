using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Actors.Command
{
    public class DeleteActorCommand : IRequest<int>
    {
        public string Id { get; set; }
    }

    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand, int>
    {
        private readonly IAppDbContext _context;

        public DeleteActorCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _context.Actors.FindAsync(request.Id);
            if (actor == null)
                return 0;

            _context.Actors.Remove(actor);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
