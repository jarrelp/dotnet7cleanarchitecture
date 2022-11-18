﻿using FluentValidation;

namespace CleanArchitecture.Application.Results.Queries.GetResultsWithPagination;

public class GetResultsWithPaginationQueryValidator : AbstractValidator<GetResultsWithPaginationQuery>
{
    public GetResultsWithPaginationQueryValidator()
    {
        RuleFor(x => x.QuestionId)
            .NotEmpty().WithMessage("QuestionId is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
