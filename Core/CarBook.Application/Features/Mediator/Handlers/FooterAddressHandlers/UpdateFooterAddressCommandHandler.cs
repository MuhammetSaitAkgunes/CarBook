using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.FooterAddressId);
            result.Address = request.Address;
            result.Description = request.Description;
            result.Email = request.Email;
            result.Phone = request.Phone;
            await _repository.UpdateAsync(result);
        }
    }
}
