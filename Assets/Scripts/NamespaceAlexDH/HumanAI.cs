using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace AlexDHCorporation
{
	public class HumanAI : MonoBehaviour
	{
        [SerializeField] private NavMeshAgent agent;
        public Collider _collider;
        [SerializeField] protected Animator animator;
        public Rigidbody root;
        public Rigidbody[] Ragdoll;
        public string Name;
        [SerializeField] private int RewardCount;
        [SerializeField] private float TimeToChangeState = 0;
        [SerializeField] private float FindWayRadius = 10;
        private Vector3 Waypoint;


        private float _timeToChangeState = 1;
        private bool changeState = false;
        protected bool destinationReady = false;

        private bool isDead = false;

        private void Start()
        {
            animator.SetFloat("offset", Random.Range(0.0f, 1.0f));
        }

        private void Update()
        {
            if(isDead == false) BaseLogic();
        }

        private protected virtual void BaseLogic()
        {
            SimpleStateChange(); 
        }

        private protected void SimpleStateChange()
        {
            _timeToChangeState -= Time.deltaTime;


            if (_timeToChangeState <= 0 || destinationReady == true)
            {

                changeState = !changeState;
                destinationReady = false;


                if(changeState == true)
                {
                    _timeToChangeState = Random.Range(TimeToChangeState / 2, TimeToChangeState*2);
                }
                else
                {
                    _timeToChangeState = Random.Range(0, TimeToChangeState / 2);
                    Waypoint = Vector3.zero;
                }
            }

            if (changeState == true)
            {
                Move(Waypoint);
            }
            else
            {
                Idle();
            }
        }

        protected void Move(Vector3 destination)
        {
            agent.isStopped = false;

            if(agent.destination != destination)
            {
                agent.SetDestination(destination);
            }

            if(agent.pathPending == false && agent.transform.position == agent.pathEndPosition)
            {
                destinationReady = true;
            }

            if(Vector3.Distance(agent.transform.position, agent.pathEndPosition) > 0.1f)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }


        }

        protected void Idle()
        {
            agent.isStopped = true;
            animator.SetBool("Walk", false); 
            FindWay();
        }

        private protected Vector3 FindWay()
        {
            if(Waypoint == Vector3.zero)
            { 
                Vector2 r =  Random.insideUnitCircle * Random.Range(FindWayRadius/2, FindWayRadius*2);
                Waypoint = new Vector3(r.x, 0, r.y) + transform.position;
            }
            return Waypoint;
        }

        public void Death()
        {
            
            animator.enabled = false;
            _collider.enabled = false;
            Destroy(gameObject, 10);
        }

        public void Stop()
        {
            isDead = true;
            agent.isStopped = true;
        }


    }
}