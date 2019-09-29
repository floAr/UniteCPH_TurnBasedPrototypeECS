using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class InputSystem : ComponentSystem
{
    private void QueueMoveIntent(Entity id, int2 dir)
    {
        PostUpdateCommands.AddComponent<MoveIntention>(id, new MoveIntention() { direction_xz = dir });
        PostUpdateCommands.RemoveComponent<AwaitActionFlag>(id);
    }
    protected override void OnUpdate()
    {
        Entities.WithAll<PlayerComponent,AwaitActionFlag>().ForEach((Entity id) =>
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                QueueMoveIntent(id, new int2(0, 1));
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                QueueMoveIntent(id, new int2(-1, 0));
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                QueueMoveIntent(id, new int2(0, -1));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                QueueMoveIntent(id, new int2(1, 0));
            }
        });
    }
}
