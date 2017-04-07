using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bigStick;
    private Image smallStick;
    private Vector3 inputVector;

    private void Start ()
    {
        // 큰 스틱애 지금 연결된 컴포넌트<이미지>를 집어넣는다
        bigStick = GetComponent<Image>();
        // 작은 스틱에 지금 연결된 컴포넌트의 0번째 자식의 transform을 집어넣는다
        smallStick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown (PointerEventData ped)
    {
        // 누르는 경우는 드래그 메소드로 값을 보냄
        OnDrag(ped);
    }
    public virtual void OnPointerUp (PointerEventData ped)
    {
        // 손 떼면 위치 초기화
        inputVector = Vector3.zero;
        smallStick.rectTransform.anchoredPosition = Vector3.zero;
    }
    public virtual void OnDrag (PointerEventData ped)
    {
        Vector2 pos;
        if ( RectTransformUtility.ScreenPointToLocalPointInRectangle(bigStick.rectTransform , ped.position , ped.pressEventCamera , out pos) )
        {
            // 빅스틱을 감싼 투명막 pos
            // pos 크기는 빅스틱크기과 같게
            pos.x = (pos.x / bigStick.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bigStick.rectTransform.sizeDelta.y);

            // 빅스틱은 왼쪽 아래 앵커가 좌표의 기준이다
            // inputVector = new Vector3(pos.x * 2 + 1,0,pos.y*2-1); - 앵커가 오른쪽 아래 기준일때
            inputVector = new Vector3(pos.x * 2 - 1 , 0 , pos.y * 2 - 1); // 왼쪽 아래?

            // inputVector는 빅스틱의 가운데가 좌표의 기준이다.
            // 조건 ? 참 : 거짓
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // Move SmallStick
            // 스몰스틱의 앵커포인트를 재지정해줌
            // smallStick.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bigStick.rectTransform.sizeDelta.x / 2), inputVector.z * (bigStick.rectTransform.sizeDelta.y / 2));
            smallStick.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bigStick.rectTransform.sizeDelta.x / 3) , inputVector.z * (bigStick.rectTransform.sizeDelta.y / 3));
        }
    }
    public float Horizontal()
    {
        if(inputVector.x != 0 )
        {
            return inputVector.x;
        }
        else
        {
            // Input의 Horizontal를 찾아서 반환
            return Input.GetAxis("Horizontal");
        }
    }
    public float Vertical ()
    {
        if ( inputVector.z != 0 )
        {
            return inputVector.z;
        }
        else
        {
            // Input의 Vertical 찾아서 반환
            return Input.GetAxis("Vertical");
        }
    }
}
