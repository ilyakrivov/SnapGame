using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Trap
{

    //private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (isDead)
        {
            return;
        }
        if (checkTouch)
        {
            return; //если тач true то возвращаем
        }
        if (other.gameObject.CompareTag("Ally")) // если противник имеет тег "Ally"
        {
            CountMinus(); //запуск вычитания очков
        }
        if (other.gameObject.CompareTag("Enemy")) // если противник имеет тег "Enemy"
        {
            CountPlus(); //запуск прибавления очков         
        }
        if (other.gameObject.CompareTag("Ground")) //проверка соприкосновения ловушки запуск фх и таймер с запуском фх на уничтожение
        {
            time = true;
            checkTouch = true;
            rb.isKinematic = true;
            RocketMove();
        }
    }
    public override void RocketMove()
    {
        Vector3 position = transform.position;
        position.y -= 1.2f;
        transform.position = position;
    }
    // Update is called once per frame
}
