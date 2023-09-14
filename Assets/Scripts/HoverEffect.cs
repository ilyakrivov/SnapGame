using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    [SerializeField] private float hoverHeight = 1.0f; // высота подъема объекта
    [SerializeField] private float hoverSpeed = 1.0f; // скорость подъема объекта
    [SerializeField] float maxY;

    private bool isHovering = false; // флаг, указывающий, наведен ли курсор на объект
    private Vector3 originalPosition; // изначальная позиция объекта

    private void Start()
    {
        originalPosition = transform.position; // сохраняем изначальную позицию объекта
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
            float newY = Mathf.Lerp(transform.position.y, originalPosition.y + hoverHeight, Time.deltaTime * hoverSpeed); // вычисляем новую позицию объекта по оси Y
            if(newY <= maxY)
            {
                transform.position = new Vector3(transform.position.x, newY, transform.position.z); // обновляем позицию объекта
            }
            
        }
        else
        {
            float newY = Mathf.Lerp(transform.position.y, originalPosition.y, Time.deltaTime * hoverSpeed); // вычисляем новую позицию объекта по оси Y
            transform.position = new Vector3(transform.position.x, newY, transform.position.z); // обновляем позицию объекта
        }
    }
}