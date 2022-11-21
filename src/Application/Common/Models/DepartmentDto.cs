﻿using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Models;

public class DepartmentDto : IMapFrom<Department>
{
    public DepartmentDto()
    {
        ApplicationUsers = new List<ApplicationUserDto>();
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public IList<ApplicationUserDto> ApplicationUsers { get; set; }
}
