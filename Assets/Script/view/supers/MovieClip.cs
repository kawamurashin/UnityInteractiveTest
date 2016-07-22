using UnityEngine;
using System.Collections;

public class MovieClip : MonoBehaviour
{
    /// レンダラー.
    SpriteRenderer _renderer = null;

    public SpriteRenderer Renderer
    {
        get { return _renderer ?? (_renderer = gameObject.GetComponent<SpriteRenderer>()); }
    }
    // Use this for initialization
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// 座標(X).
    public float x
    {
        set
        {
            Vector3 pos = transform.position;
            pos.x = value;
            transform.position = pos;
        }
        get
        {
            return transform.position.x;
        }
    }

    /// 座標(Y).
    public float y
    {
        set
        {
            Vector3 pos = transform.position;
            pos.y = value;
            transform.position = pos;
        }
        get
        {
            return transform.position.y;
        }
    }

    /// スケール値(X).
    public float scaleX
    {
        set
        {
            Vector3 scale = transform.localScale;
            scale.x = value;
            transform.localScale = scale;
        }
        get { return transform.localScale.x; }
    }

    /// スケール値(Y).
    public float scaleY
    {
        set
        {
            Vector3 scale = transform.localScale;
            scale.y = value;
            transform.localScale = scale;
        }
        get { return transform.localScale.y; }
    }
    /// 回転角度.
    public float rotation
    {
        set { transform.eulerAngles = new Vector3(0, 0, value); }
        get { return transform.eulerAngles.z; }
    }
    public float alpha
    {
        set
        {
            var c = Renderer.color;
            c.a = value;
            Renderer.color = c;
        }
        get
        {
            var c = Renderer.color;
            return c.a;
        }
    }
}
