using Unity.Entities;
using UnityEngine;

public class PlayerTagAuthoring : MonoBehaviour
{
}

public class PlayerTagBaker : Baker<PlayerTagAuthoring>
{
    public override void Bake(PlayerTagAuthoring authoring)
    {
        AddComponent(GetEntity(TransformUsageFlags.Dynamic), new PlayerTag());
    }
}