using System.Text.Json.Serialization;


namespace TaskManager.Database.Entities
{

    public class TaskEntity
    {   
        public int Id {get;set;}
        public string AdminName {get;set;}
        public string Name {get;set;}
        public string Task {get;set;}
        public string TaskDesc {get;set;}
        public DateTime Date {get;set;} = DateTime.Now;
        public string Status {get;set;}
        public DateTime? ModifiedStatus {get;set;}
    }
}