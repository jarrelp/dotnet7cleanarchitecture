using System.Globalization;
using CleanArchitecture.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace CleanArchitecture.Infrastructure.Files.Maps;

public class OptionRecordMap : ClassMap<TodoItemRecord>
{
    public OptionRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
    }
}
