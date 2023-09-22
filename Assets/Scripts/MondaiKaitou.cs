using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class MondaiKaitou : MonoBehaviour
{
    public GameObject KousikiName;
    public GameObject Kaito;
    public Sprite NoImg;
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
        string kaito = "";
        if (File.Exists(Application.persistentDataPath + "/Kousikis/" + KousikiName.GetComponent<Text>().text + "/��A.png"))
        {
            kaito="A";
        }
        if (File.Exists(Application.persistentDataPath + "/Kousikis/" + KousikiName.GetComponent<Text>().text + "/��B.png"))
        {
            kaito = "B";
        }
        if (File.Exists(Application.persistentDataPath + "/Kousikis/" + KousikiName.GetComponent<Text>().text + "/��C.png"))
        {
            kaito = "C";
        }
        if (File.Exists(Application.persistentDataPath + "/Kousikis/" + KousikiName.GetComponent<Text>().text + "/��D.png"))
        {
            kaito = "D";
        }
        Kaito.SetActive(true);
        if (kaito== gameObject.name) {
            Kaito.transform.Find("OUT").GetComponent<Text>().text="����!";
        }
        else
        {
            Kaito.transform.Find("OUT").GetComponent<Text>().text = "�s�����@������"+kaito;
        }
        Kaito.transform.Find("Image").GetComponent<Image>().sprite = LoadSprite(Application.persistentDataPath + "/Kousikis/" + KousikiName.GetComponent<Text>().text + "/��"+kaito+".png");
    }

    public Sprite LoadSprite(string path)
    {//�w�肳�ꂽ�ꏊ�̉摜��ǂ݂����ăX�v���C�g�ɂ��ĕԂ�
        Sprite sprite = NoImg;
        if (path != "")
        {
            var rawData = System.IO.File.ReadAllBytes(path);
            Texture2D texture2D = new Texture2D(0, 0);
            texture2D.LoadImage(rawData);
            sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f, 0, SpriteMeshType.FullRect);
        }
        return sprite;
    }

    public void CloseKaito()
    {
        Kaito.SetActive(false);
    }

    public void CloseMondai()
    {
        PlayerPrefs.SetString("Name", KousikiName.GetComponent<Text>().text);
        PlayerPrefs.Save();
        SceneManager.LoadScene("KousikiSetumei");
    }
}
