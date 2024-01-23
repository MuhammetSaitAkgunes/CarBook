using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.PricingId); 
            result.Name = request.Name;
            await _repository.UpdateAsync(result);
        }
    }
}
