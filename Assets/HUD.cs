using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text scoreText;
    public IntVariable scoreValue;

    public Text coinsText;
    public IntVariable coinsValue;

    public Text livesText;
    public IntVariable livesValue;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = scoreValue.Value.ToString();
        coinsText.text = coinsValue.Value.ToString();
        livesText.text = livesValue.Value.ToString();
    }
}
