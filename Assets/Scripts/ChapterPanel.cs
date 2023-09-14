using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterPanel : MonoBehaviour
{
    public GameObject ChapScreen;
    public GameObject EpisodeScreen; //тут нужно выставлять конкретный экран главы, где находятся эпизоды
    // Start is called before the first frame update
    void Start()
    {
        ChapScreen.SetActive(true);
        EpisodeScreen.SetActive(false);
    }

    // Update is called once per frame
    public void OpenEp()
    {
        ChapScreen.SetActive(false);
        EpisodeScreen.SetActive(true);
    }
}
