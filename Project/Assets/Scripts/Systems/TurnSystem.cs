using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class TurnSystem : SystemBase
{
    protected override void OnUpdate()
    {
		float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Rotation rotation, in RotateComponent rotationComponent) =>
        {
            if (rotationComponent.rotateTargetPosition.Equals(float3.zero))
                return;

            quaternion targetRotation = quaternion.LookRotationSafe(rotationComponent.rotateTargetPosition, math.up());
            rotation.Value = math.slerp(rotation.Value, targetRotation, rotationComponent.rotateSpeed);
        }).Schedule();
    }
}
