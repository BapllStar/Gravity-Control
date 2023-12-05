using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonMaster : MonoBehaviour
{
    public bool isPlaying;

	private void StopPlaying()
	{
		isPlaying = false;
	}

    public void WinGame()
	{
		StopPlaying();
		SceneManager.LoadScene("WinScene");
	}

    public void LoseGame()
	{
		StopPlaying();
		SceneManager.LoadScene("LoseScene");
	}
}