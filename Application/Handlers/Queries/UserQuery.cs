using Application.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class UserQuery : IRequest<UserResponse>
    {
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public string lga { get; set; }
    }

    public class OnboardQueryValidator : AbstractValidator<UserQuery>
    {
        public OnboardQueryValidator()
        {
            RuleFor(c => c.phoneNumber).NotEmpty().MaximumLength(11).MinimumLength(11);
            RuleFor(c => c.email).NotEmpty().EmailAddress();
            RuleFor(c => c.state).NotEmpty();
            RuleFor(c => c.lga).NotEmpty();
        }
    }
}



