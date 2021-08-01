using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class InputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float horizontal = Mathf.Clamp(Input.GetAxis("Horizontal"), -1.0f, 1.0f);
        float vertical = Mathf.Clamp(Input.GetAxis("Vertical"), -1.0f, 1.0f);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Entities.ForEach((ref KeyboardInputComponent inputComponent, ref MoveComponent moveComponent, ref RotateComponent rotationComponent) => {
            inputComponent.horizontal = horizontal;
            inputComponent.vertical = vertical;

            inputComponent.mouseX = mouseX;
            inputComponent.mouseY = mouseY;

            moveComponent.targetDirection = new float3(inputComponent.horizontal, 0, inputComponent.vertical);
            rotationComponent.rotateTargetPosition = moveComponent.targetDirection;
        }).Schedule();
    }
}
