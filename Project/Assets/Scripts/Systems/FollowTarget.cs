using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class FollowTarget : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref MoveComponent moveComponent,in TargetComponent targetComponent, in Translation translation) => {
            ComponentDataFromEntity<Translation> translationArray = GetComponentDataFromEntity<Translation>(true);

            if(!translationArray.HasComponent(targetComponent.followEntity)){
                return;
            }

            Translation targetPosition = translationArray[targetComponent.followEntity];

            moveComponent.targetDirection = (targetPosition.Value - translation.Value);
            moveComponent.targetDirection.x += targetComponent.targetOffset.x;
            moveComponent.targetDirection.y += targetComponent.targetOffset.y;
            moveComponent.targetDirection.z += targetComponent.targetOffset.z;
        }).Schedule();
    }
}
