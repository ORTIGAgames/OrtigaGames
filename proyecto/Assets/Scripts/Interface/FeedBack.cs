using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeedBack : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image sprite;
    public float duration = .5f;
    public float distance = .1f;


    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        iniPos = transform.position + new Vector3(0, .1f, 0);
        targetPos = iniPos + new Vector3(0, distance, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > duration) Destroy(gameObject);
        else
        {
            text.alpha = (float)(duration - timer);
            sprite.CrossFadeAlpha(0, duration/3, false);
        }

        transform.position = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer / duration));
    }

    public void SetAction(int number, Sprite spritetype)
    {
        text.text = number.ToString();
        sprite.sprite = spritetype;
    }
}
