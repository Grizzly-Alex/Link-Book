using Link.Core.Entities;
namespace Link.Core.Interfaces;


public interface IUserLinkRepository
{
    Task<IEnumerable<UserLink>> GetAllForUser(string userId);
    Task<IEnumerable<UserLink>> GetFavoritesForUser(string userId);
    Task<UserLink> Create(UserLink link);
    Task<UserLink> GetById(Guid id);
    Task<bool> Update(UserLink link);
    Task<bool> Delete(Guid id);
}