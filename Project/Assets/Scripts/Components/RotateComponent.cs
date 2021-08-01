using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[GenerateAuthoringComponent]
public struct RotateComponent : IComponentData
{
   public float rotateSpeed;

   [HideInInspector]
   public float3 rotateTargetPosition;

   public bool3 freezeRotation;
}
