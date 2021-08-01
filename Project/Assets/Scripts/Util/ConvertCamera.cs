using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class ConvertCamera : MonoBehaviour, IConvertGameObjectToEntity
{

    public EntityManager entityManager;
    public float moveSpeed;
    public float rotateSpeed;

    public float3 offsetPosition;
    public Entity lookAtEntity;
    public Entity followEntity;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

        dstManager.AddComponent<CopyTransformToGameObject>(entity);

        dstManager.AddComponentData(entity, new MoveComponent {walkSpeed = moveSpeed});
        dstManager.AddComponentData(entity, new TargetComponent{ followEntity = followEntity, lookAtEntity=lookAtEntity, targetOffset = offsetPosition});
        dstManager.AddComponentData(entity, new RotateComponent{rotateSpeed = rotateSpeed});
    }

    void Awake() {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }
}
