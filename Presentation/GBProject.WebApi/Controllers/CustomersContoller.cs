using GBProject.Application.Features.CQRS.Commands.CustomerCommands;
using GBProject.Application.Features.CQRS.Handlers.CustomerHandlers;
using GBProject.Application.Features.CQRS.Queries.CustomerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GBProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersContoller : ControllerBase
    {
        private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;
        private readonly GetCustomerQueryHandler _getCustomerQueryHandler;
        private readonly RemoveCustomerCommandHandler _removeCustomerCommandHandler;
        private readonly UpdateCustomerCommandHandler _updateCustomerComandHandler;
        private readonly GetCustomerByIdQueryHandler _getCustomerByIdQueryHandler;
        private readonly GetCustomerWithAddressQueryHandler _getCustomerWithAddressQueryHandler;

        public CustomersContoller(CreateCustomerCommandHandler createCustomerCommandHandler, GetCustomerQueryHandler getCustomerQueryHandler, RemoveCustomerCommandHandler removeCustomerCommandHandler, UpdateCustomerCommandHandler updateCustomerComandHandler, GetCustomerByIdQueryHandler getCustomerByIdQueryHandler,
            GetCustomerWithAddressQueryHandler getCustomerWithAddressQueryHandler)
        {
            _createCustomerCommandHandler = createCustomerCommandHandler;
            _getCustomerQueryHandler = getCustomerQueryHandler;
            _removeCustomerCommandHandler = removeCustomerCommandHandler;
            _updateCustomerComandHandler = updateCustomerComandHandler;
            _getCustomerByIdQueryHandler = getCustomerByIdQueryHandler;
            _getCustomerWithAddressQueryHandler = getCustomerWithAddressQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var values = await _getCustomerQueryHandler.Handle();
            return Ok(values);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var value = await _getCustomerByIdQueryHandler.Handle(new GetCustomerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            await _createCustomerCommandHandler.Handle(command);
            return Ok("Müşteri bilgisi eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCustomer(int id)
        {
            await _removeCustomerCommandHandler.Handle(new RemoveCustomerCommand(id));
            return Ok("Müşteri bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand command)
        {
            await _updateCustomerComandHandler.Handle(command);
            return Ok("Müşteri bilgisi güncellendi");
        }

        [HttpGet("GetCustomerWithAddress")]
        public IActionResult GetCustomerWithAddress()
        {
            var values = _getCustomerWithAddressQueryHandler.Handle();
            return Ok(values);
        }
    }
}
