using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;

        public ContactsController(GetContactQueryHandler getContactQueryHandler,
            CreateContactCommandHandler createContactCommandHandler,
            RemoveContactCommandHandler removeContactCommandHandler,
            UpdateContactCommandHandler updateContactCommandHandler,
            GetContactByIdQueryHandler getContactByIdQueryHandler)
        {
            _getContactQueryHandler = getContactQueryHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var result = await _getContactQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var result = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Contact Eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Contact Güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact Silindi.");
        }
    }
}
