using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
    move,
    attack
}
public class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    public State state;
    public int damage;
    public float speed;
    public float attackRate;
    GameObject target;
    NavMeshAgent agent;
    void Start()
    {
        target = FindObjectOfType<PlayerOnGround>().gameObject;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;   
    }
    void Update()
    {
        if(state == State.move)
        {
            animator.SetBool("AttackRange",false); 
            agent.speed = speed;
        }
        else if(state == State.attack)
        {
            animator.SetBool("AttackRange",true); 
            agent.speed = 0;
        }
        var distance = Vector3.Distance(transform.position,target.transform.position);
        agent.destination = target.transform.position; 
        if(distance > 2) 
        {
            state = State.move;
        }
        else
        {
            state = State.attack;
        }
    }
    public void AnimationController()
    {
        
    }
}
