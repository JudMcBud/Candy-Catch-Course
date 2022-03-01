using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
	
	[SerializeField]
	float maxX;
	[SerializeField]
	float spawnInterval;
	[SerializeField]
	GameObject[] candies;
	
	public static CandySpawner instance;
	
	void Awake()
	{
		if(instance ==  null)
		{
			instance = this;
		}
	}
	
    // Start is called before the first frame update
    void Start()
	{
		StartSpawningCandies();
    }

    // Update is called once per frame
    void Update()
	{
    	
    }
    
	void SpawnCandy()
	{
		int rand = Random.Range(0, candies.Length);
		
		float randPos = Random.Range(-maxX, maxX);
		
		Vector3 spawnBounds = new Vector3(randPos, transform.position.y, transform.position.z);
		
		Instantiate(candies[rand], spawnBounds, transform.rotation);
	}
	
	IEnumerator SpawnCandies()
	{
		yield return new WaitForSeconds(1.5f);
		
		while(true)
		{
			SpawnCandy();
			
			yield return new WaitForSeconds(spawnInterval);
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
