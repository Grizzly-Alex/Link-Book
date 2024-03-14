using Link.Core.Entities;

namespace Link.Core.Interfaces;

public interface ILinkTagRepository
{
    Task<IEnumerable<LinkTag>> GetAllForUser(string userId);
    Task<LinkTag> Create(LinkTag tag);
    Task<LinkTag> GetById(Guid id);
    Task<bool> Update(LinkTag tag);
    Task<bool> Delete(Guid id);
}
