using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                                                    Console.WriteLine("Klinik Tongfang");
                                                    pr.baca(conn);
                                                    conn.Close();
                                                }
                                                break;

                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Masukkan Id Pasien : ");
                                                    string Id = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nama Pasien : ");
                                                    string NmPasien = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Alamat Pasien : ");
                                                    string Almt = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Jenis Kelamin (L/P) : ");
                                                    string jk = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No Telepon : ");
                                                    string notlpn = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Tanggal Lahir : ");
                                                    string TglLahir = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.insert(Id, NmPasien, Almt, jk, notlpn, TglLahir, conn);
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
                                    catch
                                    {
                                        Console.WriteLine("\nCheck for the value entered.");
                                    }
                                }
                            }
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                            }
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tidak Dapat Mengakses Database Menggunakan User Tersebut\n");
                    Console.ResetColor();
                }
            }
        }
        public void baca(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select * From HRD.Klinik", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
        }
        public void insert(string NIM, string NmaMhs, string Almt, string jk, string notlpn, TglLahir, SqlConnection con)
        {
            string str = "";
            str = "insert into HRD.Klinik (Id, NmPasien, Alamat, Sex, PhonePasien, birth)"
                + "values(@id,@nma,@alamat,@JK,@Phn,@birth)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("id", NIM));
            cmd.Parameters.Add(new SqlParameter("nama", NmaMhs));
            cmd.Parameters.Add(new SqlParameter("alamat", Almt));
            cmd.Parameters.Add(new SqlParameter("jk", jk));
            cmd.Parameters.Add(new SqlParameter("notlpn", notlpn));
            cmd.Parameters.Add(new SqlParameter("tgllahir", birth));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Di Tambahkan");
        }
    }
}
