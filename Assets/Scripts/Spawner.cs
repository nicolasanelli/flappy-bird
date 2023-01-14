using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawmRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 3f;

    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawmRate, spawmRate);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
