using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateAsFunction : MonoBehaviour
{

    //-> DELEGATES are similar to drawers. They have functions inside them.
    public delegate void TestDelegate();

    public delegate bool TestBoolDelegate(int i);

    private TestDelegate testDelegateFunction;
    private TestBoolDelegate testBoolDelegateFunction;

    private void Start()
    {
        //One is set and + adds a new function
        testDelegateFunction = MyTestDelegateFunction;
        //WRITTEN OUT:::
        // testDelegateFunction = new TestDelegate(MyTestDelegateFunction);

        //Delegate with return value
        testDelegateFunction += MySecondTestDelegateFunction;

        //Can be called like a function
        //Both functions will be called
        testDelegateFunction();

        testBoolDelegateFunction = MyTestBoolDelegateFunction;
        Debug.Log(testBoolDelegateFunction(1));


        //ANONYMOUS METHOD: Same parameters as function.
        //Function inline
        testDelegateFunction = delegate () { Debug.Log("Anonymous method"); };
        //2nd way: VERY COMPACT
        testDelegateFunction = () => { Debug.Log("Lambda expression"); };
        testBoolDelegateFunction = (int i) => { return i < 5; };
        //Even more compact when you have just one thingy:
        testBoolDelegateFunction = (int i) => i < 5;
    }

    private void MyTestDelegateFunction()
    {
        Debug.Log("MyTestDelegateFunction");
    }
    private void MySecondTestDelegateFunction()
    {
        Debug.Log("MySecondTestDelegateFunction");
    }

    //int can be named different and it will still run
    private bool MyTestBoolDelegateFunction(int i)
    {
        return i < 5;
    }
}
