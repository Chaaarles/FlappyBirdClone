using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(3.8f * Random.value * 2f - 3.8f, Random.value * 4, 1);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.left * (GameManager.PipeSpeed * Time.deltaTime * 0.3f);
        if (transform.position.x <= -3.8)
            transform.position = new Vector3(3.8f + Random.value * 2f, Random.value * 4, 1);
    }
}