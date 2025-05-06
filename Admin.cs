using System;
using System.Collections.Generic;

/**
 * Class Admin untuk mengelola pengguna dan pengumuman.
 */
public class Admin : IUser
{
    private string Id;
    private string username;
    private string password;
    private List<string> UserBan = new List<string>();
    private List<Freelance> freelancers = new List<Freelance>();
    private Pengumuman pengumuman = new Pengumuman(); // Pengumuman sebagai atribut admin

    public Admin(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public Admin(string Id)
    {
        this.Id = Id;
    }

    // Membuat pengumuman baru
    public void buatPengumuman(string isi)
    {
        pengumuman.SetIsiPengumuman(isi);
        Console.WriteLine("Pengumuman berhasil dibuat!");
    }

    // Mengubah pengumuman yang ada
    public void ubahPengumuman(string isiBaru)
    {
        pengumuman.SetIsiPengumuman(isiBaru);
        Console.WriteLine("Pengumuman berhasil diubah!");
    }

    // Menampilkan pengumuman
    public void tampilkanPengumuman()
    {
        Console.WriteLine(pengumuman);
    }

    public string getPassword()
    {
        return password;
    }

    public string GetUsername()
    {
        return username;
    }

    public bool CheckPassword(string password)
    {
        return this.password.Equals(password);
    }

    public void laporkanPelanggar(string pelanggar)
    {
        UserBan.Add(pelanggar); // Menambahkan nama pelanggar ke dalam array UserBan
        Console.WriteLine("Freelancer " + pelanggar + " berhasil dilaporkan.");
    }

    public List<string> getUserBan()
    {
        return UserBan;
    }

    public void deleteAkunFreelancer(string username)
    {
        for (int i = 0; i < freelancers.Count; i++)
        {
            Freelance freelancer = freelancers[i];
            if (freelancer.GetUsername().Equals(username))
            {
                freelancer.banUser();
                freelancers.RemoveAt(i);
                Console.WriteLine("Akun freelancer " + username + " telah dibanned dan dihapus.");
                return;
            }
        }
        Console.WriteLine("Freelancer dengan username " + username + " tidak ditemukan.");
    }

    public void setUsername(string username)
    {
        this.username = username;
    }

    public void setPassword(string password)
    {
        this.password = password;
    }
}
