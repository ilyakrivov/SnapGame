using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMov : MonoBehaviour
{
    public float speed = 0.01f; // скорость движения
    public Material skyMaterial;

    void Start()
    {
        skyMaterial = RenderSettings.skybox; // получаем материал скайбокса
    }

    void Update()
    {
        float offset = Time.time * speed; // расчет смещения текстуры
        skyMaterial.SetFloat("_Rotation", offset); // задаем смещение текстуры скайбокса в материале
    }
}