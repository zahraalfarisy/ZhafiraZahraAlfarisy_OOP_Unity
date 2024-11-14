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
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        //animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f); 
        animator.SetTrigger("EndTransition");
        SceneManager.LoadScene(sceneName);
        
    }
}
