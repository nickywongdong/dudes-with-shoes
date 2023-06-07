using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    StateMachine StateMachine;
    public GameObject Player { get; private set; }

    public PatrolPath Path;
    public NavMeshAgent Agent { get; private set; }

    [Header("Sight Values")]
    public float SightDistance = 20f;
    public float FieldOfView = 85f;
    public float EyeHeight;

    [Header("Weapon Values")]
    public Transform GunBarrel;
    [Range(0.1f,10)]
    public float FireRate;

    [SerializeField]
    string CurrentState;

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<StateMachine>();
        Agent = GetComponent<NavMeshAgent>();
        StateMachine.Initiailize();
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        CurrentState = StateMachine.ActiveState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (Player != null)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) < SightDistance)
            {
                Vector3 TargetDirection = Player.transform.position - transform.position - (Vector3.up * EyeHeight);
                float AngleToPlayer = Vector3.Angle(TargetDirection, transform.forward);
                if (AngleToPlayer >= -FieldOfView && AngleToPlayer <= FieldOfView)
                {
                    var Ray = new Ray((transform.position + Vector3.up * EyeHeight), TargetDirection);
                    if (Physics.Raycast(Ray, out var HitInfo, SightDistance))
                    {
                        if (HitInfo.transform.gameObject == Player)
                        {
                            Debug.DrawRay(Ray.origin, Ray.direction * SightDistance);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
