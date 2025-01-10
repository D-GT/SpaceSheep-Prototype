using UnityEngine;

public class SheepStateManager : MonoBehaviour
{
    public ISheepState currentState; // State saat ini
    public Rigidbody2D rb; // Komponen Rigidbody
    public float detectionRadius = 2f; // Radius deteksi anjing
    public LayerMask dogLayer; // Layer untuk anjing

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SwitchState(new IdleState()); // Mulai dengan state Idle
    }

    void Update()
    {
        currentState.UpdateState(this); // Jalankan logika state saat ini
    }

    public void SwitchState(ISheepState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this); // Keluar dari state lama
        }

        currentState = newState;
        currentState.EnterState(this); // Masuk ke state baru
    }
}
