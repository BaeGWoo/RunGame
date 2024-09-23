using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

   public void Excute()
    {
        StartCoroutine(SceneryManager.Instance.AsyncLoad(1));
    }

    public void Shop()
    {
        Debug.Log("Shop");
    }

    public void Quit()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();

#endif
    }


   
   

    public void OnMouseClick()
    {
        Debug.Log(gameObject.name);
    }
}
