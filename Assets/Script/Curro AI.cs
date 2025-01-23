using UnityEngine;
using UnityEngine.AI;

public class CurroAI : MonoBehaviour
{
	public NavMeshAgent agent;

	public Transform player;

	public LayerMask whatIsGround, whatIsPlayer;

	//Patrol
	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;

	//States
	public float sightRange, attackRange;
	public bool playerInSightRange, playerInAttackRange;


	private void Awake()
	{
		player = GameObject.Find("Manuel").transform;
		agent = GetCompone;
	}
	private void Patroling()
	{

	}
	private void Patroling()
	{

	}
}

