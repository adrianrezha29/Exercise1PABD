using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi ke Database\n");
                    Console.WriteLine("Masukkan User ID :");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukkan Password");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukkan database tujuan");
                    string db = Console.ReadLine();
                    Console.Write("\nKetik K untuk Terhubung ke Database: ");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'K':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data source = REZHA\\(sa(67)); " +
                                    "initial catalog = {0}; " + "User ID {1}; password = {2}";
                                conn = new SqlConnection(string.Format(strKoneksi, db, user, pass));
                                conn.Open();
                                Console.Clear();
                                while (true)
                                { 
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Melihat Seluruh Data");
                                        Console.WriteLine("2. Tambah Data");
                                        Console.WriteLine("3. Keluar");
                                        Console.Write("\nEnter your choice (1-3):");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("DATA MAHASISWA");
                                                    pr.baca(conn);
                                                    conn.Close();
                                                }
                                                break;

                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Masukkan NIM :");
                                                    string NIM = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nama Mahasiswa : ");
                                                    string NamaMhs = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Alamat Mahasiswa : ");
                                                    string Almt = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Jenis Kelamin (L/P) : ");
                                                    string jk = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No Telepon : ");
                                                    string notlpn = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.insert(NIM, NamaMhs, Almt, jk, notlpn, conn);
                                                        conn.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " + "akses untuk menambah data");
                                                    }

                                                }
                                                break;
                                            case '3':
                                                conn.Close();
                                                return;
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\nInvalid Option");
                                                }
                                                break;
                                                ;
                                        }
                                    }
                                }
                            }
                    }
                }
            }
        }
    }
}
