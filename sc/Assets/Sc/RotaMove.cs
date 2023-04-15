using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaMove : MonoBehaviour
{
    [SerializeField]
    float Rotation_Mov = 3f;
    Animation ani;
    RaycastShot Rays;

    public float fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
        Rays = GetComponent<RaycastShot>();
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        //움직임
        float mx = Input.GetAxis("Mouse X")*Rotation_Mov;
        float my = Input.GetAxis("Mouse Y")*Rotation_Mov;

        Quaternion mosX = Quaternion.AngleAxis(mx, Vector3.up);
        Quaternion mosY = Quaternion.AngleAxis(my, Vector3.right);
        this.transform.rotation *= mosX;

        //에니
        if(Input.GetMouseButtonDown(0))
        {
            fireTimer = 0;
            Rays.Fire();
            
            if(ani.IsPlaying("IdleFireSMG"))
            {
                ani.Stop("IdleFireSMG");
            }
            ani.Play("IdleFireSMG");
        }

    }
}
