using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZA_WORDO : MonoBehaviour
{

    AudioSource Source;
    Collider2D Collider;

    int pause = 0;
    // Start is called before the first frame update

    public float timeRemaining = 4;
    void Update()
    {
        if(pause == 1)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.unscaledDeltaTime;
                print(timeRemaining);
            }
            else
            {
                pause = 2;
                Time.timeScale = 1;
                print('1');
            }
        }

    }

    private void Start()
    {
        Source = GetComponent<AudioSource>();
        Collider = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (pause <= 0)
        {
            Source.Play();
            print('s');
            Time.timeScale = 0;
            pause++;
            print('4');
        }
    }
}
