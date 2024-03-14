namespace Link.Core.Interfaces;
using Link = Entities.Link;

public interface ILinkRepository
{
    Task<IEnumerable<Link>> GetAllForUser(string userId);
    Task<IEnumerable<Link>> GetFavoritesForUser(string userId);
    Task<Link> GetById(Guid id);
    Task<bool> Update(Link link);
    Task<bool> Delete(Guid id);
    Task<Link> Create(Link link);
}