using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    /*
    ゲームシーンを統括するスクリプト
    ここからほかのスクリプトのメソッドを呼び出して動作させる
    */

    public enum ChangeState { Right,Left,Stop};
    private ChangeState CS;

    private float TapFieldHeight = 200;//プレイヤー操作領域高さ
    private float SwipeLange = 5;//スワイプ判定最低値。１ｃｍくらいにしたい

    //private bool LorR;
    public bool IsChange;//射撃か変更か
    //private bool IsChange;//変更したかどうか

    private Vector3 TapPos;

    //各種スクリプト
    public Player Player;
    public Enemy Enemy;
    
    //メッセージ
    public Massage[] PlayerMassage = new Massage[5];//プレイヤーメッセージ
    public Massage[] EnemyMassage  = new Massage[5];//エネミーメッセージ

    void Update () {
        //メインループ
        //プレイヤー処理

        //タップ位置で処理変更
        if (Input.GetButtonDown("Fire1")){
            Debug.Log(TapPos);
            if (Input.mousePosition.y <= TapFieldHeight){
                //メッセージ変更処理
                IsChange = true;
                TapPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            }
            else{
                //メッセージ発射処理
                IsChange = false;
                //Player.Shot();
            }
        }

        if (IsChange){
            if(TapPos.x - Input.mousePosition.x < -SwipeLange){
                CS = ChangeState.Left;
            }
            else if(TapPos.x - Input.mousePosition.x > SwipeLange){
                CS = ChangeState.Right;
            }
            else{
                CS = ChangeState.Stop;
            }

            Player.Change((int)CS);
        }

        //エネミー処理
        //一定時間ごとにセリフ発射
        Enemy.MassageShooter();

        //セリフ移動
        for (int i = 0; i < PlayerMassage.Length; i++){
            if (PlayerMassage[i] != null){
                PlayerMassage[i].Move();
            }
        }

        for (int i = 0; i < EnemyMassage.Length; i++){
            if(EnemyMassage[i] != null){
                EnemyMassage[i].Move();
            }
        }
	}
}
