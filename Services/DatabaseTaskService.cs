using System.Data;
using TaskManager.Database;
using TaskManager.Database.Entities;

namespace TaskManager.Services
{
    public class DatabaseTaskService : TaskService
    {

        private readonly TaskDb db;
        public DatabaseTaskService(TaskDb db)
        {
            this.db = db;
        }

        public TaskEntity AddTask(TaskEntity taskEntity)
        {
            var entity = new TaskEntity
            {
                AdminName = taskEntity.AdminName,
                Name = taskEntity.Name,
                Status = taskEntity.Status,
            };
            db.Tasks.Add(entity);
            db.SaveChanges();
            taskEntity.Id = entity.Id;
            return taskEntity;
        }

        public void DeleteTask(int taskId)
        {
            var taskToDelete = db.Tasks.Find(taskId);

            if (taskToDelete != null)
            {
                db.Tasks.Remove(taskToDelete);
                db.SaveChanges();
            }
        }

        public IEnumerable<TaskEntity> GetTaskEntities()
        {
            var taskList = db.Tasks.Select(s => new TaskEntity
            {
                Id = s.Id,
                AdminName = s.AdminName,
                Name = s.Name,
                Date = s.Date,
                Status = s.Status,
                ModifiedStatus = s.ModifiedStatus
            });

            return taskList;
        }
        public TaskEntity UpdateTaskStatus(int taskId, string status)
        {
            var taskToUpdate = db.Tasks.Find(taskId);
            if (taskToUpdate != null || taskToUpdate.Status != status)
            {
                taskToUpdate.Status = status;
                taskToUpdate.ModifiedStatus = DateTime.Now;
                db.SaveChanges();
            }
            return taskToUpdate;
        }

        public IEnumerable<TaskEntity> FindTaskByStatus(string status)
        {
            return db.Tasks.Where(task => task.Status == status).ToList();
        }

    }

   
}