using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VertSliceOra5.Infrastructure;
using VertSliceOra5.Models;

namespace VertSliceOra5.Features.Sessions
{
    public class GetAllSessions
    {
        public class GetSessionsQuery : IRequest<Result<GetSessionsResult>>
        {
        }

        public class GetSessionsResult
        {
            public List<Session> Sessions { get; set; } = new List<Session>();
            public string Message { get; set; }
        }

        public class GetSessionsHandler : IRequestHandler<GetSessionsQuery, Result<GetSessionsResult>>
        {
            private readonly ModelContext repository;

            public GetSessionsHandler(ModelContext repository)
            {
                this.repository = repository;
            }
            public async Task<Result<GetSessionsResult>> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
            {
                var result = await repository.Sessions.ToListAsync();
                if (result.Count > 0)
                {
                   var result2 = new GetSessionsResult { Sessions = result };

                    return Result<GetSessionsResult>.Success(result2);
                }

                return Result<GetSessionsResult>.Fail($"No sessions found in the database.");
            }
        }
    }
}
