public interface ISheepState
{
    void EnterState(SheepStateManager sheep); // Ketika state dimulai
    void UpdateState(SheepStateManager sheep); // Logika setiap frame
    void ExitState(SheepStateManager sheep); // Ketika state berakhir
}
