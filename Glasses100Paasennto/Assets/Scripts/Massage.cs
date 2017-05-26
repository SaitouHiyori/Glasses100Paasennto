using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Massage : MonoBehaviour {
    /*
    セリフを統括するスクリプト
    */

    public Vector3 TargetPos;//射撃時クリック場所

    private float PlayerMassageSpeed = 0.5f;
    private float EnemyMassageSpeed;

    delegate void MoveTipe();

    MoveTipe ThisMassageMove;

    public void MoveSet(){
        switch (this.gameObject.tag){
            case "PlayerMassage":
                ThisMassageMove = new MoveTipe(PlayerMove);
                break;
            case "EnemyMassage":
                ThisMassageMove = new MoveTipe(EnemyMove);
                break;
            default:
                Debug.Log("タグが設定されていません");
                break;
        }
    }

    public class MassageTags{
        public const string PlayerMassage = "PlayerMassage";
        public const string EnemyMassage = "EnemyMassage";
    }

    private void PlayerMove(){
    }

    private void EnemyMove(){
        //Debug.Log("EnemyMassageが移動しました");
    }

    public void Move(){
        ThisMassageMove();
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("メッセージが衝突しました。");
    }
}