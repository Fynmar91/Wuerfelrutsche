using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	bool gameHasEnded = false;
	public PlayerMovement movement;
	public GameObject completeLevelUI;

	public void CompleteLevel()
	{
		movement.enabled = false;
		completeLevelUI.SetActive(true);
	}

	public void EndGame(float restartDelay)
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Invoke("Restart", restartDelay);
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);	
	}
}
