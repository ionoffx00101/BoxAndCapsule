using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeInMain : MonoBehaviour {

    public void GoToGame()
    {
        // 게임 씬으로 변경
        SceneManager.LoadScene("Game");
    }
    public void GoToOption()
    {
        SceneManager.LoadScene("Option");
    }
    public void GoToExit()
    {
        // 게임 종료
        Application.Quit();
    }



    //public void LoadByIndex(int sceneIndex)
    //{
    //    SceneManager.LoadScene(sceneIndex);
    //}
    //public void LoadByLevel()
    //{
    //    SceneManager.LoadScene("Game");
    //}
    //void OnClick()
    //{
    //    Debug.Log("dddd00");
    //    SceneManager.LoadScene("Game");
    //    SceneManager.LoadScene("Game",LoadSceneMode.Additive);
    //}
}
