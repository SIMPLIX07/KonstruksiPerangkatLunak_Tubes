using KonstruksiPerangkatLunak;
using System;
using System.Collections.Generic;

namespace TubesFreelance
{
    class Program
    {
        static void Main(string[] args)
        {
            var clients = new List<Client>();
            var freelancers = new List<Freelance>();
            var semuaLowongan = new List<Lowongan>();
            var pembayaranList = new List<Pembayaran>();
            var clientReviews = new List<ClientReview>();
            var freelancerReviews = new List<FreelancerReview>();
            var admin = new Admin("admin123", "admin123");
            var forum = new Forum();

            while (true)
            {
                Menu.menuUtama();
                int pilihan = int.Parse(Console.ReadLine());

                if (pilihan == 1)
                {
                    Console.Write("Masukkan username: ");
                    string username = Console.ReadLine();
                    Console.Write("Masukkan password: ");
                    string password = Console.ReadLine();
                    clients.Add(new Client(username, password));
                    Console.WriteLine("Client berhasil didaftarkan!");
                }
                else if (pilihan == 2)
                {
                    Console.Write("Masukkan username: ");
                    string username = Console.ReadLine();
                    Console.Write("Masukkan password: ");
                    string password = Console.ReadLine();
                    Console.Write("Masukkan nama: ");
                    string nama = Console.ReadLine();
                    Console.Write("Masukkan keahlian: ");
                    string keahlian = Console.ReadLine();
                    Console.Write("Masukkan pengalaman (tahun): ");
                    int pengalaman;
                    while (true)
                    {
                        try
                        {
                            pengalaman = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Input tidak valid. Harap masukkan angka!");
                            Console.Write("Masukkan pengalaman (tahun): ");
                        }
                    }
                    CV cv = new CV(nama, keahlian, pengalaman);
                    freelancers.Add(new Freelance(username, password, cv));
                    Console.WriteLine("Freelancer berhasil didaftarkan!");
                }
                else if (pilihan == 3)
                {
                    Console.Write("Masukkan username: ");
                    string username = Console.ReadLine();
                    Console.Write("Masukkan password: ");
                    string password = Console.ReadLine();

                    Client loggedInClient = null;
                    foreach (var client in clients)
                    {
                        if (client.GetUsername() == username && client.CheckPassword(password))
                        {
                            loggedInClient = client;
                            break;
                        }
                    }

                    if (loggedInClient != null)
                    {
                        Console.WriteLine("Login berhasil!");
                        while (true)
                        {
                            //MenuPerusahaan_______________________________________________________________________________________
                            Menu.menuPerusahaan();
                            int menuClient = int.Parse(Console.ReadLine());

                            if (menuClient == 1)
                            {
                                Console.Write("Masukkan judul lowongan: ");
                                string judul = Console.ReadLine();
                                Console.Write("Masukkan deskripsi lowongan: ");
                                string deskripsi = Console.ReadLine();
                                loggedInClient.tambahLowongan(judul, deskripsi);
                                Lowongan lowongan = new Lowongan(judul, deskripsi, loggedInClient.GetUsername());
                                semuaLowongan.Add(lowongan);  // Pastikan lowongan yang baru dibuat ditambahkan ke semuaLowongan
                            }
                            else if (menuClient == 2)
                            {
                                loggedInClient.melihatLowongan();
                            }
                            else if (menuClient == 3)
                            {
                                loggedInClient.melihatDaftarFreelance(freelancers);
                            }
                            else if (menuClient == 4)
                            {
                                Console.Write("Masukkan username freelancer yang ingin di-hire: ");
                                string usernameFreelancer = Console.ReadLine();
                                Freelance freelancerToHire = null;
                                foreach (var freelancer in freelancers)
                                {
                                    if (freelancer.GetUsername() == usernameFreelancer)
                                    {
                                        freelancerToHire = freelancer;
                                        break;
                                    }
                                }
                                if (freelancerToHire != null)
                                {
                                    List<Freelance> freelancerList = new List<Freelance> { freelancerToHire };
                                    loggedInClient.hireFreelancer(freelancerList);
                                    Console.WriteLine($"Freelancer {usernameFreelancer} berhasil di-hire!");
                                }
                                else
                                {
                                    Console.WriteLine("Freelancer tidak ditemukan.");
                                }
                            }
                            else if (menuClient == 5)
                            {
                                loggedInClient.melihatFreelancerHired();
                            }
                            else if (menuClient == 6)
                            {
                                Console.WriteLine("Masukan judul lowongan yang ingin dicheck pelamarnya: ");
                                string masukan6 = Console.ReadLine();
                                loggedInClient.checkLowongan(masukan6);
                            }

                            else if (menuClient == 7)
                            {
                                Console.Write("Masukkan username freelancer: ");
                                string usernameFreelancer = Console.ReadLine();
                                Console.Write("Masukkan jumlah pembayaran: ");
                                double jumlahBayar = double.Parse(Console.ReadLine());
                                Freelance freelancerToPay = null;
                                foreach (var freelancer in freelancers)
                                {
                                    if (freelancer.GetUsername() == usernameFreelancer)
                                    {
                                        freelancerToPay = freelancer;
                                        break;
                                    }
                                }
                                if (freelancerToPay != null)
                                {
                                    Pembayaran pembayaran = new Pembayaran(loggedInClient, freelancerToPay, jumlahBayar);
                                    pembayaran.ProsesPembayaran();
                                }
                                else
                                {
                                    Console.WriteLine("Freelancer tidak ditemukan.");
                                }
                            }
                            else if (menuClient == 8)
                            {
                                Console.Write("Masukkan username freelancer: ");
                                string usernameFreelancer = Console.ReadLine();
                                Console.Write("Masukkan rating (1-5): ");
                                int rating = int.Parse(Console.ReadLine());
                                Console.Write("Masukkan ulasan: ");
                                string ulasan = Console.ReadLine();
                                clientReviews.Add(new ClientReview(rating, ulasan, usernameFreelancer));
                            }
                            else if (menuClient == 9)
                            {
                                foreach (var review in clientReviews)
                                {
                                    review.displayReview();
                                }
                            }
                            else if (menuClient == 10)
                            {
                                admin.tampilkanPengumuman();
                            }
                            else if (menuClient == 11)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Username atau password salah.");
                    }
                }
                else if (pilihan == 4)
                {
                    Console.Write("Masukkan username: ");
                    string username = Console.ReadLine();
                    Console.Write("Masukkan password: ");
                    string password = Console.ReadLine();

                    Freelance loggedInFreelancer = null;
                    foreach (var freelancer in freelancers)
                    {
                        if (freelancer.GetUsername() == username && freelancer.CheckPassword(password))
                        {
                            loggedInFreelancer = freelancer;
                            break;
                        }
                    }

                    if (loggedInFreelancer != null)
                    {
                        Console.WriteLine("Login berhasil!");
                        Console.WriteLine($"Selamat Datang {loggedInFreelancer.GetUsername()}");
                        while (true)
                        {
                            //Menu Pelamar__________________________________________________________________________________________________
                            Menu.menuPelamar();
                            int menuFreelancer = int.Parse(Console.ReadLine());

                            if (menuFreelancer == 1)
                            {
                                loggedInFreelancer.melihatLowongan(semuaLowongan);
                            }
                            else if (menuFreelancer == 2)
                            {
                                Console.Write("Masukkan judul lowongan yang ingin dilamar: ");
                                string judul = Console.ReadLine();
                                Lowongan lowonganDipilih = null;
                                foreach (var lowongan in semuaLowongan)
                                {
                                    if (lowongan.GetJudul().ToLower() == judul.ToLower())
                                    {
                                        Console.WriteLine($"DEBUG: Alamat lowongan {lowongan.GetJudul()}: {lowongan.GetHashCode()}");
                                        lowonganDipilih = lowongan;
                                        lowonganDipilih.AddPelamar(loggedInFreelancer);
                                        break;
                                    }
                                }
                                try
                                {
                                    if (lowonganDipilih == null)
                                    {
                                        throw new Exception("Lowongan tidak ditemukan.");
                                    }
                                    loggedInFreelancer.melamarLowongan(lowonganDipilih);
                                    Console.WriteLine("Berhasil melamar lowongan.");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else if (menuFreelancer == 3)
                            {
                                loggedInFreelancer.melihatLowonganDipilih();
                            }
                            else if (menuFreelancer == 4)
                            {
                                loggedInFreelancer.melihatProjekHire();
                            }
                            else if (menuFreelancer == 5)
                            {
                                Console.Write("Dari: ");
                                string dari = Console.ReadLine();
                                Console.Write("Pesan: ");
                                string pesan = Console.ReadLine();
                                forum.TambahPercakapan(dari, pesan);
                            }
                            else if (menuFreelancer == 6)
                            {
                                forum.TampilkanPercakapan();
                            }
                            else if (menuFreelancer == 7)
                            {
                                loggedInFreelancer.cekSaldo();
                            }
                            else if (menuFreelancer == 8)
                            {
                                Console.Write("Masukkan portofolio: ");
                                string project = Console.ReadLine();
                                loggedInFreelancer.addPortfolio(project);
                            }
                            else if (menuFreelancer == 9)
                            {
                                loggedInFreelancer.viewPortofolio();
                            }
                            else if (menuFreelancer == 10)
                            {
                                Console.WriteLine("\n=== Tandai Pekerjaan Selesai ===");
                                Console.Write("Masukkan nama proyek yang selesai: ");
                                string namaProyek = Console.ReadLine();
                                loggedInFreelancer.tandaiPekerjaanSelesai(namaProyek);
                            }
                            else if (menuFreelancer == 11)
                            {
                                Console.Write("Masukkan username klien: ");
                                string usernameClient = Console.ReadLine();
                                Client client = null;
                                foreach (var c in clients)
                                {
                                    if (c.GetUsername() == usernameClient)
                                    {
                                        client = c;
                                        break;
                                    }
                                }
                                if (client != null)
                                {
                                    Console.Write("Masukkan rating (1-5): ");
                                    int rating = int.Parse(Console.ReadLine());
                                    Console.Write("Masukkan ulasan: ");
                                    string reviewText = Console.ReadLine();

                                    try
                                    {
                                        var review = new FreelancerReview(rating, reviewText, client.GetUsername());
                                        freelancerReviews.Add(review);
                                        Console.WriteLine("Review berhasil ditambahkan!");
                                    }
                                    catch (ArgumentException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Klien tidak ditemukan.");
                                }
                            }
                            else if (menuFreelancer == 12)
                            {
                                Console.WriteLine("Review dari Freelancer:");
                                foreach (var review in freelancerReviews)
                                {
                                    review.DisplayReview();
                                    Console.WriteLine();
                                }
                            }
                            else if (menuFreelancer == 13)
                            {
                                admin.tampilkanPengumuman();
                            }
                            else if (menuFreelancer == 14)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Username atau password salah.");
                    }
                }
                else if (pilihan == 5) // Login Admin
                {
                    Console.Write("Masukkan username: ");
                    string username = Console.ReadLine();
                    Console.Write("Masukkan password: ");
                    string password = Console.ReadLine();

                    if (username == admin.GetUsername() && password == admin.getPassword())
                    {
                        Console.WriteLine("Login berhasil!");
                        while (true)
                        {
                            Menu.menuAdmin();
                            int menuAdmin = int.Parse(Console.ReadLine());

                            if (menuAdmin == 1)
                            {
                                Console.WriteLine("\n=== Daftar Pelanggar ===");
                                if (admin.getUserBan().Count == 0)
                                {
                                    Console.WriteLine("Tidak ada pelanggar yang dilaporkan.");
                                }
                                else
                                {
                                    foreach (var pelanggar in admin.getUserBan())
                                    {
                                        Console.WriteLine(pelanggar);
                                    }
                                }
                                Console.WriteLine("Ingin melakukan Ban?: Y/N");
                                string banning = Console.ReadLine();

                                if (banning.ToUpper() == "Y")
                                {
                                    Console.Write("Masukkan nama Freelancer yang ingin Anda ban: ");
                                    string freelancerNama = Console.ReadLine();
                                    bool found = false;
                                    foreach (var f in freelancers)
                                    {
                                        if (f.getCv().getNama().ToLower() == freelancerNama.ToLower())
                                        {
                                            f.banUser();
                                            freelancers.Remove(f);
                                            Console.WriteLine($"Freelancer {freelancerNama} telah dibanned dan dihapus.");
                                            found = true;
                                            break;
                                        }
                                    }
                                    if (!found)
                                    {
                                        Console.WriteLine($"Freelancer {freelancerNama} tidak ditemukan.");
                                    }
                                }
                                else if (banning.ToUpper() == "N")
                                {
                                    Console.WriteLine("Kembali ke menu admin...");
                                    continue; // Kembali ke awal menu admin
                                }
                            }
                            else if (menuAdmin == 2)
                            {
                                Console.Write("Masukkan Username Baru: ");
                                string usernameAdmin = Console.ReadLine();
                                admin.setUsername(usernameAdmin);
                                Console.WriteLine("Username berhasil diubah");
                            }
                            else if (menuAdmin == 3)
                            {
                                Console.Write("Masukkan Password Baru: ");
                                string passwordAdmin = Console.ReadLine();
                                admin.setPassword(passwordAdmin);
                            }
                            else if (menuAdmin == 4)
                            {
                                Console.Write("Masukkan pengumuman baru: ");
                                string pengumuman = Console.ReadLine();
                                admin.buatPengumuman(pengumuman);
                            }
                            else if (menuAdmin == 5)
                            {
                                Console.Write("Masukkan pengumuman baru: ");
                                string pengumumanBaru = Console.ReadLine();
                                admin.ubahPengumuman(pengumumanBaru);
                            }
                            else if (menuAdmin == 6)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Username atau password salah.");
                    }
                }
                else if (pilihan == 6)
                {
                    Console.WriteLine("Terima kasih telah menggunakan sistem ini!");
                    break;
                }
            }
        }
    }
}