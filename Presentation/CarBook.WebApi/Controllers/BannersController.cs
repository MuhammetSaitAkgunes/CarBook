using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.commandHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;

        public BannersController(GetBannerQueryHandler getBannerQueryHandler,
            CreateBannerCommandHandler createBannerCommandHandler,
            RemoveBannerCommandHandler removeBannerCommandHandler,
            UpdateBannerCommandHandler updateBannerCommandHandler,
            GetBannerByIdQueryHandler getBannerByIdQueryHandler)
        {
            _getBannerQueryHandler = getBannerQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var result = await _getBannerQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById(int id)
        {
            var result = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Banner Eklendi.");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner Güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner Silindi.");
        }

    }
}
