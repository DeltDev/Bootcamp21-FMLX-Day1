using EventExercise;

Player player = new("John Rod");
HealthBar healthBar = new();
SoundEffects soundEffects = new();

player.HealthChanged += healthBar.OnHealthChanged;
player.HealthChanged += soundEffects.OnHealthChanged;
player.HealthChanged += GameSystem.OnHealthChanged;
player.Died += soundEffects.OnDied;
player.Died += GameSystem.OnDied;
Console.WriteLine("Commands: hit <n>, heal<n>, mute, unmute, exit");

while (true)
{
    string[] parts = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 0)
        continue;

    switch (parts[0])
    {
        case "hit" when parts.Length > 1 && int.TryParse(parts[1], out int damage):
            player.TakeDamage(damage);
            break;
        case "heal" when parts.Length > 1 && int.TryParse(parts[1], out int heal):
            player.Heal(heal);
            break;
        case "mute":
            player.HealthChanged -= soundEffects.OnHealthChanged;
            player.Died -= soundEffects.OnDied;
            Console.WriteLine("SFX Muted");
            break;
        case "unmute":
            player.HealthChanged += soundEffects.OnHealthChanged;
            player.Died += soundEffects.OnDied;
            Console.WriteLine("SFX Unmuted");
            break;
        case "exit":
            return;
    }
}