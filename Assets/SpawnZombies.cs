using UnityEngine;
using System.Collections;

public class SpawnZombies : MonoBehaviour {
	public Transform Enemy;
	public float IntervalToSpawn; //how often should the spawner spawn an enemy
	private float Timer;

	// Use this for initialization
	void Awake() {
		Timer = Time.time + IntervalToSpawn;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer < Time.time) {
			Instantiate(Enemy, transform.position, transform.rotation);
			Timer = Time.time + IntervalToSpawn;
		}
	
	}
}
