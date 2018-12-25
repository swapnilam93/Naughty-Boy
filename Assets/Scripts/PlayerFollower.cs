using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFollower : MonoBehaviour {

	public Transform Player;
	public int MoveSpeed = 4;
	public float MaxDist = 0.7f;
	public float MinDist = 0.5f;
	public float redDist = 2f;
	public Light lt;

	void Start()
	{

	}

	void Update()
	{
		transform.LookAt(Player);

		if (Vector3.Distance(transform.position, Player.position) >= MinDist)
		{

			transform.position += transform.forward * MoveSpeed * Time.deltaTime;

			if(Vector3.Distance(transform.position, Player.position) <= redDist) {
				lt.color = Color.red/2.0f;
			}
			else {
				lt.color = Color.white;
			}

			if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
			{
				Debug.Log("game over");
				SceneManager.LoadScene(2);
			}

		}
	}

}