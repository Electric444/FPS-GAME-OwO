using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Text bulletText;
    [Space]
    public GameObject flashReload;
    [Space]
    public Animator anim;

    public Camera fpsCam;

    //RELOADING

    public float currentBullets;
    public float maxBullets;

    public float reloadTime;

    bool isReloading;
    public bool alreadyShooting;

    [Space]

    public float damage;
    public float range = 100f;
    // Start is called before the first frame update
    void Start()
    {
        alreadyShooting = false;
        currentBullets = maxBullets;
        bulletText.text = maxBullets.ToString();
        flashReload.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && alreadyShooting == false)
        {
            StartCoroutine(Shoot());
        }
        else if(Input.GetButtonDown("Fire1") && alreadyShooting == true)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }
        if(currentBullets <= 0)
        {
            StartCoroutine(FlashReload());
        }
    }
    public IEnumerator Shoot()
    {
        if(currentBullets > 0 && !isReloading && !alreadyShooting)
        {
            alreadyShooting = true;
            Debug.Log(alreadyShooting);
            currentBullets--;
            FindObjectOfType<AudioManager>().Play("Shoot");
            bulletText.text = currentBullets.ToString();
            anim.Play("Recoil");
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                }

            }
            yield return new WaitForSeconds(0.9f);
            alreadyShooting = false;
        }
    }

    IEnumerator Reload()
    {
        if(currentBullets < maxBullets && !alreadyShooting)
        {
            isReloading = true;
            bulletText.text = "Reloading...";
            FindObjectOfType<AudioManager>().Play("Reload");
            anim.Play("Reload");
            yield return new WaitForSeconds(reloadTime);
            currentBullets = maxBullets;
            bulletText.text = maxBullets.ToString();
            isReloading = false;
        }
    }
    IEnumerator FlashReload()
    {
        while (currentBullets <= 0 && !isReloading)
        {
            flashReload.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            flashReload.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
        if(currentBullets >= 0)
        {
            flashReload.SetActive(false);
        }
    }
}
