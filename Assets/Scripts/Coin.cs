using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    public static event Action Collected;

    [SerializeField] float spinSpeed = 180f; // graus/s

    void Awake() => GetComponent<Collider>().isTrigger = true;

    void Update() => transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f, Space.World);

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        gameObject.SetActive(false);
        Collected?.Invoke();
    }
}
