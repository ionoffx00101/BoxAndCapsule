using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTank : MonoBehaviour
{
    public float tankSpeed = 6f;

    public GameObject tank;

    //Transform tankTrans;
    Rigidbody tankBody;

    Vector3 movement;
    //Rigidbody tankBody;

    //카메라 회전
    //int floorMask;
    //public float camRayLength = 100f;

    void Start ()
    {
        // floorMask = LayerMask.GetMask("Floor");
        //tankTrans = tank.transform;
        tankBody = tank.GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        // 수평축 움직임을 h에 넣어준다.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        //Turning();
    }

    void Move(float h, float v)
    {
        // movement.Set(x,y,z);
        movement.Set(h, 0f, v);

        // 어떤 키를 사용하든지 일정한 속도를 만들어줌
        movement = movement.normalized * tankSpeed * Time.deltaTime;

        // transform.position = 가져오는 transform은 player의 transform
        // 기존 플레이어 위치 + 새로 입력된 값에 의한 이동값
        // 그걸 플레이어 위치 변경(새로운 값)으로 입력해서 위치 재설정
        tankBody.MovePosition(transform.position + movement);
    }

    //void Turning()
    //{
    //    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    RaycastHit floorHit;

    //    if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
    //    {
    //        Vector3 playerToMouse = floorHit.point - transform.position;
    //        playerToMouse.y = 0f;

    //        // 새로 생성된 회전값을 변환
    //        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
    //        // 변환된 값을 플레이어리지드바디 움직인 회전 값에 넣는다.
    //        tankBody.MoveRotation(newRotation);
    //    }
    //}
}
