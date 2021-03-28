using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour 
{
	GameManager gameManager;
	void Start()
	{
        gameManager = GameManager.Instance;
	}
	public void CallStage(int id)
	{
		gameManager.SetGameplayScene(id);
        StartCoroutine(WaitUntilIsDone(id));
    }
    private IEnumerator WaitUntilIsDone(int id)
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        yield return new WaitUntil(() => {
            return sceneLoading.isDone;
        });
    }
}
