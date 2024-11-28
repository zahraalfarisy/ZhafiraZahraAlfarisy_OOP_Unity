using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator.enabled = false;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        animator.enabled = true;
        //animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f); 
        animator.SetTrigger("EndTransition");
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
    }
}
