using AutoMapper;
using JWT.Api.ViewModels.Order;
using JWT.Application.Commands.Orders;
using JWT.Application.Queries.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;
        public OrderController(IMediator mediateR,IMapper mapper) 
        {
            _mediatR = mediateR;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<OrderViewModel>> GetAllOrders()
        {
            try
            {
                var result =  await _mediatR.Send(new GetOrdersQuery());
                var mappedResult = _mapper.Map<List<OrderViewModel>>(result);
                return mappedResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<long> CreateOrder([FromBody] OrderViewModel data)
        {
            try
            {
                var order = _mapper.Map<CreateOrderCommand>(data);
                var result = await _mediatR.Send(order);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
