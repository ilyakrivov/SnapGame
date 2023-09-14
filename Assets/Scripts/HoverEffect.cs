using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    [SerializeField] private float hoverHeight = 1.0f; // ������ ������� �������
    [SerializeField] private float hoverSpeed = 1.0f; // �������� ������� �������
    [SerializeField] float maxY;

    private bool isHovering = false; // ����, �����������, ������� �� ������ �� ������
    private Vector3 originalPosition; // ����������� ������� �������

    private void Start()
    {
        originalPosition = transform.position; // ��������� ����������� ������� �������
    }

    private void OnMouseEnter()
    {
        isHovering = true;
    }

    private void OnMouseExit()
    {
        isHovering = false;
    }

    private void Update()
    {
        if (isHovering)
        {
            float newY = Mathf.Lerp(transform.position.y, originalPosition.y + hoverHeight, Time.deltaTime * hoverSpeed); // ��������� ����� ������� ������� �� ��� Y
            if(newY <= maxY)
            {
                transform.position = new Vector3(transform.position.x, newY, transform.position.z); // ��������� ������� �������
            }
            
        }
        else
        {
            float newY = Mathf.Lerp(transform.position.y, originalPosition.y, Time.deltaTime * hoverSpeed); // ��������� ����� ������� ������� �� ��� Y
            transform.position = new Vector3(transform.position.x, newY, transform.position.z); // ��������� ������� �������
        }
    }
}