using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thema2 : MonoBehaviour {

    // HingeJointコンポーネントをいれる
    private HingeJoint myHingeJoint;

    // 初期の傾き
    private float defaultAngle = 20;
    // 弾いた時の傾き
    private float flickAngle = -20;

    // 画面をタッチした時のFingerIdと座標を記録する為のDictionaryを作成する
    Dictionary<int, float> dic= new Dictionary<int, float>()
            {
                {0, 0}
            };

    // Use this for initialization
    void Start() {

        // HingeJointコンポーネントを取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        // フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Touch t in Input.touches)
        {
            //　FingerId
            var id = t.fingerId;
            // 座標
            var pos = t.position;

            // タッチした時の反応
            switch (t.phase)
            {
                case TouchPhase.Began:

                    // ここでFingerIdとタッチした時のpos.xを関連付ける
                    dic[id] = pos.x;

                    // 画面右半分をタッチしていたら右フリッパーを動かす
                    if (pos.x > Screen.width * 0.5f && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    //画面左半分をタッチしていたら左フリッパーを動かす
                    else if(pos.x < Screen.width * 0.5 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    // 指が離れたときのFingerId [Key] を使って記録していた座標 [Value] を呼び出し左右どちらかのフリッパーを動かすかを決める
                    if (dic[id] > Screen.width * 0.5 && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    else if (dic[id] < Screen.width * 0.5 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    break;
            }
        }
    }

    public void SetAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}

