using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Questions.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<Option>
{
    public string? Description { get; set; }
}
