using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonMaster : MonoBehaviour
{
    public bool isPlaying;
	public float timeLeft;
	public float gameLength = 15 * 60;

	private void Update()
	{
		timeLeft = gameLength - Time.timeSinceLevelLoad;
	}

	private void StopPlaying()
	{
		isPlaying = false;
	}

    public void WinGame()
	{
		StopPlaying();
		PlayerPrefs.SetFloat("score", Time.timeSinceLevelLoad);
		SceneManager.LoadScene("WinScene");
	}

    public void LoseGame()
	{
		StopPlaying();
		SceneManager.LoadScene("LoseScene");
	}
}
