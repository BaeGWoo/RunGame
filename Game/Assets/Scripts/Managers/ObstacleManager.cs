using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] GameObject obstacle;

    [SerializeField] int createCount=5;

    private void Awake()
    {
        obstacles.Capacity = 10;
    }

    private void Start()
    {
        Create();
    }

    public void Create()
    {
        for(int i = 0; i < createCount; i++)
        {
            obstacle = ResourcesManager.Instance.Instantiate("Cone",gameObject.transform);

            obstacle.SetActive(false);

            obstacles.Add(obstacle);
        }
    }


}
