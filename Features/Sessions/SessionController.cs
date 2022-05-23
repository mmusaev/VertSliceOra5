using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        public async Task<ActionResult<GetSessionResult>> GetByCode([FromQuery]string code)
        {
            var result = await media.Send(new GetSessionQuery(code));

            return result;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<GetSessionsResult>> Get()
        {
            var result = await media.Send(new GetSessionsQuery());

            return result;
        }
    }
}
