using UnityEngine;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
    public void StartPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
