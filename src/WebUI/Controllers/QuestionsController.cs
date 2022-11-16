﻿using CleanArchitecture.Application.TodoLists.Commands.CreateQuestion;
using CleanArchitecture.Application.TodoLists.Commands.DeleteQuestion;
using CleanArchitecture.Application.TodoLists.Commands.UpdateQuestion;
using CleanArchitecture.Application.TodoLists.Queries.ExportTodos;
using CleanArchitecture.Application.TodoLists.Queries.GetQuestions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

//[Authorize]
public class QuestionsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<QuestionDto>>> Get()
    {
        return await Mediator.Send(new GetQuestionsQuery());
    }

    [HttpGet("prioritylevels")]
    public async Task<ActionResult<List<PriorityLevelDto>>> GetPriorityLevels()
    {
        return await Mediator.Send(new GetPriorityLevelsQuery());
    }

    [HttpGet("{id}")]
    public async Task<FileResult> Get(int id)
    {
        var vm = await Mediator.Send(new ExportTodosQuery { QuestionId = id });

        return File(vm.Content, vm.ContentType, vm.FileName);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateQuestionCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateQuestionCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteQuestionCommand(id));

        return NoContent();
    }
}
