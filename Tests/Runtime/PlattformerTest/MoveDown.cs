using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    float angle = 0;
    Vector3 startPos;
    [SerializeField]
    float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        Time.timeScale = 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angle += Time.deltaTime;
        this.transform.position += ((angle % 2 < 1) ? Vector3.down : Vector3.up)*Time.deltaTime*speed;
    }
}
