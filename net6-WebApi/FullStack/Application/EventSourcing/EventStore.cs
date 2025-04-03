using FullStack.Data;
using FullStack.Entities;
using FullStack.Interfaces;
using Newtonsoft.Json;

namespace FullStack.Application.EventSourcing
{
    public class EventStore : IEventStore
    {
        private readonly AppDbContext _dbContext;

        public EventStore(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Save<T>(T evento, int level) where T : class
        {
            var eventoArmazenado = new LogSystem
            {
                Id = Guid.NewGuid(),
                DateTimeCreated = DateTime.UtcNow,
                ImportanceLevel = level,
                EventMessage = $"Evento - {evento.GetType().Name}",
                Details = JsonConvert.SerializeObject(evento)
            };

            
            await _dbContext.LogSystem.AddAsync(eventoArmazenado);
            await _dbContext.SaveChangesAsync();
        }
    }
}
