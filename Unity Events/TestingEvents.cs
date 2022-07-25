using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestingEvents : MonoBehaviour
{
    public UnityEvent OnUnityEvent;

    //Makes Field in Unity Pop up
    //Like Buttons Event, so click & Drop

    private void Update()
    {
        OnUnityEvent?.Invoke();
    }

}
