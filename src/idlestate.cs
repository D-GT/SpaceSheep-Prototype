// Nama File: idlestate.cs
// Fungsi: State idle untuk sheep dan pergerakan randomnya
using UnityEngine;

public class IdleState : ISheepState
{
    private Vector3 randomDirection;
    private float changeDirectionTimer;

    public void EnterState(SheepStateManager sheep)
    {
        SetRandomDirection();
    }

    public void UpdateState(SheepStateManager sheep)
    {
        // Pergerakan santai
        sheep.rb.velocity = randomDirection * 1f; // Kecepatan idle

        // Ubah arah secara berkala
        changeDirectionTimer -= Time.deltaTime;
        if (changeDirectionTimer <= 0)
        {
            SetRandomDirection();
        }

        // Deteksi anjing dalam radius
        Collider2D dog = Physics2D.OverlapCircle(sheep.transform.position, sheep.detectionRadius, sheep.dogLayer);
        if (dog)
        {
            sheep.SwitchState(new RunState(dog.transform));
        }
    }

    public void ExitState(SheepStateManager sheep)
    {
        // Tidak ada logika tambahan saat keluar dari Idle
    }

    private void SetRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        changeDirectionTimer = Random.Range(2f, 5f);
    }
}
