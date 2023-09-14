using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorEventsListener : MonoBehaviour
{
    public UnityEvent<string> Event;

    public void Call(string key)
    {
        //Debug.Log(key);
        Event?.Invoke(key);
    }
}