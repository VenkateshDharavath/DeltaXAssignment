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

namespace Application.Actors.Command
{
    public class UpdateActorCommand : IRequest<Actor>
    {
        public string Id { get; set; }
        public ActorViewModel actor { get; set; }
    }

    public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, Actor>
    {
        private readonly IAppDbContext _context;

        public UpdateActorCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Actor> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            var existingActor = await _context.Actors.FindAsync(request.Id);
            var actor = request.actor;
            if (actor.Name != null)
                existingActor.Name = actor.Name;
            if (actor.Bio != null)
                existingActor.Bio = actor.Bio;
            if (actor.Gender != null)
                existingActor.Gender = actor.Gender;
            if (actor.DateofBirth != null)
                existingActor.DateofBirth = actor.DateofBirth;

            _context.Actors.Update(existingActor);

            await _context.SaveChangesAsync(cancellationToken);

            return existingActor;
        }
    }
}
