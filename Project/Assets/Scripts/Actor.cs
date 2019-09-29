using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public struct ActorComponent : IComponentData
{
    public float3 position;
    public float3 target_positon;
}


[DisallowMultipleComponent]
[RequiresEntityConversion]
public class Actor : MonoBehaviour, IConvertGameObjectToEntity
{

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        float3 grid_pos = new float3(
            math.floor(transform.position.x),
            0,
            math.floor(transform.position.z)
            );

        dstManager.AddComponentData(entity, new ActorComponent()
        {
            position = grid_pos,
            target_positon = grid_pos,
        });
    }
}
