using System;

public class CV
{
    private string nama;
    private string keahlian;
    private int pengalaman;

    public CV(string nama, string keahlian, int pengalaman)
    {
        this.nama = nama;
        this.keahlian = keahlian;
        this.pengalaman = pengalaman;
    }

    public void tampilkanCV()
    {
        Console.WriteLine("Nama: " + nama);
        Console.WriteLine("Keahlian: " + keahlian);
        Console.WriteLine("Pengalaman: " + pengalaman + " tahun");
    }

    public string getNama()
    {
        return nama;
    }

    public string getKeahlian()
    {
        return keahlian;
    }

    public int getPengalaman()
    {
        return pengalaman;
    }

    public override string ToString()
    {
        return "CV{" + "nama=" + nama + ", keahlian=" + keahlian + ", pengalaman=" + pengalaman + "}";
    }
}
