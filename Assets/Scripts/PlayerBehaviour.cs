using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public bool homeTeam;
    
    public float Acceleration;
    public float MaxSpeed;
    public float SteeringAcceleration;

    public float PuckhandlingForce;

    public float ShootingStrength;

    public Transform Puckhandler;

    private Transform target;

    public enum Mode
    {
        ChasePuck,
        ScoreGoal
    }

    private Mode mode = Mode.ChasePuck;


    public void Start()
    {
        target = Game.Instance.Puck.transform;
    }

    public void OnTriggerEnter(Collider col)
    {
        Game.Instance.Puck.playersTouching.Add(this);
        mode = Mode.ScoreGoal;
        target = Game.Instance.GetOpponentGoal(homeTeam);

    }

    public void OnTriggerExit(Collider col)
    {
        Game.Instance.Puck.playersTouching.Remove(this);
        mode = Mode.ChasePuck;
        target = Game.Instance.Puck.transform;

    }

    public void ShootPuck()
    {
        if (Game.Instance.Puck.playersTouching.Contains(this) == false)
        {
            return;
        }

        Vector3 dir = Game.Instance.GetOpponentGoal(homeTeam).position - Game.Instance.Puck.transform.position;
        dir = dir + Random.insideUnitSphere * 1f;
        dir = dir.normalized;

        Game.Instance.Puck.AddForce(dir * ShootingStrength);
        Game.Instance.Puck.playersTouching.Remove(this);
        mode = Mode.ChasePuck;
    }

    public void Update()
    {
        if (mode == Mode.ScoreGoal)
        {
            var dist = Vector3.Distance(Game.Instance.GetOpponentGoal(homeTeam).position, transform.position);
            if (dist < 5)
                ShootPuck();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var steering = Vector3.zero;

        steering = target.position - transform.position;

        steering = steering.Flatten();

        //apply steering
        if (steering != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(steering), SteeringAcceleration * Time.deltaTime);


        rb.AddForce(transform.forward * Acceleration * Time.deltaTime, ForceMode.Force);
        // if (rb.velocity.magnitude > MaxSpeed)
        // {
        //     rb.velocity = rb.velocity.normalized * MaxSpeed;
        // }

    }
}
