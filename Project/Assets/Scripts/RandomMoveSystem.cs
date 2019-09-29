using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;


public class RandomMoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {

        Entities.WithAll<ActorComponent>().ForEach((Entity id) =>
        {
            var direction = UnityEngine.Random.value > 0.5f ? new int2(UnityEngine.Random.value > 0.5f ? 1 : -1, 0) : new int2(0, UnityEngine.Random.value > 0.5f ? 1 : -1);
            var intent = new MoveIntention()
            {
                direction_xz = direction
            };

            PostUpdateCommands.AddComponent<MoveIntention>(id, intent);
                //UnityEditor.EditorApplication.isPaused = true;
            });
    }
}