using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour 
{
	public Camera mainCamera;
	public CubesController manager;
	private Direction.Cube _direction = Direction.Cube.None;
	private GameObject cubeSelected;
	private Vector3 initPointerPos;
	private Vector3 finalPointerPos;
	public static bool isInputAllow = true;
	public float tolerance = 10f;
	GameObject player;
	void Start()
	{
		player = GameObject.FindWithTag("Player");
	}
	void Update () 
	{
		if(!isInputAllow) {
			Debug.Log("InputController is blocking the inputs.");
			return;
		}

		bool mouseLeftClickDown = Input.GetMouseButtonDown(0);
		bool mouseLeftClickUp = Input.GetMouseButtonUp(0);

		if (mouseLeftClickDown) 
		{	
			this.initPointerPos = Input.mousePosition;
			checkRaycast();
		}

		if(!this.cubeSelected) return; 	// If after releases the mouse button no cube was hit by the raycast, do nothing.
		if(mouseLeftClickUp) this._direction = CheckDirection();
		
		if(this._direction != Direction.Cube.None){
			this.manager.SendCommandToCube(this.cubeSelected, this._direction); // Ask to Manager to send the cube to a new position.
			this._direction = Direction.Cube.None;	//Resets the direction.
		}
	}
  private Direction.Cube CheckDirection()
  {	
		finalPointerPos	= Input.mousePosition;

		float difX = Mathf.Abs(initPointerPos.x - finalPointerPos.x);
		float difY = Mathf.Abs(initPointerPos.y - finalPointerPos.y);

		if(difX > tolerance)
		{
			if(initPointerPos.x < finalPointerPos.x)
				return Direction.Cube.Right;
			else if(initPointerPos.x > finalPointerPos.x)
				return Direction.Cube.Left;
		}
		else if(difY > tolerance)
		{
			if(initPointerPos.y < finalPointerPos.y)
				return Direction.Cube.Back;
			else if(initPointerPos.y > finalPointerPos.y)
				return Direction.Cube.Front;
		}

		return Direction.Cube.None;
  }

  private void checkRaycast () 
	{
		RaycastHit hit; 
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); 
		if ( Physics.Raycast (ray,out hit,100.0f)){ 
			if(hit.transform!=null && hit.collider.tag == "Cube") 
			{
				this.cubeSelected = hit.transform.gameObject;
			} 
			else
			{
				this.cubeSelected = player;
			}
		}
		else
		{
			this.cubeSelected = player;
		}
	}
}
