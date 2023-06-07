/*using Unity.Entities;
using static Unity.Entities.SystemAPI;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        foreach (var moveToPositionAspect in Query<MovetoPositionAspect>())
        {
            moveToPositionAspect.Move(SystemAPI.Time.DeltaTime);
        }
    }
}
*/