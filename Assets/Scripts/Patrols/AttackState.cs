using UnityEngine;

public class AttackState : BaseState
{
    float MoveTimer;
    float LoserPlayerTimer;
    float ShotTimer;
    readonly float _bulletVelocity = 40f;

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public void Shoot()
    {
        Debug.Log("Shooting");
        var GunBarrel = Enemy.GunBarrel;
        var Bullet = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"), GunBarrel.position, Enemy.transform.rotation);
        var ShootDirection = (Enemy.transform.position - GunBarrel.transform.position).normalized;
        //Bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * ShootDirection * 40;
        Bullet.GetComponent<Rigidbody>().velocity = ShootDirection * _bulletVelocity;

        ShotTimer = 0;
    }

    public override void Perform()
    {
        if (Enemy.CanSeePlayer())
        {
            LoserPlayerTimer = 0;
            MoveTimer += Time.deltaTime;
            ShotTimer += Time.deltaTime;
            Enemy.transform.LookAt(Enemy.Player.transform);

            if (ShotTimer > Enemy.FireRate)
            {
                Shoot();
            }

            if (MoveTimer > Random.Range(3, 7))
            {
                Enemy.Agent.SetDestination(Enemy.transform.position + (Random.insideUnitSphere * 5));
                MoveTimer = 0;
            }
        }
        else
        {
            LoserPlayerTimer += Time.deltaTime;
            if (LoserPlayerTimer > 8)
            {
                StateMachine.ChangeState(new PatrolState());
            }
        }
    }
}
