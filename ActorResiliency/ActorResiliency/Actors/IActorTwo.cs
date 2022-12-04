using Dapr.Actors;

namespace ActorResiliency.Actors;

public interface IActorTwo : IActor
{
    Task ThrowException();
}