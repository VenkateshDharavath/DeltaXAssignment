using Application.Common.Interfaces;
using Application.Common.ViewModels;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Producers.Command
{

    public class UpdateProducerCommand : IRequest<Producer>
    {
        public string Id { get; set; }
        public ProducerViewModel producer { get; set; }
    }

    public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand, Producer>
    {
        private readonly IAppDbContext _context;

        public UpdateProducerCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Producer> Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
        {
            var existingProd = await _context.Producers.FindAsync(request.Id);
            if (existingProd == null)
                throw new CustomException(404, "Producer does not exist");

            var prod = request.producer;
            if (prod.Name != null)
                existingProd.Name = prod.Name;
            if (prod.Bio != null)
                existingProd.Bio = prod.Bio;
            if (prod.Gender != null)
                existingProd.Gender = prod.Gender;
            if (prod.DateofBirth != null)
                existingProd.DateofBirth = prod.DateofBirth;
            if (prod.Company != null)
                existingProd.Company = prod.Company;

            _context.Producers.Update(existingProd);

            await _context.SaveChangesAsync(cancellationToken);

            return existingProd;
        }
    }
}
