﻿using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Results.Queries.GetResultsWithPagination;

public class ResultBriefDto : IMapFrom<Result>
{
    public int Id { get; set; }

    public IList<OptionBriefDto>? OptionBriefDtos { get; set; }
}
