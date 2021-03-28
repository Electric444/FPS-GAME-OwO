using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public FollowPlayer followScript;

    public Transform[] moveSpots;
    private int randomSpot;

    //Waits
    private float waitTime;

    public float startWaitTime;

    private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);

        nav = gameObject.GetComponent<NavMeshAgent>();

        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!followScript.seenPlayer && !followScript.shot)
        {
            PatrolFunc();
        }
    }
    void PatrolFunc()
    {
        if (!followScript.seenPlayer)
            nav.SetDestination(moveSpots[randomSpot].position);

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
