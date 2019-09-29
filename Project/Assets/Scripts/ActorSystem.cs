using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class ActorSystem : JobComponentSystem
{
    [BurstCompile]
    struct ActorSystemJob : IJobForEach<Translation, Rotation, ActorComponent>
    {
        public float deltaTime;

        public void Execute(ref Translation translation,
            ref Rotation rotation,
            ref ActorComponent actor)
        {
            var direction = actor.target_positon - actor.position;
            if (math.length(direction) > 0.1f)
            {
                direction = math.normalize(direction);
                rotation.Value = quaternion.LookRotation(direction, math.up());
                translation.Value = translation.Value + direction * deltaTime;
                actor.position = translation.Value;
            }
            else
            {
                translation.Value = actor.target_positon;
                actor.position = translation.Value;
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new ActorSystemJob
        {
            deltaTime = UnityEngine.Time.deltaTime
        };

        return job.Schedule(this, inputDependencies);
    }
}