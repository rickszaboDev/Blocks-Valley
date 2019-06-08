using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesController : MonoBehaviour 
{
	public LevelSetupContainer setup;
	public LevelSetupContainer.SwitchMatrixValue switchMatrixValue;
	public List<CubeController> cubeControllerList = new List<CubeController>();
	private bool isInputAllow = true;

	public int levelId = 0;
	public GameObject[] gameElements;
	
	public void Start()
	{
		setup = new LevelSetupContainer(levelId);
		switchMatrixValue = setup.switchMatrixValue;
		cubeControllerList = SetCubesOnContainer(gameElements, setup.GetCubesOccupation());
	}

	public void SendCommandToCube(GameObject cube, Direction.Cube direction){
		if(!isInputAllow) return;

		int controllersLen = cubeControllerList.Count;
		for(int i = 0; i < controllersLen; i++)
		{
			if(cubeControllerList[i].gameObject == cube){
				int[][] cubesOccup = setup.GetCubesOccupation();
				cubeControllerList[i].Command(direction, cubesOccup);
			}
		}
	}

	public List<CubeController> SetCubesOnContainer(GameObject[] elements, int[][] _cubesOccup)
	{
		List<CubeController> _cubeControllerList = new List<CubeController>();

		int index = 0;
		for(int i = 0; i < _cubesOccup.Length; i++){
			for(int j = 0; j < _cubesOccup[i].Length; j++){
				if(_cubesOccup[i][j] > 0){
					GameObject newCube = Instantiate(elements[_cubesOccup[i][j] - 1]) as GameObject;
					_cubeControllerList.Add(newCube.GetComponent<CubeController>());
					_cubeControllerList[index].SetUpCube(new int[] {i, j}, this);
					index++;
				}
			}
		}

		return _cubeControllerList;
	}
	
	public void ToggleInteraction(bool b)
	{
		this.isInputAllow = b;
	}

	public void SwitchMatrixValue(int[] pos, int value)
	{
		this.switchMatrixValue(pos, value);
	}
}