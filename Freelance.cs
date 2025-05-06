using System;
using System.Collections.Generic;

public class Freelance : IUser
{
    private string username;
    private string password;
    private int saldo = 0;
    private List<Lowongan> lowonganDilamar = new List<Lowongan>();
    private List<string> projekDihire = new List<string>();
    private List<Proyek> proyekList = new List<Proyek>(); // Menyimpan proyek yang di-hire dan statusnya
    private List<string> portofolio = new List<string>();
    private CV cv;
    private bool ban = false;

    public Freelance(string username, string password, CV cv)
    {
        this.username = username;
        this.password = password;
        this.cv = cv;
    }

    public int getSaldo()
    {
        return saldo;
    }

    public void cekSaldo()
    {
        Console.WriteLine("Saldo Anda Rp" + getSaldo());
    }

    public bool isBanned()
    {
        return ban;
    }

    public void banUser()
    {
        this.ban = true;
    }

    public void unban()
    {
        this.ban = false;
    }

    public string GetUsername()
    {
        return username;
    }

    public CV getCv()
    {
        return cv;
    }

    public bool CheckPassword(string password)
    {
        return this.password.Equals(password);
    }

    public void lihatPengumuman(Pengumuman pengumuman)
    {
        Console.WriteLine(pengumuman);
    }

    public void addPortfolio(string project)
    {
        portofolio.Add(project);
    }

    public void viewPortofolio()
    {
        if (portofolio.Count == 0)
        {
            Console.WriteLine("Portofolio kosong.");
        }
        else
        {
            for (int i = 0; i < portofolio.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + portofolio[i]);
            }
        }
    }

    public void melamarLowongan(Lowongan lowongan)
    {
        lowongan.AddPelamar(this);  // Menambahkan diri (freelancer) ke daftar pelamar lowongan
        lowonganDilamar.Add(lowongan);
        Console.WriteLine("Berhasil melamar lowongan: " + lowongan.GetJudul());
    }



    public void melihatLowongan(List<Lowongan> semuaLowongan)
    {
        if (semuaLowongan.Count == 0)
        {
            Console.WriteLine("Tidak ada lowongan tersedia.");
        }
        else
        {
            Console.WriteLine("Daftar Lowongan:");
            foreach (Lowongan lowongan in semuaLowongan)
            {
                Console.WriteLine(lowongan);
            }
        }
    }

    public void melihatLowonganDipilih()
    {
        if (lowonganDilamar.Count == 0)
        {
            Console.WriteLine("Belum ada lowongan yang dilamar.");
        }
        else
        {
            Console.WriteLine("Lowongan yang dilamar:");
            foreach (Lowongan lowongan in lowonganDilamar)
            {
                Console.WriteLine(lowongan);
            }
        }
    }

    public void addHiredProject(Lowongan lowongan, Client client)
    {
        string projectDetail = "Proyek: " + lowongan.GetJudul() + " dari client: " + client.GetUsername();
        projekDihire.Add(projectDetail);
        proyekList.Add(new Proyek(lowongan.GetJudul(), false)); // Tambahkan proyek ke dalam daftar proyek
    }

    public void melihatProjekHire()
    {
        if (projekDihire.Count == 0)
        {
            Console.WriteLine("Belum ada projek hire.");
        }
        else
        {
            Console.WriteLine("Daftar Projek Hire:");
            foreach (string projek in projekDihire)
            {
                Console.WriteLine(projek);
            }
        }
    }

    public void tandaiPekerjaanSelesai(string namaProyek)
    {
        bool proyekDitemukan = false;

        foreach (Proyek proyek in proyekList)
        {
            if (proyek.GetNamaProyek().Equals(namaProyek, StringComparison.OrdinalIgnoreCase) && !proyek.IsStatusSelesai())
            {
                proyek.SetStatusSelesai(true);
                Console.WriteLine("Proyek '" + namaProyek + "' telah berhasil ditandai selesai.");
                proyekDitemukan = true;
                break;
            }
        }

        if (!proyekDitemukan)
        {
            Console.WriteLine("Proyek '" + namaProyek + "' tidak ditemukan atau sudah selesai.");
        }
    }
}
