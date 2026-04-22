using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GenerateCoin : MonoBehaviour
{
    public GameObject[] coinPrefab;
    public GameObject[] badCoinPrefab;
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
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(2);
    }

    void ChosePrefab()
    {
        int randomValue = Random.Range(0, 11);
        switch (ParentFails)
        {
            
            case 0:
                ChosenPrefab = goodPrefab();

                break;
            case 1:
                
                if (randomValue <= 2)
                {
                    ChosenPrefab = badPrefab();
                }
                else
                {
                    ChosenPrefab = goodPrefab();
                }
                break;
            case 2:
                
                if (randomValue <= 4)
                {
                    ChosenPrefab = badPrefab();
                }
                else
                {
                    ChosenPrefab = goodPrefab();
                }
                break;
            case 3:
                
                if (randomValue <= 6)
                {
                    ChosenPrefab = badPrefab();
                }
                else
                {
                    ChosenPrefab = goodPrefab();
                }
                break;
            case 4:
                
                if (randomValue <= 8)
                {
                    ChosenPrefab = badPrefab();
                }
                else
                {
                    ChosenPrefab = goodPrefab();
                }
                break;
            case 5:
                ChosenPrefab = badPrefab();
                break;
        }
        if(ParentFails>5)
        {
            ParentFails = 5;
        }
        
    }

    GameObject goodPrefab()
    {
        int randomNum = Random.Range(0,3);
        return coinPrefab[randomNum];
    }

    GameObject badPrefab()
    {
        int randomNum = Random.Range(0, 3);
        return badCoinPrefab[randomNum];
    }
}
