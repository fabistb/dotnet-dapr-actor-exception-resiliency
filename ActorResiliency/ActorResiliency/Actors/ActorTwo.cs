using Dapr.Actors.Runtime;

namespace ActorResiliency.Actors;

public class ActorTwo : Actor, IActorTwo
{
    public ActorTwo(ActorHost host) 
        : base(host)
    {
    }
    
    public async Task ThrowException()
    {
        throw new Exception("ActorTwo exception");
    }
}