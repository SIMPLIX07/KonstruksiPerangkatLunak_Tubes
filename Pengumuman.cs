public class Pengumuman
{
    private string isiPengumuman;

    public Pengumuman()
    {
        this.isiPengumuman = "Belum ada pengumuman saat ini.";
    }

    public string GetIsiPengumuman()
    {
        return isiPengumuman;
    }

    public void SetIsiPengumuman(string isiPengumuman)
    {
        this.isiPengumuman = isiPengumuman;
    }

    public override string ToString()
    {
        return "Pengumuman: " + isiPengumuman;
    }
}
