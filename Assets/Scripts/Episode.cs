using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Episode : MonoBehaviour
{
    
   [SerializeField] string title;
   [SerializeField] int needPoint;
   [SerializeField] int Openlevel;
   [SerializeField] Button btn;
   private int chapPoint;

    private void Start()
    {
        btn = GetComponent<Button>();
        int chapPoint = PlayerPrefs.GetInt("ChapPoint");
        Debug.Log(chapPoint);
        if (chapPoint >= needPoint)
        {
            btn.interactable = true;
            
        }
        else
        {
            btn.interactable = false;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void NextEp()
    {
        if (needPoint >= chapPoint)
        {
            Application.LoadLevel(Openlevel);
        }
        else
        {

        }

    }
}

