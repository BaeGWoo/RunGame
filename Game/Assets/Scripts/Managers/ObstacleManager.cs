using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] GameObject obstacle;

    [SerializeField] int createCount=5;
    [SerializeField] int randomIndex=0;


    private void Awake()
    {
        obstacles.Capacity = 10;
    }

    private void Start()
    {
       
        Create();
        StartCoroutine(Activate());
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

    IEnumerator Activate()
    {
        while (true)
        {
            
            yield return CoroutineCashe.WaitForSecond(2.5f);
            
            randomIndex=Random.Range(0,obstacles.Count);

            while (obstacles[randomIndex].activeSelf)
            {
                // 배열 내 모든 오브젝트가 활성화 되어있을 경우
                if (ExaminActive())
                {
                    obstacle = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);

                    obstacle.SetActive(false);

                    obstacles.Add(obstacle);
                }

                // 현재 인덱스의 오브젝트가 활성화 되어있을경우
                randomIndex=(randomIndex+1)%obstacles.Count;
            }

           
                     
        }
    }

    private bool ExaminActive()
    {    
        for(int i=0;i< obstacles.Count;i++)
        {
            if (!obstacles[i].activeSelf)
                return false;
        }
        return true;
    }


    public GameObject GetObstacle()
    {
        return obstacles[(randomIndex)];
    }
}
