using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Transforms;

[DisallowMultipleComponent]
public class ThirdPersonCamera : MonoBehaviour, IConvertGameObjectToEntity
{
    public GameObject camera;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponent<CopyTransformToGameObject>(entity);

        ConvertCamera convertCamera  = camera.GetComponent<ConvertCamera>();

        if(convertCamera == null){
            convertCamera = camera.AddComponent<ConvertCamera>();
        }

        convertCamera.followEntity = entity;
        
    }
}
