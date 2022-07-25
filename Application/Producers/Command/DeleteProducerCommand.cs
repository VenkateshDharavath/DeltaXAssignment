using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Producers.Command
{

    public class DeleteProducerCommand : IRequest<int>
    {
        public string Id { get; set; }
    }

    public class DeleteProducerCommandHandler : IRequestHandler<DeleteProducerCommand, int>
    {
        private readonly IAppDbContext _context;

        public DeleteProducerCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteProducerCommand request, CancellationToken cancellationToken)
        {
            var producer = await _context.Producers.FindAsync(request.Id);
            if (producer == null)
                return 0;

            _context.Producers.Remove(producer);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
