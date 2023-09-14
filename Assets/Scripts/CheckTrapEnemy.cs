using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrapEnemy : MonoBehaviour
{
    public GameUnitEnemy GameUnitEnemy;
    private bool check = false;
    public void OnTriggerEnter(Collider other)
    {
        if (check)
        {
            return;
        }
        // Проверяем, есть ли у объекта, с которым произошло столкновение, тег "Trap"
        if (other.gameObject.CompareTag("Trap"))
        {
            Trap trap = null;
            check = true;
            if (other.TryGetComponent(out trap))
            {
                GU();
            }
            else if(other.transform.parent.TryGetComponent(out trap))
            {
                GU();
            }
            else
            {
                Transform par = other.transform.parent;
                for (int i = 0; i < par.childCount; i++)
                {
                    if(par.GetChild(i).TryGetComponent(out trap))
                    {
                        GU();
                    }
                }
            }

            void GU()
            {
                Debug.Log("а что говорить - хуй");
                GameUnitEnemy.TrapDieFunction(trap.trap_ID);  //запуск функции программы смерти.
            }

        }
    }
}
