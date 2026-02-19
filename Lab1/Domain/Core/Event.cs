using Lab1.Domain.Core.Interfaces;

public class Event : IIdenifiable
{
<<<<<<< HEAD
    public string Id { get; }
    public string Name { get; }
    public string Status { get; set; } = "Planned";
    public DateTime DT { get; }
    public Event(string id, string name, DateTime dT)
    {
        Id = id;
        Name = name;
        DT = dT;
=======
    public class Event : IIdenifiable, IComparable
    {
        public string Id { get; }
        public string Name { get; }
        public string Status { get; set; } = "Planned";
        public DateTime DT { get; }
        public Event (string id, string name, DateTime dT)
        {
            Id = id;
            Name = name;
            DT = dT;
        }
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Status: {Status} Scheduled: {DT}\r\n";
        }
        
        public int CompareTo(object? obj)
        {
            if (obj is not Event other)
            {
                throw new ArgumentException("Object must be type of Event");
            }
            
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    }
    public override string ToString()
    {
        return $"Id: {Id} Name: {Name} Status: {Status} Scheduled: {DT}\r\n";
    }
}