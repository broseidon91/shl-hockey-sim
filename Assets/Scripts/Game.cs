using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Puck Puck;
    public static Game Instance;
    [SerializeField]
    private Transform HomeGoal;
    [SerializeField]
    private Transform AwayGoal;

    public void Awake()
    {
        Instance = this;
    }

    public Transform GetOpponentGoal(bool home)
    {
        return home ? AwayGoal : HomeGoal;
    }
}

public static class Extensions
{
    public static Vector3 Flatten(this Vector3 vec)
    {
        return new Vector3(vec.x, 0, vec.z);
    }
}
