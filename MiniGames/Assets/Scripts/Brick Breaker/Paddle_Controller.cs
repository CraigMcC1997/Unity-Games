using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Controller : MonoBehaviour
{
    public float moveSpeed = 20.0f;
    float translation;

    public void increasePaddleSize()
    {
        Vector3 currentScale = this.transform.localScale;
        currentScale.x += 5.0f;
        this.transform.localScale = currentScale;
    }

    public void decreasePaddleSize()
    {
        Vector3 currentScale = this.transform.localScale;
        currentScale.x -= 5.0f;
        this.transform.localScale = currentScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x > 0)
            if (Input.GetKey(KeyCode.A))
                translation = Input.GetAxis("Horizontal") * moveSpeed;

        if (screenPos.x < Screen.width)
            if (Input.GetKey(KeyCode.D))
                translation = Input.GetAxis("Horizontal") * moveSpeed;

        // Make it move it per second instead of per frame
        translation *= Time.deltaTime;

        // Move translation along the object's y-axis
        transform.Translate(translation, 0, 0);
    }
}
