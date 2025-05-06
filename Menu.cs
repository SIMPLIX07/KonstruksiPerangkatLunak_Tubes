using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonstruksiPerangkatLunak
{
    class Menu
    {
        public static void menuUtama()
        {
            Console.WriteLine("\n========== Sistem Freelance ==========");
            Console.WriteLine("1. Register Client");
            Console.WriteLine("2. Register Freelancer");
            Console.WriteLine("3. Login Client");
            Console.WriteLine("4. Login Freelancer");
            Console.WriteLine("5. Login Admin");
            Console.WriteLine("6. Exit");
            Console.WriteLine("=====================================");
            Console.Write("Pilih menu: ");
        }

        public static void menuPerusahaan()
        {
            Console.WriteLine("\n========= Menu Client ==========");
            Console.WriteLine("1. Tambah Lowongan");
            Console.WriteLine("2. Lihat Lowongan");
            Console.WriteLine("3. Daftar Freelancer");
            Console.WriteLine("4. Hire Freelancer");
            Console.WriteLine("5. Melihat daftar Freelance yang di-hire");
            Console.WriteLine("6. Lihat Pelamar Pada Lowongan");
            Console.WriteLine("7. Proses Pembayaran");
            Console.WriteLine("8. Berikan Review");
            Console.WriteLine("9. Lihat Review");
            Console.WriteLine("10. Lihat Pengumuman");
            Console.WriteLine("11. Logout");
            Console.WriteLine("===================================");
            Console.Write("Pilih menu: ");
        }

        public static void menuPelamar()
        {
            Console.WriteLine("\n========== Menu Freelancer ==========");
            Console.WriteLine("1. Lihat Lowongan");
            Console.WriteLine("2. Lamar Lowongan");
            Console.WriteLine("3. Lihat Lowongan Dilamar");
            Console.WriteLine("4. Lihat Projek Hire");
            Console.WriteLine("5. Tambahkan Percakapan");
            Console.WriteLine("6. Tampilkan Forum");
            Console.WriteLine("7. Cek Saldo");
            Console.WriteLine("8. Tambah Portofolio");
            Console.WriteLine("9. Lihat Portofolio");
            Console.WriteLine("10. Tandai Pekerjaan Selesai");
            Console.WriteLine("11. Berikan Review untuk Client");
            Console.WriteLine("12. Tampilkan Review");
            Console.WriteLine("13. Lihat Pengumuman");
            Console.WriteLine("14. Logout");
            Console.WriteLine("======================================");
            Console.Write("Pilih menu: ");
        }

        public static void menuAdmin()
        {
            Console.WriteLine("\n========== Sistem Admin ==========");
            Console.WriteLine("1. Lihat Laporan");
            Console.WriteLine("2. Ubah Username");
            Console.WriteLine("3. Ubah Password");
            Console.WriteLine("4. Buat Pengumuman");
            Console.WriteLine("5. Ubah Pengumuman");
            Console.WriteLine("6. Exit");
            Console.WriteLine("===================================");
            Console.Write("Pilih menu: ");
        }
    }
}
