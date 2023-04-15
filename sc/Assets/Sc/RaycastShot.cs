using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShot : MonoBehaviour
{
    public Camera Cam;
    public Transform laserPos;
    public float gunRange = 50f;
    public float laserDuration = 0.05f;
    public float fireRate = 0.2f;

    RotaMove ro;

    
    LineRenderer Line;
    // Start is called before the first frame update
    void Start()
    {
        Line = GetComponent<LineRenderer>();
        
        ro = GetComponent<RotaMove>();
    }

    public void Fire()
    {
        if (ro.fireTimer < fireRate)
        {
           
        Line.SetPosition(0, laserPos.position);
            Vector3 rayPos = Cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayPos, Cam.transform.forward, out hit, gunRange))
            {
                Line.SetPosition(1, hit.point);
                if(hit.transform.CompareTag("Enemy"))
                Destroy(hit.transform.gameObject);
            }
            else
            {
                Line.SetPosition(1, rayPos + (Cam.transform.forward * gunRange));

            }
            StartCoroutine("Shoot");
        }
    }
    IEnumerator Shoot()
    {
        Line.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        Line.enabled = false;
    }

}
