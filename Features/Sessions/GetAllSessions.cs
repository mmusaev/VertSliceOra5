using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VertSliceOra5.Models;

namespace VertSliceOra5.Features.Sessions
{
    public class GetAllSessions
    {
        public class GetSessionsQuery : IRequest<GetSessionsResult>
        {
        }

        public class GetSessionsResult
        {
            public List<Session> Sessions { get; set; } = new List<Session>();
            public string Message { get; set; }
        }

        public class GetSessionsHandler : IRequestHandler<GetSessionsQuery, GetSessionsResult>
        {
            private readonly ModelContext repository;

            public GetSessionsHandler(ModelContext repository)
            {
                this.repository = repository;
            }
            public async Task<GetSessionsResult> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
            {
                var result = await repository.Sessions.ToListAsync();
                if (result.Count > 0)
                {
                    return new GetSessionsResult { Sessions = result};
                }

                return null;
            }
        }
    }
}
