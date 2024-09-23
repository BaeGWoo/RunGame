using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] float offset = 2.5f;
    [SerializeField] int createCount = 15;
    [SerializeField] GameObject coin;
    [SerializeField] List<GameObject> coinList;
    void Awake()
    {
        coinList.Capacity = 20;
        CreateCoin();

    }

    public void CreateCoin()
    {

        for(int i=0;i<createCount; i++)
        {
            
           
            coin=Instantiate(coin);

           coin.transform.SetParent(gameObject.transform);

            coin.transform.localPosition = new Vector3(0, 0, offset * i);

            int index = coin.name.IndexOf("(Clone)");
            if (index > 0)
            {
                coin.name=coin.name.Substring(0, index);
            }

            coin.GetComponent<MeshRenderer>().enabled=false;
            coinList.Add(coin);
        }
    }


    public void InitializePosition()
    {
        float randomPosition = Random.Range(-1, 2) * 3.5f;
        for (int i = 0; i < coinList.Count; i++)
        {           
            Vector3 newPosition = new Vector3(randomPosition, 0, coinList[i].transform.position.z);
            coinList[i].transform.position = newPosition;
            
            

            if (!coinList[i].GetComponent<MeshRenderer>().enabled)
            {
                coinList[i].GetComponent<MeshRenderer>().enabled = true;
                coinList[i].transform.Find("Holy hit").gameObject.SetActive(false);
            }
        }


    }
    
}
