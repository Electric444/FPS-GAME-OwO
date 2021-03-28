using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerForGun : MonoBehaviour
{
    public FollowPlayer follow;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        if (follow.seenPlayer)
        {
            transform.LookAt(player.position);
        }

    }
}
