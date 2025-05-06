public class Client : IUser
{
    private string username;
    private string password;
    private Dictionary<string, Lowongan> daftarLowongan = new Dictionary<string, Lowongan>();
    private List<Freelance> hiredFreelancers = new List<Freelance>();
    private List<Lowongan> lowonganDihire = new List<Lowongan>();

    public Client(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public string GetUsername()
    {
        return username;
    }

    public bool CheckPassword(string password)
    {
        return this.password.Equals(password);
    }

    public void lihatPengumuman(Pengumuman pengumuman)
    {
        Console.WriteLine(pengumuman);
    }

    public void tambahLowongan(string judul, string deskripsi)
    {
        // Generate ID secara otomatis menggunakan UUID
        string id = Guid.NewGuid().ToString();
        Lowongan lowongan = new Lowongan(judul, deskripsi, username);
        daftarLowongan.Add(id, lowongan);
        Console.WriteLine("Lowongan berhasil ditambahkan dengan ID: " + id);
    }
    public void checkLowongan(string judul)
    {
        bool ditemukan = false;
        Lowongan lowonganDitemukan = null; // Buat variabel untuk menyimpan lowongan yang cocok

        foreach (var lowongan in daftarLowongan.Values)
        {
            if (lowongan.GetJudul() == judul)
            {
                ditemukan = true;
                lowonganDitemukan = lowongan; // Simpan objeknya
                break;
            }
        }

        if (ditemukan)
        {
            Console.WriteLine("Lowongan ditemukan");
            lowonganDitemukan.GetPelamar(); // Sekarang bisa diakses karena sudah disimpan
        }
        else
        {
            Console.WriteLine("Lowongan tidak ditemukan");
        }
    }



    public void melihatLowongan()
    {
        if (daftarLowongan.Count == 0)
        {
            Console.WriteLine("Belum ada lowongan yang dibuat.");
        }
        else
        {
            Console.WriteLine("Daftar Lowongan:");
            foreach (var entry in daftarLowongan)
            {
                Console.WriteLine("ID: " + entry.Key);
                Console.WriteLine(entry.Value);
                Console.WriteLine("");
            }
        }
    }

    public void viewFreelancerPortofolio(Freelance freelancer)
    {
        Console.WriteLine(username + freelancer.GetUsername());
        freelancer.viewPortofolio(); // Memanggil metode viewPortofolio milik freelancer
    }

    public void melihatDaftarFreelance(List<Freelance> freelancers)
    {
        Console.WriteLine("Daftar Freelancer:");
        for (int i = 0; i < freelancers.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + freelancers[i].getCv().getNama()
                    + "\nKeahlian : " + freelancers[i].getCv().getKeahlian()
                    + "\nPengalaman : " + freelancers[i].getCv().getPengalaman()
            );
            Console.WriteLine("Portofolio:");
            freelancers[i].viewPortofolio();
            Console.WriteLine("");
        }
    }

    public void hireFreelancer(List<Freelance> freelancers)
    {
        if (daftarLowongan.Count == 0)
        {
            Console.WriteLine("Anda harus memiliki setidaknya satu proyek untuk dapat hire freelancer.");
            return;
        }

        Console.WriteLine("Daftar Freelancer:");
        for (int i = 0; i < freelancers.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + freelancers[i].getCv().getNama());
        }

        Console.Write("Pilih freelancer (masukkan nomor): ");
        int pilihanFreelancer;
        if (!int.TryParse(Console.ReadLine(), out pilihanFreelancer))
        {
            Console.WriteLine("Input tidak valid.");
            return;
        }

        if (pilihanFreelancer < 1 || pilihanFreelancer > freelancers.Count)
        {
            Console.WriteLine("Pilihan tidak valid.");
            return;
        }

        Freelance selectedFreelancer = freelancers[pilihanFreelancer - 1];

        Console.WriteLine("Pilih proyek untuk freelancer ini:");
        foreach (var entry in daftarLowongan)
        {
            Console.WriteLine("ID: " + entry.Key + " - " + entry.Value.GetJudul());
        }

        Console.Write("Masukkan ID proyek: ");
        string idProyek = Console.ReadLine();

        if (!daftarLowongan.ContainsKey(idProyek))
        {
            Console.WriteLine("ID proyek tidak valid.");
            return;
        }

        Lowongan selectedLowongan = daftarLowongan[idProyek];
        hiredFreelancers.Add(selectedFreelancer);
        lowonganDihire.Add(selectedLowongan);

        selectedFreelancer.addHiredProject(selectedLowongan, this);
        Console.WriteLine("Freelancer " + selectedFreelancer.GetUsername() + " berhasil di-hire untuk proyek: " + selectedLowongan.GetJudul());
    }

    public void melihatFreelancerHired()
    {
        if (hiredFreelancers.Count == 0)
        {
            Console.WriteLine("Belum ada freelancer yang di-hire.");
        }
        else
        {
            Console.WriteLine("Daftar Freelancer yang di-hire:");
            for (int i = 0; i < hiredFreelancers.Count; i++)
            {
                Freelance freelancer = hiredFreelancers[i];
                Lowongan proyek = lowonganDihire[i];
                Console.WriteLine((i + 1) + ". " + freelancer.getCv().getNama() + " untuk proyek: " + proyek.GetJudul());
            }
        }
    }

    // Getter untuk daftarLowongan
    public Dictionary<string, Lowongan> GetDaftarLowongan()
    {
        return daftarLowongan;
    }
}
