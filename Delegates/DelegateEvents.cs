using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateEvents : MonoBehaviour
{

    public event TestEventDelegate OnFloatEvent;
    public delegate void TestEventDelegate(float f);

    public delegate Action<bool> OnActionEvent;

    private void Start()
    {
        OnFloatEvent += DelegateEvents_OnFloatEvent;
        OnActionEvent += ActionEvent_Testing;
    }

    private void ActionEvent_Testing(bool arg)
    {
        Debug.Log("Es ist: " + arg);
    }

    private void DelegateEvents_OnFloatEvent(float f)
    {
        Debug.Log("My Delegate float is : " + f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnFloatEvent?.Invoke(2f);
            OnActionEvent?.Invoke(true);
        }
    }
}
