/*using Unity.Entities;

public partial class PlayerSpawnerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var playerEntityQuery = EntityManager.CreateEntityQuery(typeof(PlayerTag));

        var playerSpawnerComponent = SystemAPI.GetSingleton<PlayerSpawnerComponent>();
        var randomComponent = SystemAPI.GetSingletonRW<RandomGeneratorComponent>();

        var entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

        int spawnAmount = 20;
        if (playerEntityQuery.CalculateEntityCount() <= spawnAmount)
        {
            var spawnedEntity = entityCommandBuffer.Instantiate(playerSpawnerComponent.PlayerPrefab);
            entityCommandBuffer.SetComponent(spawnedEntity, new Speed
            {
                value = randomComponent.ValueRW.random.NextFloat(1f, 5f)
            });
        }
    }
}
*/