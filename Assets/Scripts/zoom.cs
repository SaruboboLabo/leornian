using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class zoom: MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 mouseStartPos;
    float dist0 = 0f;
    float dist1 = 0f;
    float scale = 0f;
    float oldDist = 0f;//前回の2点間の距離
    float minRate = 0.7f;
    float maxRate = 4f;
    bool button;
    bool select;
    Vector3 v = Vector3.zero;
    //-----------------------------------
    void Start()
    {
        button = false;
        //使わない
        //ScaleAround(gameObject, new Vector3(0, 0, 0), new Vector3(2, 2, 0));
    }

    public void Down()
    {

        //パソコン上だと2点タッチが使えないのでパソコンで拡大縮小を試すときはここを使う
        /*
        if (button) {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("tracksize");
            foreach (GameObject ball in objects)
            {
                ball.transform.localScale = new Vector3(1 / 2, 1 / 2, 0);
            }
            button = false;
            ScaleAround(gameObject, new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0), new Vector3(2, 2, 0));
            Debug.Log(Input.mousePosition);
        }
        else
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("tracksize");
            foreach (GameObject ball in objects)
            {
                ball.transform.localScale = new Vector3(1, 1, 0);
            }
            button = true;
            ScaleAround(gameObject, new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0), new Vector3(1, 1, 0));
            Debug.Log(Input.mousePosition);
        }
        */

        startPos = Camera.main.WorldToScreenPoint(transform.position);
        //ドラッグを開始したときのマウスの位置
        mouseStartPos = Input.mousePosition;
        /*
        if (Input.touchCount >= 2)
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);
            mouseStartPos = new Vector3((t1.position.x + t2.position.x) / 2f - Screen.width / 2, (t1.position.y + t2.position.y) / 2f - Screen.height / 2, 1);
        }
        */
        select = true;
    }

    public void Up()
    {
        select = false;
    }
    //-----------------------------------
    void Update()
    {
        if (select&& (Input.touchCount == 1))//画像のドラッグ
        {
            Vector3 t1 = Input.mousePosition;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(startPos.x + t1.x - mouseStartPos.x, startPos.y + t1.y - mouseStartPos.y, 1));
        }
        if (Input.touchCount >= 2)
        {

            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);
            if (t2.phase == TouchPhase.Began)
            {
                Destroy(GameObject.Find("big(Clone)"));
                Destroy(GameObject.Find("delete(Clone)"));
                dist0 = Vector2.Distance(t1.position, t2.position);
                oldDist = dist0;
            }
            else if (t1.phase == TouchPhase.Moved && t2.phase == TouchPhase.Moved)
            {
                dist1 = Vector2.Distance(t1.position, t2.position);
                if (dist0 < 0.001f || dist1 < 0.001f)
                {
                    return;
                }
                else
                {
                    v = transform.localScale;
                    scale = v.x;
                    scale += (dist1 - oldDist) / 200f;
                    if (scale > maxRate) { scale = maxRate; }
                    if (scale < minRate) { scale = minRate; }
                    oldDist = dist1;
                }
                Vector3 center = new Vector3((t1.position.x + t2.position.x) / 2f - Screen.width / 2, (t1.position.y + t2.position.y) / 2f - Screen.height / 2, 1);//タッチされている2つの座標の中点を計算
                ScaleAround(gameObject, center, new Vector3(scale, scale, 0));//中点中心に拡大させる

                //gameObject.transform.localScale = new Vector3(scale, scale, 0);
                //Vector3 t3 = center;
                //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(startPos.x + t3.x - mouseStartPos.x, startPos.y + t3.y - mouseStartPos.y, 1));
            }
        }
    }
    public void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)//任意座標中心に拡大する関数
    {
        Vector3 targetPos = target.transform.localPosition;
        Vector3 diff = targetPos - pivot;
        float relativeScale = newScale.x / target.transform.localScale.x;

        Vector3 resultPos = pivot + diff * relativeScale;
        target.transform.localScale = newScale;
        resultPos.z = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 1)).z;
        target.transform.localPosition = resultPos;

    }
}
