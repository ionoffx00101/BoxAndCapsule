using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMoveBackup : MonoBehaviour
{

    // space jump
    // f fire1
    // wasd move

    GameObject[] allBox;

    void Start()
    {
        // input 생성해두기?
        allBox = GameObject.FindGameObjectsWithTag("Box");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // 박스를 어느방향으로 움직여야하나 알기위해 플레이어를 움직이는 input값을 가져옴
        // 박스 위치 = 해당 이동값 + Time.deltaTime + /*스피드*/ 
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");

        // 버튼을 누른 상ㅐ에서만 상자를 움ㅣㄱ일수 있다
        //if (Input.GetButtonDown("Fire1"))
        //{ 
        //    Debug.Log("버튼 누른상태");

        //}
        changeKinematic(Input.GetButton("Fire1"));
    }

    private void changeKinematic(bool button)
    {
        for ( int x = 1 ; x < allBox.Length ; x++ )
        {

            GameObject nineBox = allBox[x];
            Rigidbody rb = nineBox.GetComponent<Rigidbody>();
            rb.isKinematic = !button;
        }
    }
}
