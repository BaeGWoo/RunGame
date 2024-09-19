using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] float offset = 2.5f;
    [SerializeField] int createCount = 15;
    [SerializeField] GameObject coin;
    void Awake()
    {
        CreateCoin();
    }

    public void CreateCoin()
    {

        for(int i=0;i<createCount; i++)
        {
            
           
            coin=Instantiate(coin);

           coin.transform.SetParent(gameObject.transform);

            coin.transform.localPosition = new Vector3(0, 0, offset * i);
        }
    }
    
}
