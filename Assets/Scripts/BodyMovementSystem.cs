using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

partial class BodyMovementSystem : SystemBase
{
    /*
    float range = 0;
    float3 pivotPoint = new float3(15, 0, 0);
    float amplitude = 10;
    */
    float speed = 5;
    protected override void OnUpdate()
    {
        //var et = (float) SystemAPI.Time.ElapsedTime;
        var dt = (float)SystemAPI.Time.DeltaTime;
        //range += et * 0.5f;

        Entities
            .WithAll<Body>()
            .WithoutBurst()
            .ForEach((TransformAspect transform) =>
            {
                /*
                var dir = new float3(0, 0, 1);
                transform.LocalPosition += dir * dt * 5.0f;
                transform.LocalPosition = Vector3.Slerp(new Vector3(-5, 0, 0), new Vector3(0, 0, 5), range);                
                transform.LocalPosition = new float3(pivotPoint.x + math.sin(et * speed) * amplitude, 
                                                     0, 
                                                     pivotPoint.z + math.cos(et *speed) * amplitude);
                */
                if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.W))
                {
                    transform.LocalPosition += new float3(0, 0, 1) * dt * speed;
                }
                else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.S))
                {
                    transform.LocalPosition += new float3(0, 0, -1) * dt * speed;
                }
                else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.D))
                {
                    transform.LocalPosition += new float3(1, 0, 0) * dt * speed;
                }
                else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.A))
                {
                    transform.LocalPosition += new float3(-1, 0, 0) * dt * speed;
                }

            }).Run();
    }
}
