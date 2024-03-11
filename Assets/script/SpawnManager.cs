using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;

    public float mintime = 1.5f;
    public float maxtime = 2.5f;
        
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoRutine(0));
    }

    // Update is called once per frame
    IEnumerator SpawnCoRutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], transform.position, Quaternion.identity);
        StartCoroutine(SpawnCoRutine(Random.Range(mintime, maxtime)));    
    }

}
