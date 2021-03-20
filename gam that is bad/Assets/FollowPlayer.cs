using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public EnemyGun gun;

    public Transform player;
    public NavMeshAgent nav;

    public float range;
    public LayerMask playerLayer;

    public bool seenPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!seenPlayer)
        {
            Debug.DrawRay(this.gameObject.transform.position, this.transform.forward, Color.yellow, range);
            RaycastHit hit;
            if (Physics.Raycast(this.gameObject.transform.position, this.transform.forward, out hit, range, playerLayer))
            {
                seenPlayer = true;
                nav.SetDestination(player.position);
                StartCoroutine(gun.Shoot());
            }
        }
    }
}
