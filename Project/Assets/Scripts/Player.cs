using System;
using Unity.Entities;
using UnityEngine;


[Serializable]
public struct PlayerComponent : IComponentData
{

}

public class Player : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponent<PlayerComponent>(entity);
        dstManager.AddComponent<AwaitActionFlag>(entity);
    }
}
