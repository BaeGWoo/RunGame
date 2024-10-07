using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstaclePositionManager : MonoBehaviour
{

    [SerializeField] Transform[] parents;
    [SerializeField] Transform[] positionX;
    [SerializeField] bool state = false;
    [SerializeField] int count = -1;
    [SerializeField] float[] randomPositionZ = new float[16];
    [SerializeField] ObstacleManager obstacleManager;

    private void Awake()
    {
        for (int i = 0; i < randomPositionZ.Length; i++)
        {
            randomPositionZ[i] = i * 2.5f + - 10.0f;
        }
    }

   

    private void Start()
    {
        StartCoroutine(SetRandomPosition());
    }

    public void SetObstaclePosition()
    {
        state = true;

        count = (count + 1) % parents.Length;
        
        
        transform.SetParent(parents[count]);
        transform.localPosition += new Vector3(0, 0, 40);

    }

    IEnumerator SetRandomPosition()
    {
        while (true)
        {
            yield return CoroutineCashe.WaitForSecond(2.5f);

            //transform.position = parents[count].localPosition;
            transform.localPosition = new Vector3(0, 0, randomPositionZ[Random.Range(0, randomPositionZ.Length)]);

            if (state)
            {
                obstacleManager.GetObstacle().SetActive(true);

                obstacleManager.GetObstacle().transform.position = transform.localPosition;

                obstacleManager.GetObstacle().transform.position = positionX[Random.Range(0, positionX.Length)].position;


                obstacleManager.GetObstacle().transform.SetParent(transform.root.GetChild(count));
                
            }
        }

       
    }

}
