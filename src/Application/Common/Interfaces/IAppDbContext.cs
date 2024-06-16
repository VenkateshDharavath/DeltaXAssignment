using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Movie> Movies { get; }
        DbSet<Actor> Actors { get; }
        DbSet<Producer> Producers { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
