using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePositionManager : MonoBehaviour
{

    [SerializeField] Transform []  parents;
    [SerializeField] int count=-1;
    [SerializeField] float[] randomPositionZ = new float[16]; 

    private void Awake()
    {
       for(int i = 0; i < randomPositionZ.Length; i++)
        {
            randomPositionZ[i] = ((float)i * 2.5f) - 10.0f;
        }
    }

    private void Start()
    {
        StartCoroutine(SetRandomPosition());
    }

    public void SetObstaclePosition()
    {
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
            transform.position = new Vector3(0, 0, randomPositionZ[Random.Range(0, randomPositionZ.Length)]);

        }

       
    }

}
