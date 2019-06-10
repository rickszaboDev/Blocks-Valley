using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	void Awake () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
	
	public void CallStage(int id)
	{
		StartCoroutine(WaitUntilIsDone(id));
	}

	IEnumerator WaitUntilIsDone(int id)
	{
		AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
		yield return new WaitUntil(() =>{
			return sceneLoading.isDone;
		});
		
		setGameplayScene(id);
	}

	public void setGameplayScene(int id)
	{		
		CubesController controller = GameObject.FindGameObjectWithTag("CubeContainer").GetComponent<CubesController>();
		controller.levelId = id - 1;
		controller.enabled = true;
	}
}
