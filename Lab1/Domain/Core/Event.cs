using Lab1.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Core
{
    class Event : IIdenifiable
    {
        public string Id { get; }
        public string Name { get; }
        public string Status { get; set; }
        public DateTime DT { get; }
        public Event (string id, string name, string status, DateTime dT)
        {
            Id = id;
            Name = name;
            Status = status;
            DT = dT;
        }
    }
}
