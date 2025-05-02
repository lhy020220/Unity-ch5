using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");  // A/D 또는 ←/→ 입력
        transform.Translate(Vector3.right * moveX * moveSpeed * Time.deltaTime);
    }
}
