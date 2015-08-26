using UnityEngine;
using System.Collections;
using Game;
public class TestEasyButton : MonoBehaviour
{
    //本地磁盘assetbundle -> www.load -> assetbundle 镜像 -> assetbundle.load-> gameobject ->gameobject instantiate 
    //                                                              |> assetbundle.unload();                      resourses.unloadAsset()                                      |> GameObject.Destroy

    private ETCButton _button;
    void Start()
    {
        _button = gameObject.GetComponent<ETCButton>();
        _button.onDown.AddListener(OnButton);
        
    }

    private void OnButton()
    {
        GameInput.Instance.EasyButton();
    }

}
