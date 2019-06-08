using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTimeCubeBehavior : CubeController
{
	bool hasBack = true;
	Direction.Cube lastDirection;
	public override void CubeAction(int[] pos)
	{
		base.CubeAction(pos);
		hasBack = false;
	}

	public override void OnAnimationEnded()
	{
		if(!hasBack)
		{	
			StartCoroutine("backToInitialPosition");
		} else {
			base.OnAnimationEnded();
		}
	}

	public override void Command(Direction.Cube direction, int[][] _cubesOccup){
		if(!hasInteraction) return;
		base.Command(direction, _cubesOccup);
		this.lastDirection = direction;
	}

	IEnumerator backToInitialPosition()
	{
		yield return new WaitForSeconds(1.5f);
		Direction.Cube backDirection = inverseDirection(lastDirection);
		this.hasInteraction = true;
		manager.SendCommandToCube(gameObject, backDirection);
		this.hasInteraction = false;
		hasBack = true;
	}
	private Direction.Cube inverseDirection(Direction.Cube _dir)
	{
		Direction.Cube _inverseDirection = Direction.Cube.None;
		if(_dir == Direction.Cube.Left)
		{
			_inverseDirection = Direction.Cube.Right;
		}
		else if(_dir == Direction.Cube.Right)
		{
			_inverseDirection = Direction.Cube.Left;
		}
		else if(_dir == Direction.Cube.Front)
		{
			_inverseDirection = Direction.Cube.Back;
		}
		else if(_dir == Direction.Cube.Back)
		{
			_inverseDirection = Direction.Cube.Front;
		}

		return _inverseDirection;
	}
}
