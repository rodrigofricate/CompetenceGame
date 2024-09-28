using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CanLoadScene : MonoBehaviour
{
    [SerializeField] TMP_Text tmpLoadPercentage;
    [SerializeField] int sceneBuilderRef;
    [SerializeField] Image img_LoadProgressBar;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }


    public void LoadScene()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneBuilderRef, LoadSceneMode.Single);

        gameObject.GetComponent<Canvas>().enabled = true;

        while (!asyncLoad.isDone)
        {
            tmpLoadPercentage.text = (asyncLoad.progress*100.0f).ToString("00")+"%";
            img_LoadProgressBar.fillAmount = asyncLoad.progress;
            yield return null;
        }

    }
}
