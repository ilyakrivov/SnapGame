using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    public List<GameObject> objectsToInstantiate;  // ������ ����������� 

    [SerializeField] private float moveSpeed = 20f; // �������� �������� ������

    [SerializeField] private float zoomSpeed = 50f; // �������� ����

    [SerializeField] private float minZoom = 10f; // ����������� �������� ����

    [SerializeField] private float maxZoom = 80f; // ������������ �������� ����

    [SerializeField] private float maxX = 110f;

    [SerializeField] private float minX = -110f;

    [SerializeField] private float maxZ = 110f;

    [SerializeField] private float minZ = -110f;

    [SerializeField] int trapCount; // ���������� ������� �� �������

    public Text trapCountTxt;

    Camera Camera;

    private int index;

    void ClampCameraPosition(float minX, float maxX, float minZ, float maxZ)
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;
    }

    public void ind0()
    {
        index = 0;
    }

    public void ind1()
    {
        index = 1;
    }
    public void ind2()
    {
        index = 2;
    }
    public void ind3()
    {
        index = 3;
    }
    public void ind4()
    {
        index = 4;
    }
    public void ind5()
    {
        index = 5;
    }
    public void ind6()
    {
        index = 6;
    }
    public void ind7()
    {
        index = 7;
    }
    public void ind8()
    {
        index = 8;
    }
    public void ind9()
    {
        index = 9;
    }

    private void Update()
    {
        //Debug.Log(Trap.Count);
        // ������������ �������� ������ �� ���� X � Z
        var x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        var z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(x, 0, z);

        trapCountTxt.text = "Traps left: " + trapCount.ToString();

        // ���������� ������� ������ � �������� ��������
        ClampCameraPosition(minX, maxX, minZ, maxZ);

        //transform.Translate(x, 0, z, Space.World); // ������� ������ ������������ ������� ����������

        // ������������ ��� ������ � ������� �������� ����
        var zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        var newPosition = transform.position + transform.forward * zoom;
        newPosition.y = Mathf.Clamp(newPosition.y, minZoom, maxZoom); // ������������ ���
        transform.position = newPosition;
        //���� ����� ��� ������ ���������� 

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            index = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            index = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            index = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            index = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            index = 8;
        }
        // ������ ���������
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Ground" && trapCount > 0)
                {
                    Instantiate(objectsToInstantiate[index], hit.point, Quaternion.identity);
                    trapControll();
                }

            }
        }

    }
    private void trapControll()
    {
        trapCount-=1;
    }
}

