using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour 
{
	public GameObject winPanel;
	public void EndStage(bool success)
	{
		if(success)
		{
			winPanel.SetActive(true);
		}
	}

	public void BackToMain()
	{
		SceneManager.LoadSceneAsync(0);
	}

}
