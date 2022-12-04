using ActorResiliency.Actors;
using ActorResiliency.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ActorResiliency.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorFactory<IActorOne> _actorFactoryOne;

    public ActorController(IActorFactory<IActorOne> actorFactoryOne)
    {
        _actorFactoryOne = actorFactoryOne;
    }

    [HttpPost("single")]
    public async Task<ActionResult> SingleActorException()
    {
        const string actorIdSingle = "actor-single-exception";

        var actor = _actorFactoryOne.CreateActor(actorIdSingle);
        await actor.ThrowException();
        
        return Ok();
    }

    [HttpPost("multi")]
    public async Task<ActionResult> MultiActorException()
    {
        const string actorIdMulti = "actor-multi-exception";

        var actor = _actorFactoryOne.CreateActor(actorIdMulti);
        await actor.CallActorTwo();
        
        return Ok();
    }
}