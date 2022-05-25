using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VertSliceOra5.Infrastructure;
using static VertSliceOra5.Features.Sessions.GetAllSessions;
using static VertSliceOra5.Features.Sessions.GetSessions;

namespace VertSliceOra5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly IMediator media;

        public SessionController(IMediator media)
        {
            this.media = media;
        }

        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCode([FromQuery] GetSessionQuery query)
        {
            var result = await media.Send(query);

            return ResultHelper(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await media.Send(new GetSessionsQuery());

            return ResultHelper(result);
        }

        private IActionResult ResultHelper<T>(Result<T> result)
        {
            return result.IsSuccess ? Ok(result.Payload) : Problem(title: result.FailureReason);
        }
    }
}
