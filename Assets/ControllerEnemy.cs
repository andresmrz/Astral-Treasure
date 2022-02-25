using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerEnemy : MonoBehaviour
{
    public float lookRadius = 10f;  // Detection range for player

    public GameObject Player;   // Reference to the player
    public NavMeshAgent _agent; // Reference to the NavMeshAgent

    private Animator animator;
    private float x, y;

    public float speed = 3;
    public float rotation = 20;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        // Distance to the target
        float distance = Vector3.Distance(Player.transform.position, transform.position);

        // If inside the lookRadius
        if (distance <= lookRadius)
        {
            if(distance <= 1.2)
            {
                animator.SetFloat("VelX", 0);
                animator.SetFloat("VelY", 2);

                _agent.isStopped = true;

                Player.GetComponent<CharacterController_Motor>().vida -= 1;
            }
            else
            {
                animator.SetFloat("VelX", 0);
                animator.SetFloat("VelY", 1);

                // Move towards the target
                _agent.isStopped = false;
                _agent.SetDestination(Player.transform.position);
            }
        }
        else
        {
            animator.SetFloat("VelX", 0);
            animator.SetFloat("VelY", 0);
        }


        //transform.Rotate(0, x * Time.deltaTime * rotation, 0);
        //transform.Translate(0, 0, y * Time.deltaTime * speed);

    }
}
