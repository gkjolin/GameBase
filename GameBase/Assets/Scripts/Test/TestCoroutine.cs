using UnityEngine;
using System.Collections;
using DG.Tweening;
public class TestCoroutine : MonoBehaviour
{

    private bool isStartCall = true;  //Makesure Update() and LateUpdate() Log only once
    private bool isUpdateCall = true;
    private bool isLateUpdateCall = true;
    // Use this for initialization
    void Start()
    {
        if (!isStartCall)
        {
            Debug.Log("Start Call Begin");
            StartCoroutine(StartCoutine());
            Debug.Log("Start Call End");
            isStartCall = true;
        }

    }
    IEnumerator StartCoutine()
    {

        Debug.Log("This is Start Coroutine Call Before");
        yield return null;
        Debug.Log("This is Start Coroutine Call After");

    }
    // Update is called once per frame
    void Update()
    {
        if (!isUpdateCall)
        {
            Debug.Log("Update Call Begin");
            StartCoroutine(UpdateCoutine());
            Debug.Log("Update Call End");
            isUpdateCall = true;
            //this.enabled = false;
            //this.gameObject.SetActive(false);
        }
    }
    IEnumerator UpdateCoutine()
    {
        Debug.Log("This is Update Coroutine Call Before");
        yield return null;
        Debug.Log("This is Update Coroutine Call After");
        yield return null;
        Debug.Log("This is Update Coroutine Call Second");
        /*yield return new WaitForEndOfFrame();//after all of the rendering and GUI is complete
        yield return new WaitForFixedUpdate();*/ // after all physics is calculated
    }
    void LateUpdate()
    {
        if (!isLateUpdateCall)
        {
            //Debug.Log("LateUpdate Call Begin");
            StartCoroutine(LateCoutine());
            //Debug.Log("LateUpdate Call End");
            isLateUpdateCall = true;

        }
    }
    IEnumerator LateCoutine()
    {
        //Debug.Log("This is Late Coroutine Call Before");
        yield return null;
        //Debug.Log("This is Late Coroutine Call After");
        TestVpTimer();
    }

    private void TestVpTimer()
    {
        //vp_Timer.In(5,CallBack);
        //GlobalData.Instance.Delay(5, CallBack);
        //vp_Timer.In()
    }

    private void CallBack()
    {
        Debug.Log("vp timer call back");
    }
}
