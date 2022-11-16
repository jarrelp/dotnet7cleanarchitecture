using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Skills.Queries.GetSkills;
using CleanArchitecture.Application.Skills.Commands.CreateSkill;
using CleanArchitecture.Application.Skills.Commands.DeleteSkill;
using CleanArchitecture.Application.Skills.Commands.UpdateSkill;
using CleanArchitecture.Application.Skills.Commands.PurgeSkills;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

//[Authorize]
public class SkillsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<SkillDto>>> Get()
    {
        return await Mediator.Send(new GetSkillsQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateSkillCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateSkillCommand command)
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
        await Mediator.Send(new DeleteSkillCommand(id));

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Purge()
    {
        await Mediator.Send(new PurgeSkillsCommand());

        return NoContent();
    }
}
