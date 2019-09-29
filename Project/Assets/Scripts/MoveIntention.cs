using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct MoveIntention : IComponentData
{
    public int2 direction_xz; 
}
