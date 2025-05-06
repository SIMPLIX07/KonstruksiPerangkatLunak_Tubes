public class StatusPekerjaan
{
    private string status;

    public StatusPekerjaan()
    {
        this.status = string.Empty; // Default value set to empty string
    }

    public void SetStatus(string status)
    {
        this.status = status;
    }

    public string GetStatus()
    {
        return this.status;
    }
}
