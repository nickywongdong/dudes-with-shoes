using Unity.Entities;

public struct RandomGeneratorComponent : IComponentData
{
    public Unity.Mathematics.Random random;
}
