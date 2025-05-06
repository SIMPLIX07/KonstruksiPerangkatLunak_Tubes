using System;
using System.Collections.Generic;

public class Portofolio
{
    private List<string> daftarProyek;

    public Portofolio()
    {
        daftarProyek = new List<string>();
    }

    public void TambahProyek(string proyek)
    {
        daftarProyek.Add(proyek);
        Console.WriteLine("Proyek \"" + proyek + "\" berhasil ditambahkan ke portofolio.");
    }

    public void LihatProyek()
    {
        if (daftarProyek.Count == 0)
        {
            Console.WriteLine("Belum ada proyek dalam portofolio.");
        }
        else
        {
            for (int i = 0; i < daftarProyek.Count; i++)
            {
                Console.WriteLine("   " + (i + 1) + ". " + daftarProyek[i]);
            }
        }
    }
}
