using System;
using System.Collections.Generic;
using Core.Models;

namespace Core.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents(DateTime? start, DateTime? end);
    }
}