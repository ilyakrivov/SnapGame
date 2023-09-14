using UnityEngine;

public class SpriteAnim : MonoBehaviour
{
    // Переменные для хранения текущей позиции, поворота и размера объекта
    private Vector3 scale;

    // Переменные для задания скорости вращения, изменения размера и максимального диапазона изменения размера
    public float scaleSpeed = 0.3f;
    private int scaleDirection = 1;
    [SerializeField] float maxScale = 2.0f;
    [SerializeField] float minScale = 1.0f;
    

    void Start()
    {
        // Получение начальных значений позиции, поворота и размера объекта
        scale = transform.localScale;
    }

    void Update()
    {

        // Обновление изменения размера объекта с использованием заданной скорости и направления изменения размера
        scale += scaleDirection * scaleSpeed * Time.deltaTime * Vector3.one;

        // Изменение направления изменения размера, если достигнут максимальный или минимальный диапазон
        if (scale.x > maxScale || scale.x < minScale)
        {
            scaleDirection = -scaleDirection;
        }

        // Установка обновленного размера объекта
        transform.localScale = scale;
    }
}