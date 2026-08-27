using Microsoft.EntityFrameworkCore;
using MotoFlow.Application.Activities.Interfaces;
using MotoFlow.Domain.Entities;
using MotoFlow.Infrastructure.Data;

namespace MotoFlow.Infrastructure.Persistence.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly AppDbContext _context;

    public ActivityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Activity activity, CancellationToken cancellationToken)
    {
        await _context.Activities.AddAsync(activity, cancellationToken);
    }

    public async Task<List<Activity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Activities
            .Include(x => x.ActivityMembers)
            .ThenInclude(x => x.Member)
            .ToListAsync(cancellationToken);
    }

    public async Task<Activity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Activities
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<Activity?> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Activities
            .Include(x => x.ActivityMembers)
                .ThenInclude(x => x.Member)
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public void Update(Activity activity)
    {
        _context.Activities.Update(activity);
    }

    public void Delete(Activity activity)
    {
        _context.Activities.Remove(activity);
    }
}