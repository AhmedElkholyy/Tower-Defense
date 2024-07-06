using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    
    public void ExitApplication()
    {
        
        Application.Quit();
        
        
    }
}
