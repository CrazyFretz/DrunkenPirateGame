using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {


	public GameControl gameControl;

	private bool canMove = true;
	private Vector3 accDir;
	public float moveSpeed = 20;

	private int leftCount = 0;
	private int rightCount = 0;


	private int stagger = 0;

	void Awake()
	{
		gameControl = GameObject.Find("GameControl").GetComponent<GameControl>(); // second part of getComponent

	}

	// Use this for initialization
	void Start () {
		InvokeRepeating("DrunkenStagger", 0.5f, 1.0f);
		InvokeRepeating("ResetStagger", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(new Vector3(0f, 0f, gameControl.playerMoveSpeed * Time.deltaTime));

		if(canMove == true){
			//accDir.x = (0 + 0.5f) * 2; // Input.acceleration.x
			
			//if(accDir.sqrMagnitude > 1){
			//	accDir.Normalize();
			//}
			
			//accDir *= Time.deltaTime;
			
			//transform.Translate(accDir * moveSpeed);

			transform.AddForce(Input.acceleration.x / 2,0,0);
			
			Vector3 playerPos = transform.position;





			// stagger stuff
			if(stagger > 0){
				if(stagger < 10){ //go left
					if(leftCount < 4){
						rigidbody.AddForce(new Vector3(Random.Range(-0.7f, -0.3f), 0f, 0f));
					}else{
						if(leftCount > 8){
							leftCount = 0;
						}
					}
				}else if(stagger > 10){ // go right
					if(rightCount < 4){
						rigidbody.AddForce(new Vector3(Random.Range(0.7f, 0.3f), 0f, 0f));
					}else{
						if(rightCount > 8){
							rightCount = 0;
						}
					}
				}
			}


			

		}

	}

	void DrunkenStagger (){

		int randNum = Random.Range(0, 20);
	
		stagger = randNum;

		if(stagger < 10){ //go left
			leftCount++;
		}else if(stagger > 10){ // go right
			rightCount++;
		}


	}

	void ResetStagger (){
		stagger = 0;
	}
}
