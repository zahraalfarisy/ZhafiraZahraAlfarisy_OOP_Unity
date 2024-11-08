using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (animator == null)
        {
            animator.enabled = false;
        }
    }

    public void LoadScene(string sceneName)
    {
        animator.SetTrigger("StartTransition");
        StartCoroutine(LoadSceneWithDelay(sceneName, 1f));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
        animator.SetTrigger("EndTransition");
    }
}