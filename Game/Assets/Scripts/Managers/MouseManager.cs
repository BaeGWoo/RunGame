using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : Singleton<MouseManager>
{
    [SerializeField] Texture2D texture2D;

    void Start()
    {
        texture2D = ResourcesManager.Instance.Load<Texture2D>("Default");

        Cursor.SetCursor(texture2D,Vector2.zero,CursorMode.Auto);    
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        State(scene.buildIndex);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void State(int state)
    {
        switch (state)
        {
            case 0:
                Cursor.visible = true;              
            break;


            case 1:
                Cursor.visible = false;
                break;
        }
    }

}
