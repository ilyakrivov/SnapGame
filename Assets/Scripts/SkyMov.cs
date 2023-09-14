using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMov : MonoBehaviour
{
    public float speed = 0.01f; // �������� ��������
    public Material skyMaterial;

    void Start()
    {
        skyMaterial = RenderSettings.skybox; // �������� �������� ���������
    }

    void Update()
    {
        float offset = Time.time * speed; // ������ �������� ��������
        skyMaterial.SetFloat("_Rotation", offset); // ������ �������� �������� ��������� � ���������
    }
}