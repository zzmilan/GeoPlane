using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject treesObject;

    private bool trees = true;

    private void Start()
    {
        trees = true;

        treesObject = GameObject.Find("trees");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void SetTrees(bool isTree)
    {
        trees = isTree;

        treesObject.SetActive(trees);
    }

    public void Mora() {
        if (trees)
        {
            SceneManager.LoadScene("mora");
        }
        else {
            SceneManager.LoadScene("moraNT");
        }
    }

    public void Nizije()
    {
        if (trees)
        {
            SceneManager.LoadScene("nizije");
        }
        else
        {
            SceneManager.LoadScene("nizijeNT");
        }
    }

    public void Ostrva()
    {
        if (Random.Range(1, 6) != 4)
        {
            if (trees)
            {
                SceneManager.LoadScene("ostrva");
            }
            else
            {
                SceneManager.LoadScene("ostrvaNT");
            }
        }
        else {
            if (trees)
            {
                SceneManager.LoadScene("ostrvaS");
            }
            else
            {
                SceneManager.LoadScene("ostrvaSNT");
            }
        }
    }

    public void Planine()
    {
        if (trees)
        {
            SceneManager.LoadScene("planine");
        }
        else
        {
            SceneManager.LoadScene("planineNT");
        }
    }

    public void Poluostrva()
    {
        if (trees)
        {
            SceneManager.LoadScene("poluostrva");
        }
        else
        {
            SceneManager.LoadScene("poluostrvaNT");
        }
    }
}
