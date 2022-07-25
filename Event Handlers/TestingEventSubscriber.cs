using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour
{
    public TestingEvents testingEvents;
    private void Start()
    {
        testingEvents = GetComponent<TestingEvents>();

        testingEvents.OnSpacePress += TestingEvents_OnSpacePress;
    }

    private void TestingEvents_OnSpacePress(object sender, EventArgs e)
    {
        Debug.Log("Call from other script! : Event Handler");
    }

    private void OnDestroy()
    {
        //Unsubscribed when dead, so no dead listeners here
        testingEvents.OnSpacePress -= TestingEvents_OnSpacePress;
    }
}
