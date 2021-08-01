using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class LookAtSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Rotation rotation,in KeyboardInputComponent inputComponent) => {
            // rotation.Value = quaternion.RotateY(inputComponent.mouseX * deltaTime);
            float mouseDelta = inputComponent.mouseX * inputComponent.mouseSensitivity;

            rotation.Value = math.mul(
                                    rotation.Value,
                                    quaternion.RotateY(math.radians(mouseDelta)
                                    ));
        }).Schedule();
    }
}
