using FullStack.Entities;

namespace FullStack.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> ObterPorStatusAsync(int[] status);
        Task AdicionarAsync(Order ordem);
        Task AtualizarAsync(Order ordem);
    }
}
