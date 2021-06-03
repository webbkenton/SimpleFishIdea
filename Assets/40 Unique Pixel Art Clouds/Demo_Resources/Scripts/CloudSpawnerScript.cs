using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///using UnityEngine.Experimental.PlayerLoop;

public class CloudSpawnerScript : MonoBehaviour {

	public float timeInterval;
	public GameObject cloudPrefab;
	public float speed;
	
	private float timer;
	private Sprite[] cloudSprites;

	void Start () {
		cloudSprites = Resources.LoadAll<Sprite>("Clouds");
		// Spawn our initial clouds
		spawnCloud(new Vector3(-4, 2, 0));
		spawnCloud(new Vector3(2, 3, 0));
		spawnCloud(new Vector3(8, 3, 0));
	}
	
	
	void Update () {
		timer += Time.deltaTime;
		if (timer > timeInterval) {
			timer = 0;
			spawnCloud();
		}
	}

	void spawnCloud() {
		var heightOffset = new Vector3(0, Random.Range(-2, 2), 0);
		var newCloud = Instantiate(cloudPrefab, transform.position + heightOffset, Quaternion.identity);
		newCloud.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, -2) * speed, 0));
		newCloud.GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(0, cloudSprites.Length)];
	}

	void spawnCloud(Vector3 position) {
		var newCloud = Instantiate(cloudPrefab, position, Quaternion.identity);
		newCloud.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, -2) * speed, 0));
		newCloud.GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(0, cloudSprites.Length)];
	}
}
