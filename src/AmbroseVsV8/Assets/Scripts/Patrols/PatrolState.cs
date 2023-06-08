using UnityEngine;

public class PatrolState : BaseState
{
    public int WaypointIndex;
    public float WaitTimer;

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        PatrolCycle();
        if (Enemy.CanSeePlayer())
        {
            StateMachine.ChangeState(new AttackState());
        }
    }
    public void PatrolCycle()
    {
        if (Enemy.Agent.remainingDistance < 0.2f)
        {
            WaitTimer += Time.deltaTime;
            if(WaitTimer > 3)
            {
                if (WaypointIndex < Enemy.Path.Waypoints.Count - 1)
                {
                    WaypointIndex++;
                }
                else
                {
                    WaypointIndex = 0;
                }
                Enemy.Agent.SetDestination(Enemy.Path.Waypoints[WaypointIndex].position);
                WaitTimer = 0;
            }
        }
    }
}
