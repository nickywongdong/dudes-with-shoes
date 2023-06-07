using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState ActiveState;

    private void Update()
    {
        ActiveState?.Perform();
    }

    public void Initiailize()
    {
        ChangeState(new PatrolState());
    }

    public void ChangeState(BaseState NewState)
    {
        // run cleanup on ActiveState
        ActiveState?.Exit();

        // Change to a new state
        ActiveState = NewState;

        // Check new state was not null
        if (ActiveState != null)
        {
            ActiveState.StateMachine = this;
            ActiveState.Enemy = GetComponent<Enemy>();
            ActiveState.Enter();
        }
    }
}
