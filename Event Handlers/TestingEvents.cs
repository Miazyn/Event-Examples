using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEvents : MonoBehaviour
{
    //Type + name -> Usual naming of "On" + "What event does"
    public event EventHandler OnSpacePress;

    public event EventHandler<OnEnterPressArgs> OnEnterPressAttribute;
    public class OnEnterPressArgs : EventArgs
    {
        public int spaceCount;
    }

    private void Start()
    {
        //adding function
        OnSpacePress += Testing_OnSpacePress;

        OnEnterPressAttribute += EventHandler_Attributes;
    }

    private void EventHandler_Attributes(object sender, OnEnterPressArgs e)
    {
        Debug.Log("Space Count: " + e.spaceCount);
    }

    private int spaceCount = 1;
    //function needs the same parameters
    private void Testing_OnSpacePress(object sender, EventArgs e)
    {
        Debug.Log("Inside same Script call: Event Handler");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //-> Bad, since if nothing is subscribed will cause an error
            //OnSpacePress(this, EventArgs.Empty);

            //---> Better as it will look for sth being subscribed
            OnSpacePress?.Invoke(this, EventArgs.Empty);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            OnEnterPressAttribute?.Invoke(this, new OnEnterPressArgs { spaceCount = spaceCount });
        }
    }

}
