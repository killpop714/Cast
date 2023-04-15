using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private Transform Target;
    NavMeshAgent navy;
    // Start is called before the first frame update
    void Start()
    {
        navy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        navy.SetDestination(Target.position);
    }
}
