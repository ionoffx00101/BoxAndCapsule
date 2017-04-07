using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float cubeSpeed = 6f;

    Vector3 movement;
    Rigidbody cubeBody;

    void Start ()
    {
        cubeBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        // 수평축 움직임을 h에 넣어준다.
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        //Move(h, v);
    }

    void Move(float h, float v)
    {
        // movement.Set(x,y,z);
        movement.Set(h, 0f, v);

        // 어떤 키를 사용하든지 일정한 속도를 만들어줌
        movement = movement.normalized * cubeSpeed * Time.deltaTime;

        // transform.position = 가져오는 transform은 player의 transform
        // 기존 플레이어 위치 + 새로 입력된 값에 의한 이동값
        // 그걸 플레이어 위치 변경(새로운 값)으로 입력해서 위치 재설정
        cubeBody.MovePosition(transform.position + movement);
    }
}
