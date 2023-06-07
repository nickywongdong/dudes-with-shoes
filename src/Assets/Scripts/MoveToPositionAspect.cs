using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct MovetoPositionAspect : IAspect
{
    public readonly Entity Self;

    readonly RefRW<LocalTransform> ObjectTransform;
    readonly RefRW<Speed> ObjectSpeed;
    readonly RefRW<TargetPosition> ObjectTargetPosition;

    public float3 Position
    {
        get => ObjectTransform.ValueRO.Position;
        set => ObjectTransform.ValueRW.Position = value;
    }

    public float Speed
    {
        get => ObjectSpeed.ValueRO.value;
        set => ObjectSpeed.ValueRW.value = value;
    }

    public float3 TargetPosition
    {
        get => ObjectTargetPosition.ValueRO.value;
        set => ObjectTargetPosition.ValueRW.value = value;
    }

    public void Move(float deltaTime)
    {
        float3 direction = math.normalize(TargetPosition - Position);
        Position += direction * deltaTime * Speed;
    }

    public void TestReachedTargetPosition(RefRW<RandomGeneratorComponent> randomGeneratorComponent)
    {
        float reachedTargetDistance = 0.5f;
        if (math.distance(Position, TargetPosition) < reachedTargetDistance)
        {
            TargetPosition = GetRandomPosition(randomGeneratorComponent);
        }
    }

    float3 GetRandomPosition(RefRW<RandomGeneratorComponent> random)
    {
        return new float3(
            random.ValueRW.random.NextFloat(0f, 15f),
            0,
            random.ValueRW.random.NextFloat(0f, 15f)
        );
    }
}