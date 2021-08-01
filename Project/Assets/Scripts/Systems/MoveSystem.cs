using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class MoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation ,in MoveComponent moveComponent) => {
            if (moveComponent.targetDirection.Equals(float3.zero))
                return;
            
            translation.Value += moveComponent.targetDirection * moveComponent.walkSpeed * deltaTime;
        }).Schedule();
    }
}
