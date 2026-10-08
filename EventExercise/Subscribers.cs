namespace EventExercise;

public class HealthBar
{
    public void OnHealthChanged(object? sender, HealthChangedEventArgs e)
    {
        var player = (Player)sender!;
        int filled = e.NewHealth * 10 / player.MaxHealth;
        Console.WriteLine($"[HP] {player.Name} [{new string('#', filled)}{new string('-', 10 - filled)}] {e.NewHealth}/{player.MaxHealth}");
    }
}

public class SoundEffects
{
    public void OnHealthChanged(object? sender, HealthChangedEventArgs e)
    {
        Console.WriteLine(e.NewHealth < e.OldHealth ? "[SFX] OOF" : "[SFX] Heal sound");
    }

    public void OnDied(object? sender, EventArgs e)
    {
        Console.WriteLine("[SFX] YOU DIED. GAME OVER");
    }
}

public class GameSystem
{
    public static void OnHealthChanged(object? sender, HealthChangedEventArgs e)
    {
        Console.WriteLine("[GameSystem] Screen shake effects");
    }
    public static void OnDied(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}