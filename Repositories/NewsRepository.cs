﻿using GamersChat.Data;
using GamersChat.Repositories.Interfaces;
using GamersChatAPI.Models;

namespace GamersChat.Repositories
{
    public class NewsRepository : INewsRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public NewsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public News GetById(Guid id)
        {
            var newsToReturn = _dbContext.Set<News>().Where(p => p.Id == id).FirstOrDefault();

            if (newsToReturn == null)
            {
                throw new KeyNotFoundException("News article not found.");
            }

            return newsToReturn;
        }

        public News Add(News newsToAdd)
        {
            _dbContext.News.Add(newsToAdd);
            _dbContext.SaveChanges();
            return newsToAdd;
        }

        public void DeleteById(Guid id)
        {
            var toDelete = GetById(id);
            _dbContext.Set<News>().Remove(toDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<News> GetAll()
        {
            return _dbContext.Set<News>().ToList();
        }

        public News Update(News newsToUpdate)
        {
            var existingNews = GetById(newsToUpdate.Id);
            if (existingNews == null)
            {
                throw new ArgumentException($"News with id: {newsToUpdate.Id} not found.");
            }
            existingNews.Content = newsToUpdate.Content;
            existingNews.Image = newsToUpdate.Image;
            existingNews.Attachment = newsToUpdate.Attachment;
            _dbContext.SaveChanges();
            return existingNews;
        }
    }
}
