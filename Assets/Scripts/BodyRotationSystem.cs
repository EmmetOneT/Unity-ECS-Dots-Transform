using Unity.Entities;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Transforms;

[BurstCompile]
partial struct BodyRotationSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        
    }

    public void OnDestroy(ref SystemState state)
    {
       
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var rotation = quaternion.RotateY(SystemAPI.Time.DeltaTime * math.PI);

        foreach(var transform in SystemAPI.Query<TransformAspect>().WithAll<Body>())
        {
            transform.RotateWorld(rotation);
        }
    }
}
