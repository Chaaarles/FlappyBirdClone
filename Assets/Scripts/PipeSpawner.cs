using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float interval;
    public GameObject pipes;

    private float _timer;

    // Update is called once per frame
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Instantiate(pipes);
            _timer += interval;
        }
    }

    private void OnEnable()
    {
        _timer = 2.5f;
    }
}