public class Lowongan
{
    private string judul;
    private string deskripsi;
    private string client;
    private int harga;
    private List<Freelance> pelamar;

    public Lowongan(string judul, string deskripsi, string client)
    {
        this.judul = judul;
        this.deskripsi = deskripsi;
        this.client = client;
        this.harga = 0; // Atau harga default yang sesuai
        this.pelamar = new List<Freelance>(); // Inisialisasi list pelamar
    }

    public void AddPelamar(Freelance pelamar)
    {
        this.pelamar.Add(pelamar);
    }

    public void GetPelamar()
    {
        for (int i = 0; i < pelamar.Count; i++)
        {
            Console.WriteLine($"Pelamar {i + 1}: Nama: {pelamar[i].GetUsername()}");
        }
    }

    public string GetJudul()
    {
        return judul;
    }

    public string GetDeskripsi()
    {
        return deskripsi;
    }

    public string GetClient()
    {
        return client;
    }

    public int GetHarga()
    {
        return harga;
    }

    public override string ToString()
    {
        return "Lowongan: " + judul + "\nDeskripsi: " + deskripsi + "\nDibuat oleh: " + client;
    }
}
