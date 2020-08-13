using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Main { get; private set; }

    private void Awake()
    {
        if (!Main)
        {
            Main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void LoadScene(string id)
    {
        SceneManager.LoadScene(id);
    }

}
