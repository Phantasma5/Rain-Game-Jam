using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    [SerializeField]
    GameObject mainLight;
    float flashTime;

    // Start is called before the first frame update
    void Start()
    {
        if(mainLight == null)
            mainLight = GameObject.FindGameObjectWithTag("MainLight");
        mainLight.SetActive(false);
        flashTime = Random.Range(5, 30);
    }

    // Update is called once per frame
    void Update()
    {
        flashTime -= Time.deltaTime;
        if(flashTime < 0)
        {
            StartCoroutine("LightningFlash");
            flashTime = Random.Range(5, 30);
        }
    }

    public IEnumerator LightningFlash()
    {
        mainLight.SetActive(true);
        yield return new WaitForSeconds(.5f);
        mainLight.SetActive(false);
        yield return new WaitForSeconds(.2f);
        mainLight.SetActive(true);
        yield return new WaitForSeconds(.1f);
        mainLight.SetActive(false);
    }
}
