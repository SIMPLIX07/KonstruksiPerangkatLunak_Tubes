using System;

public class Pembayaran
{
    private Client client;
    private Freelance freelancer;
    private double jumlahBayar;
    private bool statusSelesai;

    public Pembayaran(Client client, Freelance freelancer, double jumlahBayar)
    {
        this.client = client;
        this.freelancer = freelancer;
        this.jumlahBayar = jumlahBayar;
        this.statusSelesai = false;
    }

    public void ProsesPembayaran()
    {
        Console.WriteLine();
        Console.WriteLine("! Konfirmasi Pembayaran !");
        Console.WriteLine("Client: " + client.GetUsername());
        Console.WriteLine("Freelancer: " + freelancer.GetUsername());
        Console.WriteLine("Jumlah Bayar: Rp " + jumlahBayar);
        Console.WriteLine("Apakah proyek ini sudah selesai? (yes/no): ");
        string konfirmasi = Console.ReadLine();

        if (konfirmasi.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            statusSelesai = true;
            Console.WriteLine("Proyek telah selesai.");
            Console.WriteLine();
            Console.WriteLine("Memproses pembayaran...");

            if (PotongSaldoClient(jumlahBayar))
            {
                TambahSaldoFreelancer(jumlahBayar);
                Console.WriteLine("Pembayaran berhasil diproses!");
                Console.WriteLine("Saldo client telah dipotong.");
                Console.WriteLine("Saldo freelancer telah ditambahkan.");
            }
            else
            {
                Console.WriteLine("Gagal memproses pembayaran. Saldo client tidak mencukupi.");
            }
        }
        else
        {
            Console.WriteLine("Proyek belum selesai. Pembayaran ditunda.");
        }
    }

    private bool PotongSaldoClient(double jumlah)
    {
        double saldoClient = 100000; // sementara saldo client hardcode
        if (saldoClient >= jumlahBayar)
        {
            saldoClient -= jumlahBayar;
            Console.WriteLine("Saldo client sekarang: Rp " + saldoClient);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void TambahSaldoFreelancer(double jumlah)
    {
        double saldoFreelancer = 0; // sementara saldo freelancer hardcode
        saldoFreelancer += jumlah;
        Console.WriteLine("Saldo freelancer sekarang: Rp " + saldoFreelancer);
    }

    public bool IsStatusSelesai()
    {
        return statusSelesai;
    }
}
