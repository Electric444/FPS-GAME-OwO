using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Transform player;
    public float damage;
    public float range = 100f;

    public Transform bulletPos;

    public FollowPlayer follow;

    bool wait = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (follow.seenPlayer)
        {
            StartCoroutine(Shoot());
        }
    }
    public IEnumerator Shoot()
    {
        if (!wait)
        {
            RaycastHit hit;
            if (Physics.Raycast(bulletPos.transform.position, bulletPos.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                }
                wait = true;
            }
        }
        else
        {
            yield return new WaitForSeconds(2);
            wait = false;
        }

    }
}

