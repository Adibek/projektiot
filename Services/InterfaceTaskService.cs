using TaskManager.Database.Entities;

namespace TaskManager.Services
{
    public interface TaskService
    {
        IEnumerable<TaskEntity> GetTaskEntities();

        TaskEntity AddTask(TaskEntity taskEntity);

        void DeleteTask(int taskId);

        TaskEntity UpdateTaskStatus(int id, string status);

        IEnumerable<TaskEntity> FindTaskByStatus(string status);
    }

}