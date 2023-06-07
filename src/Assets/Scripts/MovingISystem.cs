/*using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using static Unity.Entities.SystemAPI;

public partial struct MovingISystem : ISystem
{
    [BurstCompile]
    public readonly void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<RandomGeneratorComponent>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var random = GetSingletonRW<RandomGeneratorComponent>();
        float deltaTime = Time.DeltaTime;

        var jobHandle = new MoveJob
        {
            deltaTime = deltaTime
        }.ScheduleParallel(state.Dependency);

        jobHandle.Complete();

        new TestReachedTargetPositionJob
        {
            randomGeneratorComponent = random
        }.Run();
    }

}
[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float deltaTime;
    public readonly void Execute(MovetoPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.Move(deltaTime);
    }
}

[BurstCompile]
public partial struct TestReachedTargetPositionJob : IJobEntity
{
    [NativeDisableUnsafePtrRestriction]
    public RefRW<RandomGeneratorComponent> randomGeneratorComponent;
    public readonly void Execute(MovetoPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.TestReachedTargetPosition(randomGeneratorComponent);
    }
}*/