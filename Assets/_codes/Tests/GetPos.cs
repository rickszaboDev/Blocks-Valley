using UnityEngine;
public class GetPos {
    
	Vector3[][] positionHolder = {
			new Vector3[16],
			new Vector3[16],
			new Vector3[16],
			new Vector3[16]
	};

	void Awake(){
		// stageLevelsHolder = new StagesSetups();
	}
	void Start () {
		var posHolderLen = this.positionHolder.Length;
		var levelHolderLen = this.positionHolder[0].Length;
		for(int i = 0; i < posHolderLen; i++){
			for(int j = 0; j < levelHolderLen; j++) {
				positionHolder[i][j].x = j % 4;
				positionHolder[i][j].y = i;
				positionHolder[i][j].z = j / 4;
			}
		}
	}
}