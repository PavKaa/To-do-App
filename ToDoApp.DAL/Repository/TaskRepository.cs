using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml.Linq;
using ToDoApp.DAL.Interface;
using ToDoApp.Domain.Entity;

namespace ToDoApp.DAL.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext contextDb;

        public TaskRepository(ApplicationDbContext contextDb) 
        {
            this.contextDb = contextDb;
        }

        public async Task<bool> Create(TaskEntity entity)
        {
            await contextDb.AddAsync(entity);
            await contextDb.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(TaskEntity entity)
        {
            contextDb.Tasks.Remove(entity);
            await contextDb.SaveChangesAsync();
            return true;
        }

        public async Task<TaskEntity> Get(int id)
        {
            return await contextDb.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskEntity> GetByName(string name)
        {
            return await contextDb.Tasks.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<TaskEntity>> Select()
        {
            return await contextDb.Tasks.ToListAsync();
        }

		public async Task<TaskEntity> Update(TaskEntity entity)
		{
			contextDb.Update(entity);
            await contextDb.SaveChangesAsync();
            return entity;
		}
	}
}
