using Unity.Entities;

class BodyAuthoring : UnityEngine.MonoBehaviour
{
    class BodyBaker : Baker<BodyAuthoring>
    {
        public override void Bake(BodyAuthoring authoring)
        {
            AddComponent<Body>();
        }
    }
}

struct Body : IComponentData { }