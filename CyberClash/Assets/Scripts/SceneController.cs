using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] private Animator transitionAnim;
    
    // Start is called before the first frame update
    void Awake()
    {

    }

    public void LoadLevel(string sceneName)
    {
        transitionAnim.SetTrigger("Start");
        StartCoroutine(Wait());
        SceneManager.LoadScene(sceneName);
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
