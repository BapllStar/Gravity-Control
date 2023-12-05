using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPlayerScore : MonoBehaviour
{
	private TMP_Text text;
	private void Awake()
	{
		text = GetComponent<TMP_Text>();
        text.text = TimeDisplayer(PlayerPrefs.GetFloat("score"));
	}

    private string TimeDisplayer(float time)
    {
        string sign = time < 0 ? "-" : "";

        time = Mathf.Abs(time);

        int minutes = (int)Mathf.Floor(time / 60);
        int seconds = (int)Mathf.Floor(time - minutes * 60);

        string minZero = "";
        string secZero = "";

        if (minutes < 10) minZero = "0";
        if (seconds < 10) secZero = "0";

        string output = sign + minZero + minutes.ToString() + ":" + secZero + seconds.ToString();
        return output;
    }
}
