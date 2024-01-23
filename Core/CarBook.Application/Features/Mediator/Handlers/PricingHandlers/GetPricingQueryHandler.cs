using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery,List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            return result.Select(x => new GetPricingQueryResult
            {
                PricingId = x.PricingId,
                Name = x.Name
            }).ToList();
        }
    }
}
