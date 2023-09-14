using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : MonoBehaviour
{
    public string title;
    public string description;
    [SerializeField] public string Chap_;
    public List<Episode> episodes;
/*
    public Chapter(string title, string description)
    {
        this.title = title;
        this.description = description;
        episodes = new List<Episode>();
    }

    public void SetNextEpisodes()
    {
        for (int i = 0; i < episodes.Count - 1; i++)
        {
            episodes[i].nextEpisode = episodes[i + 1].isUnlocked ? episodes[i + 1] : null;
        }
    } */
}
