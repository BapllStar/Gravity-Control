using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float gameLength = 20 * 60;
    private TMP_Text text;
	// Start is called before the first frame update
	private void Awake()
	{
        text = GetComponent<TMP_Text>();
	}

	// Update is called once per frame
	void Update()
    {
        float timeLeft = gameLength - Time.time;
        text.text = TimeDisplayer(timeLeft);
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

        string output = sign + minZero + minutes.ToString() + ":" + secZero +  seconds.ToString();
        return output;
	}
}
