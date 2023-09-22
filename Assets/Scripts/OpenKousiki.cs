using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenKousiki : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        PlayerPrefs.SetString("Name", gameObject.transform.Find("Text").GetComponent<Text>().text);
        PlayerPrefs.Save();
        SceneManager.LoadScene("KousikiSetumei");
    }
}
