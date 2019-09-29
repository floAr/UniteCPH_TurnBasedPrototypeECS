using Unity.Entities;

public class TurnBasedGameLoop : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<PlayerComponent, MoveIntention>().ForEach((Entity id) =>
        {
            World.GetOrCreateSystem<RandomMoveSystem>().Update();
            World.GetOrCreateSystem<MoveSystem>().Update();
        });
    }
}
