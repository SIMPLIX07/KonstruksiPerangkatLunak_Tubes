using System;
using System.Collections.Generic;

public class Forum
{
    private List<string> percakapan;
    private List<string> from;

    // Konstruktor untuk inisialisasi List
    public Forum()
    {
        percakapan = new List<string>();
        from = new List<string>();
    }

    public List<string> GetPercakapan()
    {
        return percakapan;
    }

    public void SetPercakapan(List<string> percakapan)
    {
        this.percakapan = percakapan;
    }

    public List<string> GetFrom()
    {
        return from;
    }

    public void SetFrom(List<string> from)
    {
        this.from = from;
    }

    public void TambahPercakapan(string dari, string pesan)
    {
        // pesan tidak boleh kosong
        if (!string.IsNullOrWhiteSpace(pesan))
        {
            percakapan.Add(pesan);
            from.Add(dari);
            Console.WriteLine("Pesan berhasil ditambahkan: " + pesan);
        }
        else
        {
            Console.WriteLine("Pesan tidak valid. Tidak ada yang ditambahkan.");
        }
    }

    public void TampilkanPercakapan()
    {
        Console.WriteLine("Daftar Percakapan:");
        for (int i = 0; i < percakapan.Count; i++)
        {
            Console.WriteLine(from[i] + ": " + percakapan[i]);
        }
    }
}
