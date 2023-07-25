using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(3.5f, Random.value * 5 - 2, 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.left * (Time.deltaTime * GameManager.PipeSpeed);
        if (transform.position.x < -3.5) Destroy(gameObject);
    }
}