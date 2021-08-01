using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct TargetComponent : IComponentData
{
    public Entity followEntity;
    public Entity lookAtEntity;

    public float3 targetOffset;
}
