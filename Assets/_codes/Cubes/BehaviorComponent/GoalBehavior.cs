using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : CubeController 
{
	public override void SetUpCube(int[] pos, CubesController manager)
	{
		base.SetUpCube(pos, manager);
		manager.SwitchMatrixValue(pos, -1);
	}

	public override void Command(Direction.Cube direction, int[][] _cubesOccup){}

	public override void Update(){

	}
}