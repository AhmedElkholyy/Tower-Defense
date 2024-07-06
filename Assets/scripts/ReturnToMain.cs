using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToMain : MonoBehaviour
{
    public void OnButtonClick()
    {
        
        SceneManager.LoadScene("Main");
    }
}
