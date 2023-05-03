using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    [SerializeField] private Sprite [] nextPage;
    int i = 0;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Play");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowRules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void NextPage()
    {
        GameObject.Find("Panel").GetComponent<Image>().sprite= nextPage[i];
        i++;
        if (i == nextPage.Length)
        {
            Destroy(GameObject.Find("Next"));
            GameObject.Find("Play Button").transform.localPosition= new Vector3(0, -190, 0);
        }

    }
}
