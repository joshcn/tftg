using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise : MonoBehaviour
{
    public float horizontal;
    float vertical;

    Animation anim;

    // ***** Create your variable here *****\\

    public float speed = 15.0f ;
    public bool greenlight = true;
    public int waitTime = 5;
    public int min = 0;
    public int max = 10;
    public int xval = 0;
    public int yval = 1;

    void Start()
    {
        anim = GetComponent<Animation>();
        currentHealth = 5;
        StartCoroutine(GenerateScore());
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 position = transform.position;

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Light Attack");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Heavy Attack");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }


    }
    void FixedUpdate()
    {
        // ***** Change the Hard Coded values to be variable instead *****\\
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical * speed * Time.deltaTime);
    }

    IEnumerator GenerateScore()
    {
        // ***** Change the Hard Coded true value to be variable instead *****\\
        while (greenlight)
        {
            // ***** Change the Hard Coded values to be variable instead *****\\
            yield return new WaitForSeconds(waitTime);
            int index = Random.Range(min, max);

            // ***** Change the Hard Coded true value to be variable instead *****\\
            if (greenlight)
            {
                Debug.Log("Score increasing");
            }

        }
    }

    void LaunchProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        // ***** Change the Hard Coded Vector2 value to be variable instead *****\\
        projectile.Launch(new Vector2(xval, yval), 300);

        animator.SetTrigger("Launch");
        audioSource.PlayOneShot(shootingSound);
    }


}