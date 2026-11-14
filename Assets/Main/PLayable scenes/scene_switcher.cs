using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    [SerializeField] private KeyCode _keypress;

    private void Update()
    {
         
        if (Input.GetKeyDown(_keypress)) SceneManager.LoadScene(_sceneName);
    }
}