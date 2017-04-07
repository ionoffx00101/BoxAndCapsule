using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeInGame : MonoBehaviour {

    public void GoToBack()
    {
        // 뒤로 가기
        // Application.Quit();
        // Main으로 보내기
        SceneManager.LoadScene("Main");
    }
}
