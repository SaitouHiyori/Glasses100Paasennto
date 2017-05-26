using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /*
    プレイヤーの処理を統括するスクリプト
    */

    public enum MassageState {Brake,Bigger,Smoler }
    //public enum LR_SwitchState { Stop,Left,Right}

    private MassageState NowMassageState;

    private string[] MassageName = new string[3] { "Break", "Bigger", "Smoler" };

    public GameManager GM;
    public GameObject Massage;

	void Start () {
        NowMassageState = MassageState.Brake;
    }
	

    public void Change(int State){
        switch (State){
            case (int)GameManager.ChangeState.Left:
                if(NowMassageState == MassageState.Brake){
                    NowMassageState = MassageState.Smoler;
                }
                else{
                    NowMassageState--;
                }
                GM.IsChange = false;
                break;
            case (int)GameManager.ChangeState.Right:
                if(NowMassageState == MassageState.Smoler){
                    NowMassageState = MassageState.Brake;
                }
                else{
                    NowMassageState++;
                }
                GM.IsChange = false;
                break;
            case (int)GameManager.ChangeState.Stop:
                break;
            default:
                break;
        } 

        Debug.Log(MassageName[(int)NowMassageState]);

    }

    public void Shot(Vector3 TapPos){
        for (int i = 0; i < GM.PlayerMassage.Length; i++){
            if (GM.PlayerMassage[i] == null){
                GameObject InstanceMassage = Instantiate(Massage);
                InstanceMassage.tag = "PlayerMassage";//タグ付け
                InstanceMassage.GetComponent<Massage>().MoveSet();//動き決定
                GM.PlayerMassage[i] = InstanceMassage.GetComponent<Massage>();
                Debug.Log("プレイヤーがセリフを発射しました");
                break;
            }
        }
    }
}
