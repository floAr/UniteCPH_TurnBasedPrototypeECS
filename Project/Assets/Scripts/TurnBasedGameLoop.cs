using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


public struct AwaitActionFlag : IComponentData
{ }

public struct ReadyToHandleFlag : IComponentData
{ }



public class TurnBasedGameLoop : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<PlayerComponent>().ForEach((Entity id) => { }); // weirdness

        // remove token
        Entities.WithAll<ReadyToHandleFlag>().ForEach((Entity id) =>
        {
            PostUpdateCommands.RemoveComponent<ReadyToHandleFlag>(id);
        });
        // query for waiting
        var waiting = Entities.WithAll<AwaitActionFlag>().ToEntityQuery().CalculateEntityCount();

        // if 0 waiting hand out tokens, refresh awaiting
        if (waiting == 0)
        {
            Entities.WithAll<ActorComponent>().ForEach((Entity id) =>
            {
                PostUpdateCommands.AddComponent<ReadyToHandleFlag>(id);
            });

            Entities.WithAll<PlayerComponent>().ForEach((Entity id) =>
            {
                PostUpdateCommands.AddComponent<AwaitActionFlag>(id);
            });
        }
    }
}
