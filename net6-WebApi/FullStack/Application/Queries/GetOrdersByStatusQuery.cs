using FullStack.Application.Dtos;
using FullStack.Entities;
using MediatR;

namespace FullStack.Application.Queries
{
    public class GetOrdersByStatusQuery: IRequest<List<OrderByStatusDTO>>
    {
        public int Status { get; set; }

        public GetOrdersByStatusQuery(int status)
        {
            Status = status;
        }
    }
}
