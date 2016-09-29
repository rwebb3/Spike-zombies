using UnityEngine;
using System.Collections;
 
public class Gun : MonoBehaviour {

	public float fireRate = 0;
	public float damage = 10;
	public LayerMask whatToHit;
	
	float timeToFire = 0;
	Transform firePoint;
	int shotDirection = 1;

	// Use this for initialization
	void Awake() {
		firePoint = transform.FindChild("FirePoint");
		if (firePoint == null){
			Debug.LogError("No FirePoint?");
		}	
	}
	
	// Update is called once per frame
	void Update() {
		if (fireRate == 0){
			if (Input.GetButtonDown("Fire1")){
				Shoot();
			}
		}
		else{
			if (Input.GetButtonDown("Fire1") && Time.time > timeToFire){
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	
	}
	
	void Shoot(){
	
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y); //start of shot
		//Debug.Log(firePointPosition);
		
		if (GetComponentInParent<PlatformerCharacter2D>().isFacingRight()){shotDirection = 1;} //determine shot direction
		else{shotDirection = -1;}
		
		Vector2 shotPosition = new Vector2(firePoint.position.x + shotDirection, firePoint.position.y); // make a point slightly away from firePoint
		//Debug.Log(shotPosition);
		Vector2 shotPositionDirection = new Vector2(shotPosition.x - firePoint.position.x, 0);
	 	
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition, shotPositionDirection, 100, whatToHit);
		
		//Debug.DrawLine(firePointPosition, shotPosition*10, Color.cyan);
		if (hit.collider != null){
			Debug.DrawLine(firePointPosition, hit.point, Color.red);
			if (hit.transform.gameObject.CompareTag ("Zombie")){
				hit.transform.SendMessage("TakeDamage", damage);
			}
			//Debug.Log (hit.point);
			//Debug.Log("hit " + hit.collider.name + " and did " + damage + " damage.");
		}
	}
}
