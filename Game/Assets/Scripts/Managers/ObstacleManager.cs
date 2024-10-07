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
                // �迭 �� ��� ������Ʈ�� Ȱ��ȭ �Ǿ����� ���
                if (ExaminActive())
                {
                    obstacle = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);

                    obstacle.SetActive(false);

                    obstacles.Add(obstacle);
                }

                // ���� �ε����� ������Ʈ�� Ȱ��ȭ �Ǿ��������
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
