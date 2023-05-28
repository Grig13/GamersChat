using GamersChatAPI.Models;

namespace GamersChat.Repositories.Interfaces
{
    public interface INewsRepository
    {
        public IEnumerable<News> GetAll();
        public News Add(News newsToAdd);
        public void DeleteById(Guid id);
        public News Update(News newsToUpdate);
        public News GetById(Guid id);
    }
}
