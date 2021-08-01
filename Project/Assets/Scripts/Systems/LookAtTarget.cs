using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class LookAtTarget : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.WithAll<TargetComponent>()
            .ForEach((ref RotateComponent rotationComponent, in Translation translation, in TargetComponent targetComponent) => {
                ComponentDataFromEntity<Translation> translationArray = GetComponentDataFromEntity<Translation>(true);

                if(!translationArray.HasComponent(targetComponent.lookAtEntity)){
                    return;
                }

                Translation targetPosition = translationArray[targetComponent.lookAtEntity];

                rotationComponent.rotateTargetPosition = targetPosition.Value - translation.Value;


                // rotationComponent.rotateTargetPosition = new float3(rotationComponent.rotateTargetPosition.x, 0f, rotationComponent.rotateTargetPosition.z);
                rotationComponent.rotateTargetPosition.x = !rotationComponent.freezeRotation.x ? rotationComponent.rotateTargetPosition.x : 0f;
                rotationComponent.rotateTargetPosition.y = !rotationComponent.freezeRotation.y ? rotationComponent.rotateTargetPosition.y : 0f;
                rotationComponent.rotateTargetPosition.z = !rotationComponent.freezeRotation.z ? rotationComponent.rotateTargetPosition.z : 0f;
        }).Schedule();
    }
}
