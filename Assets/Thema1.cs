using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thema1 : MonoBehaviour {

    // スコアを表示するテキスト
    private GameObject scoreText;

    private int test = 0;

    // Use this for initialization
    void Start () {

        // シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {

        // ScoreTextにスコアを表示
        this.scoreText.GetComponent<Text>().text = "score " + test + "pt";
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            this.test += 10;
        }else if (collision.gameObject.tag == "LargeStarTag")
        {
            this.test += 50;
        }else if (collision.gameObject.tag == "SmallCloudTag")
        {
            this.test += 100;
        }else if (collision.gameObject.tag == "LargeCloudTag")
        {
            this.test += 200;
        }
    }
}
