using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using TaskManager.Services;
using TaskManager.Database.Entities;

namespace TaskManager.Functions
{
    public class TaskFn
    {
        private readonly ILogger _logger;

        private readonly DatabaseTaskService databaseTaskService;

        public TaskFn(ILoggerFactory loggerFactory, DatabaseTaskService databaseTaskService)
        {
            _logger = loggerFactory.CreateLogger<TaskFn>();
            this.databaseTaskService = databaseTaskService;
        }

        [Function("TaskFn")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", "delete", "put")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
             switch  (req.Method){
                case "POST":
                    StreamReader reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var json = reader.ReadToEnd();
                    var task = JsonSerializer.Deserialize<TaskEntity>(json);
                    var res =  databaseTaskService.AddTask(task);
                    response.WriteAsJsonAsync(res);
                    break;
                case "PUT":
                    StreamReader putReader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var putJson = putReader.ReadToEnd();
                    var updatedTask = JsonSerializer.Deserialize<TaskEntity>(putJson);
                    var updateTaskStatus = databaseTaskService.UpdateTaskStatus(updatedTask.Id, updatedTask.Status);
                    response.WriteAsJsonAsync(updateTaskStatus);
                    break;
                case "GET":
                    var gettask = databaseTaskService.GetTaskEntities();
                    response.WriteAsJsonAsync(gettask);
                    break;
                case "DELETE":
                    StreamReader deleteReader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var deleteJson = deleteReader.ReadToEnd();
                    var taskToDelete = JsonSerializer.Deserialize<TaskEntity>(deleteJson);
                    databaseTaskService.DeleteTask(taskToDelete.Id);
                    response.WriteString("Task deleted successfully");
                    break;
            }
            return response;
        }
    }
}
