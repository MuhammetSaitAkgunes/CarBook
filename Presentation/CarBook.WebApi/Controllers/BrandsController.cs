using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;

        public BrandsController(GetBrandQueryHandler getBrandQueryHandler,
            CreateBrandCommandHandler createBrandCommandHandler,
            RemoveBrandCommandHandler removeBrandCommandHandler,
            UpdateBrandCommandHandler updateBrandCommandHandler,
            GetBrandByIdQueryHandler getBrandByIdQueryHandler)
        {
            _getBrandQueryHandler = getBrandQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var result = await _getBrandQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var result = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Brand Eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Brand Güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Brand Silindi.");
        }
    }
}
