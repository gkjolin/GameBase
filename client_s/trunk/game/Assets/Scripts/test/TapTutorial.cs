using UnityEngine;
using System.Collections;

public class TapTutorial : MonoBehaviour
{

    void OnTap(TapGesture gesture)
    {
        Debug.Log("Tap gesture detected at" + gesture.Position + ".It was sent by" + gesture.Recognizer.name);
    }
}
