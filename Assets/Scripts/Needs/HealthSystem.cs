using System;

public class HealthSystem : NeedsSystem
{
    public override void AddValue(int value)
    {
        base.AddValue(value);
        currentValue = Math.Clamp(currentValue, 0, 100); // Ограничиваем 0-100
        UpdateUI();
    }
}