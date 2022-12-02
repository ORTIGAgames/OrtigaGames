using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeedBack : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image sprite;
    public float distance;


    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;
    private float duration = 2;
    void Start()
    {
        iniPos = transform.position + new Vector3(0, .1f, 0);
        targetPos = iniPos + new Vector3(0, distance, 0);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > duration) Destroy(gameObject);
        else
        {
            if (text)
            {
                text.alpha = (float)(duration - timer);
                sprite.CrossFadeAlpha(0, duration / 3, false);
            }
        }

        transform.position = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer / duration));
    }

    public void SetAction(int number, Sprite spritetype, float dura)
    {
        duration = dura;
        if (number >= 0) text.text = number.ToString();
        else text = null;
        sprite.sprite = spritetype;
    }
}
