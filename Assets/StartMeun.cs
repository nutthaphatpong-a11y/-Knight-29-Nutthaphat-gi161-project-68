using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMeun : MonoBehaviour
{

    public void OnStartCkick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnExitCkick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#endif 
        Application.Quit();
    }


}
