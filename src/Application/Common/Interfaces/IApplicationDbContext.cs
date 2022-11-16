using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Question> Questions { get; }

    DbSet<Option> Options { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
