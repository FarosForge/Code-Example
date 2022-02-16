using System;

public class Wallet
{
    public int currency { get; private set; }
    public void Init()
    {
        Load();
    }
    private void Load()
    {
        if(SaveSystem.HasKey("CURRENCY"))
            currency = SaveSystem.LoadInt("CURRENCY");
    }
    private void Save()
    {
        SaveSystem.Save("CURRENCY", currency);
    }
    public void AddCurrency(int val)
    {
        currency += val;
        Save();
    }
    public void RemoveCurrency(int val)
    {
        currency -= val;

        if(currency <= 0)
        {
            currency = 0;
        }

        Save();
    }
}
