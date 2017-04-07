using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControl : MonoBehaviour {

    public float speed = 6f;

    // 변수 영역 미리 준비
    Vector3 movement;
    Rigidbody playerRigbody;
    float camRayLength = 100f;

    /* JoyStick - 시작 */
    public VirtualJoystick joyStick;
    /* JoyStick - 끝 */

    void Awake ()
    {
        // 게임이 시작되면 
        // 각 부분에 유니티 영역값을 가져와서 넣어줌  
        playerRigbody = GetComponent<Rigidbody>();
    }

    void Start () {

    }


    void Update ()
    { 

    }
    private void FixedUpdate ()
    {

        /* JoyStick - 시작 */
        float h = joyStick.Horizontal();
        float v = joyStick.Vertical();
        /* JoyStick - 끝 */

        Move(h , v);
    }
    void Move (float h , float v)
    {
        // movement.Set(x,y,z);
        movement.Set(h , 0f , v);

        // 어떤 키를 사용하든지 일정한 속도를 만들어줌
        movement = movement.normalized * speed * Time.deltaTime;

        // transform.position = 가져오는 transform은 player의 transform
        // 기존 플레이어 위치 + 새로 입력된 값에 의한 이동값
        // 그걸 플레이어 위치 변경(새로운 값)으로 입력해서 위치 재설정
        playerRigbody.MovePosition(transform.position + movement);
    }
}
