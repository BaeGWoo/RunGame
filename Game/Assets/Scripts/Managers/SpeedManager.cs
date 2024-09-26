using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class SpeedManager : State 
{
    [SerializeField] float basicSpeed;
    [SerializeField] float limitSpeed;
    [SerializeField] float increaseValue;

    private void Awake()
    {
        StartCoroutine(IncreaseSpeed());
    }

    private void Start()
    {
        basicSpeed = 25.0f;
        limitSpeed = 70.0f;
        increaseValue = 5.0f;
    }

    public float Speed
    {
        get { return basicSpeed; }
    }

    public IEnumerator IncreaseSpeed()
    {

        while (state&&basicSpeed < limitSpeed)
        {
            yield return CoroutineCashe.WaitForSecond(10);
            basicSpeed += increaseValue;
        }
    }
}
