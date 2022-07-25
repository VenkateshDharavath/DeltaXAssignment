using Application.Common.Interfaces;
using Application.Common.ViewModels;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Producers.Command
{

    public class CreateProducerCommand : IRequest<Producer>
    {
        public ProducerViewModel producer { get; set; }
    }

    class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, Producer>
    {
        private readonly IAppDbContext _context;

        public CreateProducerCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Producer> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
        {
            // I Usually use AutoMapper Nuget Package, not using it here 
            var prod = request.producer;
            var producer = new Producer();
            producer.Id = Guid.NewGuid().ToString();
            producer.Name = prod.Name.Trim();
            producer.Bio = prod.Bio != null ? prod.Bio.Trim() : null;
            producer.Gender = prod.Gender.Trim();
            producer.Company = prod.Company.Trim();
            producer.DateofBirth = prod.DateofBirth;

            _context.Producers.Add(producer);

            await _context.SaveChangesAsync(cancellationToken);

            return producer;
        }
    }
}
