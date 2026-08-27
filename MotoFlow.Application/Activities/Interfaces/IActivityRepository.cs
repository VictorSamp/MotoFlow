using MotoFlow.Domain.Entities;

namespace MotoFlow.Application.Activities.Interfaces;

public interface IActivityRepository
{
    Task AddAsync(Activity activity, CancellationToken cancellationToken);

    Task<List<Activity>> GetAllAsync(CancellationToken cancellationToken);

    Task<Activity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Activity?> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken);

    void Update(Activity activity);

    void Delete(Activity activity);
}