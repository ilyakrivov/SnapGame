using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Play")
                {
                    Application.LoadLevel(1);
                }
                if (hit.collider.gameObject.tag == "Setting")
                {
                    Debug.Log("Запуск настроек");
                }
                if (hit.collider.gameObject.tag == "Exit")
                {
                    Debug.Log("Выход");
                }

            }
        }

    }

}
