using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	protected int[] curPos = {0, 0};
	protected CubesController manager;
	protected Animation anim;
	protected bool hasInteraction = true;
	void Start()
	{
		anim = GetComponent<Animation>();
	}

	public virtual void Update(){}
	public virtual void SetUpCube(int[] pos, CubesController manager)
	{
		this.manager = manager;
		this.curPos = pos;
		transform.position = Cubes.GetWorldPosition(pos);
	}
	public virtual void CubeAction(int[] nextPos)
	{
		startAnimation(nextPos);
	}

	public virtual void Command(Direction.Cube direction, int[][] _cubesOccup)
	{
		if(!this.hasInteraction) return;

		this.hasInteraction = false;

		Dictionary<string, int> newPosInfo = Cubes.GetCubeNewPos(this.curPos, _cubesOccup, direction);

		int[] oldMatrixPos = new int[]{
			newPosInfo["y"],
			newPosInfo["x"]
		};

		int[] newMatrixPos = new int[]{
			newPosInfo["newY"],
			newPosInfo["newX"]
		};

		manager.SwitchMatrixValue(oldMatrixPos, 0);
		manager.SwitchMatrixValue(newMatrixPos, newPosInfo["cubeID"]);

		CubeAction(newMatrixPos);
	}

	protected void startAnimation(int[] nextPos)
	{
		Direction.Cube upOrDown = Direction.Cube.None;
		if(nextPos[0] < this.curPos[0]){
			upOrDown = Direction.Cube.Down;
		} else {
			upOrDown = Direction.Cube.Up;
		}

		this.curPos = nextPos;
		AnimationClip clip = CustomAnimation.setAnimationTo(gameObject, nextPos, upOrDown);

		anim.AddClip(clip, clip.name);
		anim.Play(clip.name);
	}
	public virtual void OnAnimationEnded()
	{
		this.hasInteraction = true;
	}
}