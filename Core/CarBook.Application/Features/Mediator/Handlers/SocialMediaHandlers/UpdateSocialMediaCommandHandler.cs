using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.SocialMediaId);
            result.Name = request.Name;
            result.Icon = request.Icon;
            result.Url = request.Url;
            await _repository.UpdateAsync(result);
        }
    }
}
