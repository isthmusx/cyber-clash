using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
public class OpenPack : MonoBehaviour
{

    public float updated;
    public float max;

    public Image bar;

    public GameObject prefab;
    public GameObject pack;
    
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
    
    // Start is called before the first frame update
    void Start()
    {
        max = 100;
        updated = 100;
        
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = updated / max;

        if (updated < 0)
        {
            updated = 0;
        }
        updated -= 50 * Time.deltaTime;

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(prefab,pack.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(prefab,pack.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(prefab,pack.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(prefab,pack.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(prefab,pack.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        
        Destroy(pack);
        c1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        c2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        c3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        c4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        c5.SetActive(true);
    }

}
