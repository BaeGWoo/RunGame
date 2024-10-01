using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] GameObject obstacle;

    [SerializeField] int createCount=5;
    [SerializeField] int randomIndex;

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
                if (ExaminActive(obstacles))
                {
                    obstacle = ResourcesManager.Instance.Instantiate("Cone", gameObject.transform);

                    obstacle.SetActive(false);

                    obstacles.Add(obstacle);
                }

                // ���� �ε����� ������Ʈ�� Ȱ��ȭ �Ǿ��������
                randomIndex=(randomIndex+1)%obstacles.Count;
            }

            obstacles[(randomIndex)].SetActive(true);         
        }
    }

    private bool ExaminActive(List<GameObject> list)
    {    
        for(int i=0;i<list.Count;i++)
        {
            if (!list[i].activeSelf)
                return false;
        }
        return true;
    }

}
