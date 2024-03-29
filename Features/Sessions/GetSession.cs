﻿using FluentValidation;
using MediatR;
using System;
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

                RuleFor(x => x)
                    .MustAsync(SessionCheck)
                    .WithMessage("Session code doesn't exist");
                // RuleFor(x => x.Age).NotNull();
                //RuleFor(x => x.Position).NotNull().MaximumLength(20).WithMessage("Maximum length for the position is 20 characters.");
            }

            //Can check database here
            private Task<bool> SessionCheck(GetSessionQuery arg1, CancellationToken arg2)
            {
                return Task.FromResult(arg1.SessionCode == "Ta");
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
