using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarBehavior : CubeController {
	private bool isCompleted = false;

	public override void Command(Direction.Cube direction, int[][] _cubesOccup){
		Dictionary<string, int> newPosInfo = Cubes.GetCubeNewPos(this.curPos, _cubesOccup, direction);

		int[] oldMatrixPos = new int[]{
			newPosInfo["y"],
			newPosInfo["x"]
		};

		int[] newMatrixPos = new int[]{
			newPosInfo["newY"],
			newPosInfo["newX"]
		};

		if(_cubesOccup[newMatrixPos[0]][newMatrixPos[1]] == -1)
		{
			isCompleted = true;
		}
		base.Command(direction, _cubesOccup);
	}

	public override void OnAnimationEnded(){
		if(isCompleted)
		{
			Debug.Log("End Game");
			manager.EndStage(true);
		}
		base.OnAnimationEnded();
	}
	
}
