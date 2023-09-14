using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace AlexDHCorporation
{
	public class HunterAI : HumanAI
	{
		[SerializeField] private HumanAI target;
		[SerializeField] private float SearchRange = 10;
		[SerializeField] private float castIntervalSet = 1;
		[SerializeField] private LayerMask layerMask;
		
		[SerializeField] private string targetName = "Ally";
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] audioClips;
        [SerializeField] private Transform LookPoint;
        [SerializeField] private float AttackDistance = 2;
        private float _castInterval = 1;
        Vector3 tar;

        bool _isAttack = false;
        private protected override void BaseLogic()
		{
            if (target != null)
            {
                
                Move(target.transform.position);

                if (audioSource.isPlaying == false) audioSource.Play();

                if (Vector3.Distance(transform.position, target.transform.position) < AttackDistance)
                {
                    Attack();
                }
            }
            else
            {
                SimpleStateChange();
            }

            _castInterval -= Time.deltaTime;

            if (_castInterval <= 0 && target == null)
            {
                Debug.Log("1321");
                _castInterval = castIntervalSet;
                FindEnemy();
            }      
		}

        private void Attack()
        {
            if (_isAttack == true) return;
           
            target.Stop();
            audioSource.Stop();
            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
            _isAttack = true;
            
        }

        public void Hit()
        {
            target.Death();
            target = null;
            _isAttack = false;
        }

		private void FindEnemy()
		{

                HumanAI[] humanAIs = null;
                _collider.enabled = false;
                if (Cast.LoockOther(out humanAIs, transform.position, SearchRange, layerMask))
                {
                    _collider.enabled = true;
                    foreach (HumanAI human in humanAIs)
                    {
                        tar = human.transform.position;

                        if (Physics.Raycast(LookPoint.position, human.transform.position + Vector3.up - LookPoint.position, out RaycastHit hit, Mathf.Infinity))
                        {
                            Debug.Log(hit.collider.name);
                            if (hit.transform.TryGetComponent(out HumanAI aI))
                            {
                                Debug.Log(aI.Name);
                                if (human == aI && human.Name == targetName)
                                {
                                    target = human;
                                    break;
                                }
                            }
                        } 
                    }
                }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(LookPoint.position, tar + Vector3.up*0.5f);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, SearchRange);
        }

    }
}