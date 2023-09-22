using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CloneKosikiButton : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        SafeCreateDirectory(Application.persistentDataPath + "/Kousikis");
        string[] filePaths = Directory.GetDirectories(Application.persistentDataPath + "/Kousikis");
        foreach (string filePath in filePaths)//MyNoteフォルダ内にあるファイルをすべて取得
        {
            GameObject NewMarker = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity, parent.transform) as GameObject;
            //Debug.Log(filePath);
            string str = Path.GetFileName(filePath);//ファイル名のみ取得
            NewMarker.transform.Find("Button").transform.Find("Text").GetComponent<Text>().text = str;//ボタンのテキストをファイル名にする
            NewMarker.name = str;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public static DirectoryInfo SafeCreateDirectory(string path)
        {
            //ディレクトリが存在しているかの確認 なければ生成
            if (Directory.Exists(path))
            {
                return null;
            }
            return Directory.CreateDirectory(path);
        }
    }
