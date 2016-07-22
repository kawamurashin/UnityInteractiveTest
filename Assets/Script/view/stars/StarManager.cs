using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StarManager : MonoBehaviour {
    List<BlueStar> blueList;
    List<YellowStar> yellowList;
    Vector2 preMousePosition;
    // Use this for initialization
    void Start()
    {
        int i;
        int n;
        GameObject gameObject;
        Vector2 minStageSize = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 maxStageSize = Camera.main.ViewportToWorldPoint(Vector2.one);
        float _width = maxStageSize.x - minStageSize.x;
        float _height = maxStageSize.y - minStageSize.y;
        n = 32;
        yellowList = new List<YellowStar>();
        for (i = 0; i < n; i++)
        {
            gameObject = Instantiate(Resources.Load("prefab/Star")) as GameObject;
            YellowStar star = gameObject.GetComponent<YellowStar>();
            star.x = minStageSize.x + _width * Random.value;
            star.y = minStageSize.y + _height * Random.value;
            star.addMouseDown(mouseDownHandler);
            star.addMouseDrag(mouseDragHandler);
            star.addMouseUp(mouseUpHandler);
            yellowList.Add(star);
        }
        blueList = new List<BlueStar>();
        n = 32;
        for (i = 0; i < n; i++)
        {
            gameObject = Instantiate(Resources.Load("prefab/BlueStar")) as GameObject;
            BlueStar blueStar = gameObject.GetComponent<BlueStar>();
            blueStar.name = BlueStar.NAME;
            blueStar.x = minStageSize.x + _width * Random.value;
            blueStar.y = minStageSize.y + _height * Random.value;
            blueList.Add(blueStar);
        }

        preMousePosition = new Vector2(0, 0);
    }
    void mouseDragHandler(YellowStar star)
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + star.offset;
        star.x = currentPosition.x;
        star.y = currentPosition.y;
    }
    public void mouseDownHandler(YellowStar star)
    {
        int i;
        int n;
        //
        n = yellowList.Count;
        for (i = 0; i < n; i++)
        {
            YellowStar yellowStar = yellowList[i];
            /*
            if(yellowStar == star)
            {
                Destroy(star.gameObject);
                yellowList.Remove(star);
                break;
            }
            */
        }
    }
    public void mouseUpHandler(YellowStar star)
    {
        star.vx = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - preMousePosition.x;
        star.vy = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - preMousePosition.y;
    }
	
	// Update is called once per frame
	void Update () {
        BlueStar blueStar;
        YellowStar yellowStar;
        GameObject gameObject;
        int i;
        int n;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collder = Physics2D.OverlapPoint(mouseDownPosition);
            if (collder)
            {
                gameObject = collder.transform.gameObject;
                if (gameObject.name == BlueStar.NAME)
                {
                    blueStar = gameObject.GetComponent<BlueStar>();
                    blueStar.isDrag = true;
                    blueStar.offset = blueStar.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
                    
                }
                /*
                    if(gameObject.name == BlueStar.NAME)
                    {
                        Debug.Log("ホイ北");
                        BlueStar blueStar = gameObject.GetComponent<BlueStar>();
                        Destroy(blueStar.gameObject);
                        blueList.Remove(blueStar);
                    }

                    n = blueList.Count;
                    for(i=0;i<n;i++)
                    {
                        BlueStar blueStar = blueList[i];
                        if(blueStar.gameObject == gameObject)
                        {
                            Destroy(blueStar.gameObject);
                            blueList.Remove(blueStar);
                            break;
                        }
                    }
                    */
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            /*
            Vector3 mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collder = Physics2D.OverlapPoint(mouseDownPosition);
            if (collder)
            {
                GameObject gameObject = collder.transform.gameObject;
                if (gameObject.name == BlueStar.NAME)
                {
                    BlueStar blueStar = gameObject.GetComponent<BlueStar>();
                    blueStar.isDrag = false;
                }
            }
            */
            n = blueList.Count;
            for (i = 0; i < n; i++)
            {
                blueStar = blueList[i];
                if(blueStar.isDrag)
                {
                    blueStar.vx = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - preMousePosition.x;
                    blueStar.vy = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - preMousePosition.y;
                }
                blueStar.isDrag = false;

            }
        }
        else if (Input.GetMouseButton(0))
        {
            /*
            Vector3 mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collder = Physics2D.OverlapPoint(mouseDownPosition);
            if (collder)
            {
                gameObject = collder.transform.gameObject;
                if (gameObject.name == BlueStar.NAME)
                {
                    blueStar = gameObject.GetComponent<BlueStar>();
                    if(blueStar.isDrag)
                    {
                        gameObject.transform.position = new Vector2(mouseDownPosition.x, mouseDownPosition.y);
                    }
                }
            }
            */
            n = blueList.Count;
            for (i = 0; i < n; i++)
            {
                blueStar = blueList[i];
                if(blueStar.isDrag)
                {
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    blueStar.x = mousePosition.x + blueStar.offset.x;
                    blueStar.y = mousePosition.y + blueStar.offset.y;
                }

            }
        }

        preMousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        //move
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
        n = blueList.Count;
        for(i=0;i<n;i++)
        {
            blueStar = blueList[i];
            blueStar.vx *= 0.95f;
            blueStar.vy *= 0.95f;
            blueStar.x += blueStar.vx;
            blueStar.y += blueStar.vy;
            if (blueStar.x < min.x)
            {
                blueStar.vx *= -0.9f;
                blueStar.x = min.x;
            }
            else if (blueStar.x > max.x)
            {
                blueStar.vx *= -0.9f;
                blueStar.x = max.x;
            }

            if (blueStar.y < min.y)
            {
                blueStar.vy *= -0.9f;
                blueStar.y = min.y;
            }
            else if (blueStar.y > max.y)
            {
                blueStar.vy *= -0.9f;
                blueStar.y = max.y;
            }
        }
        n = yellowList.Count;
        for (i = 0; i < n; i++)
        {
            yellowStar = yellowList[i];
            yellowStar.vx *= 0.95f;
            yellowStar.vy *= 0.95f;
            yellowStar.x += yellowStar.vx;
            yellowStar.y += yellowStar.vy;
            if (yellowStar.x < min.x)
            {
                yellowStar.vx *= -0.9f;
                yellowStar.x = min.x;
            }
            else if (yellowStar.x > max.x)
            {
                yellowStar.vx *= -0.9f;
                yellowStar.x = max.x;
            }

            if (yellowStar.y < min.y)
            {
                yellowStar.vy *= -0.9f;
                yellowStar.y = min.y;
            }
            else if (yellowStar.y > max.y)
            {
                yellowStar.vy *= -0.9f;
                yellowStar.y = max.y;
            }
        }

    }
}
