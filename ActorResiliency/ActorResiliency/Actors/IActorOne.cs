using Dapr.Actors;

namespace ActorResiliency.Actors;

public interface IActorOne : IActor
{
    Task ThrowException();

    Task CallActorTwo();
}