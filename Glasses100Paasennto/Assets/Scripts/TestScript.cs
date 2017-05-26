using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    float Speed = 0.5f;

    Vector3 TargetPos;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")){
            TargetPos = Input.mousePosition;
            TargetPos.y = 0;
        }
        if (Input.GetButtonUp("Fire1")){
            TargetPos = Vector3.zero;
        }

        if (TargetPos != Vector3.zero){
            transform.LookAt(TargetPos);
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
    }
}
