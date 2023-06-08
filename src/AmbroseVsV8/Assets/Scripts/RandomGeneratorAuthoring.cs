using Unity.Entities;
using UnityEngine;

public class RandomGeneratorAuthoring : MonoBehaviour
{
}

public class RandomGeneratorBaker : Baker<RandomGeneratorAuthoring>
{
    public override void Bake(RandomGeneratorAuthoring authoring)
    {
        AddComponent(GetEntity(TransformUsageFlags.Dynamic), new RandomGeneratorComponent
        {
            random = new Unity.Mathematics.Random(1)
        });
    }
}