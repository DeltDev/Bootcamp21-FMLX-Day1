namespace EventExercise;

public class HealthChangedEventArgs(int oldHealth, int newHealth) : EventArgs
{
    public readonly int OldHealth = oldHealth;
    public readonly int NewHealth = newHealth;
}

public class Player
{
    public string Name { get; }
    public int MaxHealth { get; } = 100;
    public int CurrentHealth { get; private set; }
    public event EventHandler<HealthChangedEventArgs>? HealthChanged;
    public event EventHandler? Died;
    public Player(string name)
    {
        Name = name;
        CurrentHealth = MaxHealth;
    }
    public void TakeDamage(int damage) => SetHealth(CurrentHealth - damage);
    public void Heal(int heal) => SetHealth(CurrentHealth + heal);

    private void SetHealth(int health)
    {
        if (CurrentHealth == 0)
        {
            return;
        }

        int oldHealth = CurrentHealth;
        CurrentHealth = Math.Clamp(health, 0, MaxHealth);
        OnHealthChanged(new HealthChangedEventArgs(oldHealth, CurrentHealth));
        if (CurrentHealth == 0)
        {
            OnDied();
        }
    }

    protected virtual void OnHealthChanged(HealthChangedEventArgs e) => HealthChanged?.Invoke(this, e);
    protected virtual void OnDied() => Died?.Invoke(this, EventArgs.Empty);
}