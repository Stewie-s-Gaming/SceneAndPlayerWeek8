using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardingPlayer : StateMachineBehaviour
{
    [Tooltip("Minimum time to wait at target between running to the next target")]
    [SerializeField] private float minWaitAtTarget = 7f;

    [Tooltip("Maximum time to wait at target between running to the next target")]
    [SerializeField] private float maxWaitAtTarget = 15f;


    [Tooltip("A game object whose children have a Target component. Each child represents a target.")]
    private Target[] allTargets = null;

    [Header("For debugging")]
    [SerializeField] private Target currentTarget = null;
    [SerializeField] private float timeToWaitAtTarget = 0;

    private NavMeshAgent navMeshAgent;
    private Animator animators;
    private float rotationSpeed = 5f;
    private GameObject player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animators = animator;
        navMeshAgent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
        allTargets = GameObject.FindGameObjectWithTag("Targets").GetComponentsInChildren<Target>(false); // false = get components in active children only
        Debug.Log("Found " + allTargets.Length + " active targets.");
        SelectNewTarget();
    }

    private void SelectNewTarget()
    {
        float min = Vector3.Distance(player.transform.position, allTargets[0].transform.position);
        Target mostFarTarget = allTargets[0];
        foreach (var target in allTargets)
        {
            float tempMin = Vector3.Distance(player.transform.position, target.transform.position);
            if (min > tempMin)
            {
                min = tempMin;
                mostFarTarget = target;
            }
        }
        currentTarget = mostFarTarget;
        Debug.Log("New target: " + currentTarget.name);
        navMeshAgent.SetDestination(currentTarget.transform.position);
        //if (animator) animator.SetBool("Run", true);
        timeToWaitAtTarget = Random.Range(minWaitAtTarget, maxWaitAtTarget);
    }

    private bool currTargetIsClosest()
    {
        float min = Vector3.Distance(player.transform.position, allTargets[0].transform.position);
        Target mostFarTarget = allTargets[0];
        foreach (var target in allTargets)
        {
            float tempMin = Vector3.Distance(player.transform.position, target.transform.position);
            if (min > tempMin)
            {
                min = tempMin;
                mostFarTarget = target;
            }
        }
        return mostFarTarget.Equals(currentTarget);
    }

    private void checkIfSwitch()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animators.SetBool("isEscape", true);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            animators.SetBool("isChasePlayer", true);
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
        if (!currTargetIsClosest())
        {
            SelectNewTarget();
        }
        if (navMeshAgent.hasPath)
        {
            FaceDestination();
        }
    }
    private void FaceDestination()
    {
        Vector3 directionToDestination = (navMeshAgent.destination - animators.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToDestination.x, 0, directionToDestination.z));
        //transform.rotation = lookRotation; // Immediate rotation
        animators.transform.rotation = Quaternion.Slerp(animators.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed); // Gradual rotation
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animators.SetBool("isGuard", false);
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
