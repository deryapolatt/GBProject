using GBProject.Application.Features.CQRS.Commands.AddressCommands;
using GBProject.Application.Features.CQRS.Handlers.AddressHandlers;
using GBProject.Application.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GBProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressComandHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly GetAddressWithCustomerQueryHandler _getAddressWithCustomerQueryHandler;

        public AddressesController(CreateAddressCommandHandler createAddressCommandHandler, GetAddressQueryHandler getAddressQueryHandler, RemoveAddressCommandHandler removeAddressCommandHandler, UpdateAddressCommandHandler updateAddressComandHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler,
            GetAddressWithCustomerQueryHandler getAddressWithCustomerQueryHandler)
        {
            _createAddressCommandHandler = createAddressCommandHandler;
            _getAddressQueryHandler = getAddressQueryHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
            _updateAddressComandHandler = updateAddressComandHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _getAddressWithCustomerQueryHandler = getAddressWithCustomerQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var value = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres bilgisi eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Adres bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressComandHandler.Handle(command);
            return Ok("Adres bilgisi güncellendi");
        }

        [HttpGet("GetAddressWithCustomer")]
        public IActionResult GetAddressWithCustomer()
        {
            var values = _getAddressWithCustomerQueryHandler.Handle();
            return Ok(values);
        }
    }
}
