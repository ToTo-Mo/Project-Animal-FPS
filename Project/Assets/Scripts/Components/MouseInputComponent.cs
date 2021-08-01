using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct NewComponent : IComponentData
{
    public float mouseX;
    public float mouseY;
}
