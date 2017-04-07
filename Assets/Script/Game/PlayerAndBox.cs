using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAndBox : MonoBehaviour
{
    // 플레이어와 박스의 충돌을 처리하기 위해 만든 스크립트
    // 충돌 후
    // f키 = fire1
    // 키가 눌려있는지 확인하고
    // 키가 눌려있으면 플레이어 앞에 상자가 붙어서 이동한다
    // 플레이어 방향 +상자 반쪽길이 에 붙어서
    // 플레이어 이동방향으로 가는거

    // 이 스크립트는 A랑 B랑 만나고
    // 무언가가 B를 만난다고 코딩했으면
    // A에다 스크립트를 올려주면 된다.
    // 이렇게 했더니 되서 암 ㅇㅇ

    // 버튼 눌리고 충돌 
    // 충돌하고 버튼 눌림 - 지금 이거

    //3. Raycast
    //거리를 판단하고 명령에 맞는 수행을 하는것부터 시작해서 응용분야가 다양하다.

    private bool collis = false;
    private Collision meetBox;

    /* JoyStick 추가해본것 - 시작 */
    public VirtualJoystick joyStick;
    /* JoyStick 추가해본것 - 끝 */

    private void OnCollisionEnter (Collision other)
    {
        // other에는 충돌한 객체가 들어있다.
        
        // 만난 게임오브젝트의 태그가 box면
        if ( other.transform.tag == "Box" )
        {
            meetBox = other;
            collis = true;
        }
    }

    private void FixedUpdate ()
    {
        /* JoyStick 추가해본것 - 시작 */
        float h = joyStick.Horizontal();
        float v = joyStick.Vertical();
        /* JoyStick 추가해본것 - 끝 */

        if ( Input.GetButton("Fire1") && collis ) // GetButtonDown
        {
            BoxFollowPlayer(h,v);
            // 한번 돌린 후에는 초기화를 시켜주자
            meetBox = new Collision();
            collis = false;
        }
        // 아무 충돌이 없을때 collis랑 meetBox를 초기화시켜줘야함
        if ( Input.GetButtonUp("Fire1") && collis )
        {
            PlayerDropBox();
        }
    }

    private void BoxFollowPlayer (float h, float v)
    {
        // 움직이는 속도
        float speed = Vector3.Dot(meetBox.rigidbody.velocity , transform.forward);

        // 사람 객체 좌표 - 충돌객체 좌표을 통해 가야할 좌표 방향을 잡을 수 있을것같다.
        // 근데 사람 객체를 어떻게 잡아



        // Debug.Log("만나고 버튼도 눌려있는 상태"); // 아주 효과적으로 만남
        Debug.Log(meetBox.rigidbody.position);
        //meetBox.rigidbody.position = new Vector3(meetBox.rigidbody.position.x + (v * Time.deltaTime), meetBox.rigidbody.position.z + (h * Time.deltaTime));
        // 기존 위치에서 플레이어가 가던 방향으로 -(10)?
        // 숫자로 된 부분을 어디서 따로 만들어야한다
        // 플레이어가 왼쪽으로 가는거 화나낟
        // meetBox.rigidbody.position = new Vector3(meetBox.rigidbody.position.x+5 , meetBox.rigidbody.position.y ,meetBox.rigidbody.position.z-5);
        meetBox.rigidbody.position = new Vector3(((meetBox.rigidbody.position.x-5)- meetBox.rigidbody.position.x )*speed, meetBox.rigidbody.position.y ,(meetBox.rigidbody.position.z-5)- meetBox.rigidbody.position.z);
        Debug.Log(meetBox.rigidbody.position);

    }
    private void PlayerDropBox ()
    {
        // Debug.Log("만나고 버튼도 눌려있는 상태"); // 초기화되긴 함
        meetBox = new Collision();
        collis = false;
    }
}
