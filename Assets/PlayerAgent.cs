using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAgent : MonoBehaviour
{

    public Transform Ball;

    NavMeshAgent nav;

    [Range(5,9)]
    [SerializeField] float minSpeed;

    [Range(9, 15)]
    [SerializeField] float maxSpeed;

    [SerializeField] Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballToGoalDir = goal.position - Ball.position;

        nav.SetDestination(Ball.position - ballToGoalDir.normalized * 1.2f);

        //ma tae yin lel mal tae yin kan mal
        if (Vector3.Distance(transform.position, Ball.position) < 1.8f)    
        {
            if (Vector3.Angle(transform.forward, ballToGoalDir) < 10)
            {
                Ball.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(500, 650));
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(ballToGoalDir), nav.acceleration * Time.deltaTime); //nav.angularspeed
        }

        //if(nav.remainingDistance < 1.5f)
        
    }
}
