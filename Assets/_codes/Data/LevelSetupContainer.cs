using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetupContainer {

	
	public delegate void  SwitchMatrixValue(int[] pos, int value);
	public SwitchMatrixValue switchMatrixValue;
	StagesSetups stageLevelsHolder;
	public GameObject element;

	private int[][] CubesOccupation = {
			new int[16],
			new int[16],
			new int[16],
			new int[16]
	};

	public LevelSetupContainer(int i){
		stageLevelsHolder = new StagesSetups();
		CubesOccupation = stageLevelsHolder.cubesOccupation[i];
		
		switchMatrixValue = ChangeOccup;
	}


	public void ChangeOccup (int[] pos, int value){	
		CubesOccupation[pos[0]][pos[1]] = value;
	}

	public int[][] GetCubesOccupation(){
		return this.CubesOccupation;
	}
}
