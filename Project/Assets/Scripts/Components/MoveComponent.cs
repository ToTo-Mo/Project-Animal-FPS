using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[GenerateAuthoringComponent]
public struct MoveComponent : IComponentData
{
    public float walkSpeed;
    public float sprintSpeed;

    [HideInInspector]
    public float3 targetDirection;
}
