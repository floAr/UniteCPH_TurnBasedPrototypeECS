using Unity.Entities;
using Unity.Mathematics;
using static Unity.Mathematics.math;

[DisableAutoCreation]
public class MoveSystem : ComponentSystem
{
    public int grid_x = 5; 
    public int grid_z = 5; 

    private bool inBounds(float3 target_pos)
    {
        return target_pos.x >= 0 && target_pos.x <= grid_x && target_pos.z >= 0 && target_pos.z <= grid_z;
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((Entity id, ref ActorComponent actor, ref MoveIntention intent) => 
        { 
            var target_pos = actor.target_positon + float3(intent.direction_xz.x, 0, intent.direction_xz.y);
            if (inBounds(target_pos))
            {
                actor.target_positon = target_pos;
            }

            PostUpdateCommands.RemoveComponent<MoveIntention>(id);
        });
    }


}