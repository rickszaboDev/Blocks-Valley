using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelector : MonoBehaviour 
{
	GameManager gameManager;
	void Start()
	{
		gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
	}
	public void CallStage(int id)
	{
		gameManager.CallStage(id);
	}
}
