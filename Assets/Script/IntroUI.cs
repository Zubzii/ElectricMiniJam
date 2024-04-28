using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Make sure you have this using directive
using UnityEngine.UIElements;

public class IntroUI : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}