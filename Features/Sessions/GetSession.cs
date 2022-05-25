using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VertSliceOra5.Infrastructure;
using VertSliceOra5.Models;
using static VertSliceOra5.Features.Sessions.GetSessions;

namespace VertSliceOra5.Features.Sessions
{
    public class GetSessions
    {
        public class GetSessionQuery : IRequest<Result<GetSessionResult>>
        {
            public string SessionCode { get; set; }

            //public GetSessionQuery(string sessionCode)
            //{
            //    SessionCode = sessionCode;
            //}
        }

        public class GetSessionResult
        {
            public Session Session { get; set; }
            public string Message { get; set; }
        }

        public class Validator : AbstractValidator<GetSessionQuery>
        {
            public Validator()
            {
                RuleFor(x => x.SessionCode)
                    .NotNull()
                    .MaximumLength(2)
                    .WithMessage("Maximum lenght for the Name is 2 characters.");

                // RuleFor(x => x.Age).NotNull();
                //RuleFor(x => x.Position).NotNull().MaximumLength(20).WithMessage("Maximum length for the position is 20 characters.");
            }
        }
    }

    public class GetSessionHandler : IRequestHandler<GetSessionQuery, Result<GetSessionResult>>
    {
        private readonly ModelContext repository;

        public GetSessionHandler(ModelContext repository)
        {
            this.repository = repository;
        }

        public async Task<Result<GetSessionResult>> Handle(GetSessionQuery request, CancellationToken cancellationToken)
        {
            GetSessionResult result = new GetSessionResult();

            var validator = new Validator();
            FluentValidation.Results.ValidationResult validation = validator.Validate(request);
            if (!validation.IsValid)
            {
                result.Message = validation.Errors[0].ErrorMessage;
                return Result<GetSessionResult>.Fail($"Due to an error {result.Message}");
            }

            var session = await repository.Sessions.FindAsync(request.SessionCode);
            if (session == null)
            {
                result.Message = "Not found";
                return Result<GetSessionResult>.Fail($"Due to an error {result.Message}");
            }

            result.Session = session;
            result.Message = "Succeded";

            return Result<GetSessionResult>.Success(result);

        }
    }
}
