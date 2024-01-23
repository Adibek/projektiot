using System.Text.Json.Serialization;


namespace TaskManager.Database.Entities
{

    public enum TaskStatus
    {
        Zlecone,
        Przyjęte,
        Wykonane,
        Anulowane,
    }
    public class TaskEntity
    {   
        public int Id {get;set;}
        public string AdminName {get;set;}
        public string Name {get;set;}
        public DateTime Date {get;set;} = DateTime.Now;
        // [JsonConverter(typeof(JsonStringEnumConverter))]
        public string Status {get;set;}
        public DateTime? ModifiedStatus {get;set;}
    }
}