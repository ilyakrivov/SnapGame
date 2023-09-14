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
            return; //���� ��� true �� ����������
        }
        if (other.gameObject.CompareTag("Ally")) // ���� ��������� ����� ��� "Ally"
        {
            CountMinus(); //������ ��������� �����
        }
        if (other.gameObject.CompareTag("Enemy")) // ���� ��������� ����� ��� "Enemy"
        {
            CountPlus(); //������ ����������� �����         
        }
        if (other.gameObject.CompareTag("Ground")) //�������� ��������������� ������� ������ �� � ������ � �������� �� �� �����������
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
