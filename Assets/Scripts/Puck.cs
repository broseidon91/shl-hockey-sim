using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public List<PlayerBehaviour> playersTouching;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        foreach (var player in playersTouching)
        {
            var dir = player.Puckhandler.position - transform.position;
            dir = dir.Flatten();
            rb.AddForce(dir * player.PuckhandlingForce * Time.deltaTime, ForceMode.Force);
        }
    }

    public void AddForce(Vector3 dir)
    {
        rb.AddForce(dir, ForceMode.Impulse);
    }
}
