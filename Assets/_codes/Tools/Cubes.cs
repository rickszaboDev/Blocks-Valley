using UnityEngine;
using System.Collections.Generic;
public class Cubes {

	public static bool CheckBoundaries(int[] currentPos, Direction.Cube _direction)
	{
		bool canMove = false;

		if(_direction == Direction.Cube.Left){
			canMove = currentPos[1] % 4 > 0 || (currentPos[1] - 1) == 0;
		}
		if(_direction == Direction.Cube.Right){
			canMove = (currentPos[1] + 1) % 4 != 0 || currentPos[1] < 3;
		}
		if(_direction == Direction.Cube.Back){
			canMove = currentPos[1] + 4 < 16;
		}
		if(_direction == Direction.Cube.Front){
			canMove = currentPos[1] - 4 >= 0;
		}

		return !canMove;
	}
	public static bool CheckBlockOverTarget(int[][] cubesOccupation, int[] _currentPos)
	{
		if(_currentPos[0] < 3){ // Check if there is some block over the current selected
			if(cubesOccupation[_currentPos[0] + 1][_currentPos[1]] > 0){
				return true;
			}
		}
		return false;
	}
	public static int GetDirectionValue(Direction.Cube _direction)
	{
		var directionValue = 0;
		
		if(_direction == Direction.Cube.Left){
			directionValue = -1;
		}
		if(_direction == Direction.Cube.Right){
			directionValue = 1;
		}
		if(_direction == Direction.Cube.Back){
			directionValue = 4;
		}
		if(_direction == Direction.Cube.Front){
			directionValue = -4;
		}

		return directionValue;
	}
	public static Vector3 GetWorldPosition (int[] pos) 
	{
		Vector3 position = new Vector3(
			pos[1] % 4,
			pos[0],
			pos[1] / 4
		);
		return position;
	}

	public static int[] GetMatrixPos (Vector3 worldPos){
		int[] _matrixPos = new int[2];

		_matrixPos[0] = (int)worldPos.y;
		_matrixPos[1] = (int)(worldPos.z * 4 + worldPos.x);

		return _matrixPos;
	}

	public static Dictionary<string, int> GetCubeNewPos(int[] pos, int[][] cubesOccupation, Direction.Cube _direction)
	{
		var _value = new Dictionary<string, int> { 
			{"x", pos[1]},
			{"y", pos[0]},
			{"cubeID", cubesOccupation[pos[0]][pos[1]]},
			{"newX", pos[1]},
			{"newY", pos[0]},
		};

		if(Cubes.CheckBoundaries(pos, _direction)) return _value;
		if(Cubes.CheckBlockOverTarget(cubesOccupation, pos)) return _value;
		
		int[] nextPos = (int[])pos.Clone();
		var directionValue = GetDirectionValue(_direction);

		if(cubesOccupation[pos[0]][pos[1] + directionValue] <= 0)
		{ 				
			if(pos[0] >= 1)
			{																
				if(cubesOccupation[pos[0] - 1][pos[1] + directionValue] > 0) 
				{ 	
					nextPos[1] += directionValue;	
				}
				else if (pos[0] >= 2) 
				{												
					if (cubesOccupation[pos[0] - 2][pos[1] + directionValue] > 0)
					{
						nextPos[0] += -1;														
						nextPos[1] += directionValue;
					}
				} 
				else if(pos[0] - 1 == 0)
				{															
					nextPos[0] += -1;
					nextPos[1] += directionValue;
				}
			} 
			else if(pos[0] == 0)
			{
				nextPos[1] += directionValue;
			}
		} 
		else if(nextPos[0] < 3) 
		{
			if(cubesOccupation[pos[0] + 1][pos[1] + directionValue] <= 0)
			{
				nextPos[1] += directionValue;
				nextPos[0] += 1;
			}
		}
		
		_value["newX"] = nextPos[1];
		_value["newY"] = nextPos[0];

		return _value;
	}
}
