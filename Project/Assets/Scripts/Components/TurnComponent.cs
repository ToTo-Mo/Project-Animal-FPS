using Unity.Entities;

[GenerateAuthoringComponent]
public struct TurnComponent : IComponentData
{
    public float turnSpeed;
}
