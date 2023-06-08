using Unity.Entities;
using UnityEngine;

public class PlayerSpawnerAuthoring : MonoBehaviour
{
    public GameObject PlayerPrefab;
}

public class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthoring>
{
    public override void Bake(PlayerSpawnerAuthoring authoring)
    {
        AddComponent(GetEntity(TransformUsageFlags.Dynamic), new PlayerSpawnerComponent 
        { 
            PlayerPrefab = GetEntity(authoring.PlayerPrefab, TransformUsageFlags.Dynamic) 
        });
    }
}