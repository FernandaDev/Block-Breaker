using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject breakBlockFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    int timesHit = 0;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (gameObject.tag == "Breakable")
        {
            GameManager.instance.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;

        if (timesHit >= maxHits)
        {
            GameManager.instance.gameStatus.AddToScore();
            timesHit = 0;
            GetDestroyed();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        if (hitSprites == null) return;

        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
            spriteRenderer.sprite = hitSprites[spriteIndex];
    }

    void GetDestroyed()
    {
        GameManager.instance.OnBlockDestroyed();

        Instantiate(breakBlockFX, transform.position, transform.rotation);

        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        this.gameObject.SetActive(false);
    }
}
