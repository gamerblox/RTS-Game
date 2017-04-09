using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RightClickNavigation : Interaction{

    public float RelaxDistance = 5;

    private NavMeshAgent agent;
    private Vector3 target = Vector3.zero;
    private bool selected = false;
    private bool isActive = false;

    public override void Deselect()
    {
        selected = false;

    }

    public override void Select()
    {
        selected = true;

    }

    public void SendToTarget()
    {
        agent.SetDestination(target);
        agent.isStopped = false;
        isActive = true;

    }

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

	}
	
	void Update ()
    {
		if (selected && Input.GetMouseButtonDown(1))
        {
            var temp_target = RtsManager.Current.ScreenPointToMapPosition(Input.mousePosition);
            if (temp_target.HasValue)
            {
                target = temp_target.Value;
                SendToTarget();

            }

        }

        if (isActive && Vector3.Distance(target, transform.position) < RelaxDistance)
        {
            agent.isStopped = false;
            isActive = false;

        }

	}

}
