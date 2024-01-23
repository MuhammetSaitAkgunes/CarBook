using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarId);
            values.BigImageUrl = command.BigImageUrl;
            values.Luggage = command.Luggage;
            values.Km = command.Km;
            values.Model = command.Model;
            values.Seat = command.Seat;
            values.Transmission = command.Transmission;
            values.CoverImageUrl = command.CoverImageUrl;
            values.BrandId = command.BrandId;
            values.Fuel = command.Fuel;
            await _repository.UpdateAsync(values);
        }
    }
}
