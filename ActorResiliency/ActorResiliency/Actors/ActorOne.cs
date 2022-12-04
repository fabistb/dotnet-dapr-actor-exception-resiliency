using ActorResiliency.Infrastructure;
using Dapr.Actors;
using Dapr.Actors.Runtime;

namespace ActorResiliency.Actors;

public class ActorOne : Actor, IActorOne
{
    private readonly IActorFactory<ActorTwo> _actorFactoryTwo;

    public ActorOne(
        IActorFactory<ActorTwo> actorFactoryTwo,
        ActorHost host) 
        : base(host)
    {
        _actorFactoryTwo = actorFactoryTwo;
    }


    public async Task ThrowException()
    {
        throw new Exception("ActorOne exception");
    }

    public async Task CallActorTwo()
    {
        const string actorId = "actor-multi-exception";

        var actor = _actorFactoryTwo.CreateActor(actorId);
        await actor.ThrowException();
    }
}