using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountUI : MonoBehaviour
{
    [SerializeField] int NextLevel;
    [SerializeField] int MenuLevel;
    [SerializeField] int RestartLevel;
    [SerializeField] int WinCount;
    [SerializeField] int LoseCount;
    [SerializeField] float Timer;
    public Text Count;
    private bool fixadd = false;
    public GameObject winScreen;
    public GameObject loseScreen;

    private void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }
    void Update()
    {
        Timer -= Time.deltaTime; // вычитаем прошедшее время из переменной таймера
        if (Timer <= 0f)
        {
            loseScreen.SetActive(true);
            //ResetLevel(); // вызываем функцию ResetLevel, когда таймер достигнет нуля
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
        // Устанавливаем текст на основе значения переменной myInt
            Count.text = "Count: " + Trap.Count.ToString();
        if (Trap.Count >= WinCount)
        {
            winScreen.SetActive(true);
            int chapScore = PlayerPrefs.GetInt("ChapPoint");
            if (!fixadd)
            {
                chapScore += 1;
                fixadd = true;
            }
            PlayerPrefs.SetInt("ChapPoint", chapScore);
        }
    }
    public void NextLvl()
    {
        Application.LoadLevel(NextLevel);
    }
    public void BacktoMenu()
    {
        Application.LoadLevel(MenuLevel);
    }

    public void ResetLevel()
    {
        Application.LoadLevel(RestartLevel);
    }

    

}
