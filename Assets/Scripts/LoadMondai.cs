using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMondai : MonoBehaviour
{
    public GameObject KousikiName;
    public Sprite NoImg;
    public GameObject Image;
    // Start is called before the first frame update
    void Start()
    {
        KousikiName.GetComponent<Text>().text=PlayerPrefs.GetString("Name");
        Image.GetComponent<Image>().sprite = LoadSprite(Application.persistentDataPath + "/Kousikis/" + KousikiName.GetComponent<Text>().text + "/問題.png");
    }

    public Sprite LoadSprite(string path)
    {//指定された場所の画像を読みだしてスプライトにして返す
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

    // Update is called once per frame
    void Update()
    {
        
    }

}
