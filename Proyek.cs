public class Proyek
{
    private string namaProyek;
    private bool statusSelesai;

    public Proyek(string namaProyek, bool statusSelesai)
    {
        this.namaProyek = namaProyek;
        this.statusSelesai = statusSelesai;
    }

    public string GetNamaProyek()
    {
        return namaProyek;
    }

    public bool IsStatusSelesai()
    {
        return statusSelesai;
    }

    public void SetStatusSelesai(bool statusSelesai)
    {
        this.statusSelesai = statusSelesai;
    }
}
