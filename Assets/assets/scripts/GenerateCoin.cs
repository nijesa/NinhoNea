using UnityEngine;
using System.Collections;

public class GenerateCoin : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject badCoinPrefab;
    GameObject ChosenPrefab;
    public int ParentFails=3;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float spawnDuration = 10f;
    [SerializeField] GameObject InvisiWall;

    void Start()
    {
        StartCoroutine(SpawnCoinsForDuration());
    }

    IEnumerator SpawnCoinsForDuration()
    {
        float elapsedTime = 0f;

        while (elapsedTime < spawnDuration)
        {
            ChosePrefab();
            Instantiate(ChosenPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
            elapsedTime += spawnInterval;
        }
        InvisiWall.SetActive(false);
    }

    void ChosePrefab()
    {
        int randomValue = Random.Range(0, 11);
        switch (ParentFails)
        {
            
            case 0:
                ChosenPrefab = coinPrefab;

                break;
            case 1:
                
                if (randomValue <= 2)
                {
                    ChosenPrefab = badCoinPrefab;
                }
                else
                {
                    ChosenPrefab = coinPrefab;
                }
                break;
            case 2:
                
                if (randomValue <= 4)
                {
                    ChosenPrefab = badCoinPrefab;
                }
                else
                {
                    ChosenPrefab = coinPrefab;
                }
                break;
            case 3:
                
                if (randomValue <= 6)
                {
                    ChosenPrefab = badCoinPrefab;
                }
                else
                {
                    ChosenPrefab = coinPrefab;
                }
                break;
            case 4:
                
                if (randomValue <= 8)
                {
                    ChosenPrefab = badCoinPrefab;
                }
                else
                {
                    ChosenPrefab = coinPrefab;
                }
                break;
            case 5:
                ChosenPrefab = badCoinPrefab;
                break;
        }
        if(ParentFails>5)
        {
            ParentFails = 5;
        }
        
    }
}
