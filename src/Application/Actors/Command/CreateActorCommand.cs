using Application.Common.Interfaces;
using Application.Common.ViewModels;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Actors.Command
{
    public class CreateActorCommand : IRequest<Actor>
    {
        public ActorViewModel actor { get; set; }
    }

    class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Actor>
    {
        private readonly IAppDbContext _context;

        public CreateActorCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Actor> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            // I Usually use AutoMapper Nuget Package, not using it here 
            var actor = request.actor;

            var newActor = new Actor();

            newActor.Id = Guid.NewGuid().ToString();
            newActor.Name = actor.Name.Trim();
            newActor.Bio = actor.Bio != null? actor.Bio.Trim() : null;
            newActor.Gender = actor.Gender.Trim();
            newActor.DateofBirth = actor.DateofBirth;

            _context.Actors.Add(newActor);

            await _context.SaveChangesAsync(cancellationToken);

            return newActor;
        }
    }
}
