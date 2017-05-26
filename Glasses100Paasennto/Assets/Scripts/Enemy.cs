using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    /*
    敵のＡＩを統括するスクリプト
    */

    private float ShootInterval = 3;//発射間隔
    private float ShootTimer;//間隔を計るタイマー

    public GameManager GM;
    public GameObject Massage;

	void Start () {
		
	}
	
    //セリフ発射メソッド
    public void MassageShooter(){
        //毎フレーム呼び出される。
        //呼び出されるたびに時間経過をカウント
        //一定時間経過で発射

        //発射間隔
        ShootTimer += Time.deltaTime;
        if(ShootTimer >= ShootInterval){
            MassageChanger();
            for (int i = 0; i < GM.EnemyMassage.Length; i++){
                if(GM.EnemyMassage[i] == null){
                    GameObject InstanceMassgae = Instantiate(Massage);
                    InstanceMassgae.tag = "EnemyMassage";//タグ付け
                    InstanceMassgae.GetComponent<Massage>().MoveSet();//動き決定
                    GM.EnemyMassage[i] = InstanceMassgae.GetComponent<Massage>();
                    Debug.Log("敵がセリフを発射しました");
                    break;
                }
            }
            ShootTimer = 0;
        }

    }

    //セリフ変更メソッド
    private static void MassageChanger(){
        Debug.Log(string.Format("が選択されました"));
    }
}
