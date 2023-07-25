using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.left * (GameManager.PipeSpeed * Time.deltaTime);
        if (transform.position.x <= -5.76) transform.position += Vector3.right * (5.76f * 2f);
    }
}