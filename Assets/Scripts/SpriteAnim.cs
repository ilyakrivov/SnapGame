using UnityEngine;

public class SpriteAnim : MonoBehaviour
{
    // ���������� ��� �������� ������� �������, �������� � ������� �������
    private Vector3 scale;

    // ���������� ��� ������� �������� ��������, ��������� ������� � ������������� ��������� ��������� �������
    public float scaleSpeed = 0.3f;
    private int scaleDirection = 1;
    [SerializeField] float maxScale = 2.0f;
    [SerializeField] float minScale = 1.0f;
    

    void Start()
    {
        // ��������� ��������� �������� �������, �������� � ������� �������
        scale = transform.localScale;
    }

    void Update()
    {

        // ���������� ��������� ������� ������� � �������������� �������� �������� � ����������� ��������� �������
        scale += scaleDirection * scaleSpeed * Time.deltaTime * Vector3.one;

        // ��������� ����������� ��������� �������, ���� ��������� ������������ ��� ����������� ��������
        if (scale.x > maxScale || scale.x < minScale)
        {
            scaleDirection = -scaleDirection;
        }

        // ��������� ������������ ������� �������
        transform.localScale = scale;
    }
}