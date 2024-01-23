using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.TestimonialId);
            result.Title = request.Title;
            result.ImageUrl = request.ImageUrl;
            result.Name = request.Name;
            result.Comment = request.Comment;
            await _repository.UpdateAsync(result);
        }
    }
}
