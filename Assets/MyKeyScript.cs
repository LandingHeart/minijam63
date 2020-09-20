using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform startingpoint;
    public Rigidbody2D rb;
    public Animator _anim;
    public GameObject level1Platform;

    public GameObject nowPlatform1;

    public GameObject nowbackground;
    public GameObject futureBackground;
    public SceneManagerScript manager;
    public int count;
    private void Start()
    {
        count = 0;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(NextPlatform());
        }
    }

    IEnumerator NextPlatform()
    {
        _anim.SetTrigger("LevelUp");
        rb.velocity = Vector2.zero;
        level1Platform.SetActive(false);
        nowPlatform1.SetActive(true);
        nowbackground.SetActive(true);
        futureBackground.SetActive(false);
        yield return new WaitForSeconds(3f);
        player.position = startingpoint.position;
        count++;
        if(count == 2)
        {
            manager.nextLevel();
        }
        Level1Script.clear = true;
        
        
    }
}
