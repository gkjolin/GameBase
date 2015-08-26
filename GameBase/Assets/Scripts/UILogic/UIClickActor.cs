using UnityEngine;
using System.Collections;
public class UIClickActor : MonoBehaviour
{

    void Start()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }

    private void CheckRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.DrawLine(ray.origin, hitInfo.point);
            Debug.Log(hitInfo.collider.gameObject.name);
        }
    }
}
