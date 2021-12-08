using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : StateMachineBehaviour
{
    [Tooltip("The object that this enemy chases after")]
    GameObject player = null;

    [Header("These fields are for display only")]
    [SerializeField] private Vector3 playerPosition;

    private Animator animators;
    private NavMeshAgent navMeshAgent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animators = animator;
        navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();
        animator = animator.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void checkIfSwitch()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animators.SetBool("isEscape", true);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            animators.SetBool("isGuard", true);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            animators.SetBool("isChaseEngine", true);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        checkIfSwitch();
        playerPosition = player.transform.position;
        float distanceToPlayer = Vector3.Distance(playerPosition, animator.transform.position);
        FacePlayer();
        navMeshAgent.SetDestination(playerPosition);
    }
    private void FacePlayer()
    {
        Vector3 direction = (playerPosition - animators.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // transform.rotation = lookRotation;
        animators.transform.rotation = Quaternion.Slerp(animators.transform.rotation, lookRotation, Time.deltaTime * 5);
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animators.SetBool("isChasePlayer", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
