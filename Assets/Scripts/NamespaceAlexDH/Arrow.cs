using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexDHCorporation
{
	public class Arrow : MonoBehaviour
	{
		[SerializeField] protected ParticleSystem onHitPS;
		[SerializeField] protected ParticleSystem onDestroyPS;
		[SerializeField] private Transform raypoint;

		private void Update()
		{
			MainLogic();
        }

		protected virtual void MainLogic()
		{

		}






	}
}