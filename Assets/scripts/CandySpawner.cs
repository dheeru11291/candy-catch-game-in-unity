using System.Collections;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] float maxX;
    [SerializeField] GameObject[] candies;
    [SerializeField] float SpawnInterval;

    public static CandySpawner Instance;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        StartSpawningCandies();
    }
    void SpawnCandy()
    {
        int random=Random.Range(0,candies.Length);
        //Instantiate(candies[random],transform.position,transform.rotation);

        float randomX=Random.Range(-maxX,maxX);
        Vector3 randomPos=new Vector3(randomX,transform.position.y,transform.position.z);
        Instantiate(candies[random], randomPos,transform.rotation);
    }
    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }
    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
