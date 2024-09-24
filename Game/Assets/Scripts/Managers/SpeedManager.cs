using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] float basicSpeed;
    [SerializeField] float limitSpeed;
    [SerializeField] float increaseValue;
    [SerializeField] float increaseTime;

    WaitForSeconds waitForSeconds=new WaitForSeconds(10);

    public static SpeedManager Instance;

    private void Awake()
    {
        basicSpeed = 25.0f;
        limitSpeed = 70.0f;
        increaseValue = 5.0f;
        increaseTime = 10.0f;
        Instance = this;
    }

    public float Speed
    {
        get { return basicSpeed; }
    }

    public IEnumerator IncreaseSpeed()
    {
        
        while (basicSpeed < limitSpeed)
        {
            yield return CoroutineCashe.WaitForSecond(10);
            basicSpeed += increaseValue;
        }
    }
}
