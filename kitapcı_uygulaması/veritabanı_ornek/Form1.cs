using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace veritabanı_ornek
{
    public partial class veritabanı_örnek : Form
    {
        public veritabanı_örnek()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-5E38FO6; Initial Catalog=kitap ;  Integrated Security=True");


        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand(" select * from kitaplar",baglan);

            SqlDataReader oku = komut.ExecuteReader();

            while(oku.Read())


            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kitapad"].ToString());
                ekle.SubItems.Add(oku["yazar"].ToString());
                ekle.SubItems.Add(oku["yayınevi"].ToString());
                ekle.SubItems.Add(oku["sayfa"].ToString());


                listView1.Items.Add(ekle);


            }

            baglan.Close();



        }
        private void kayıt()
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("Insert into kitaplar (id,kitapad,yazar,yayınevi,sayfa) Values ('"
                + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglan);

            komut.ExecuteNonQuery();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            baglan.Close();
        }


        int id = 0;
       
        private void button1_Click(object sender, EventArgs e)
        {

            kayıt();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            verilerigoster();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from kitaplar where id =(" + id + ")", baglan);

            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);



            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;

            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;

            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;

            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;

            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;



        }

        private void button4_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update  kitaplar set id='" + textBox1.Text.ToString() + "',kitapad='" + textBox2.Text.ToString() + "',yazar='" + textBox3.Text.ToString() + "',yayınevi='" + textBox4.Text.ToString() + "',sayfa='" + textBox5.Text.ToString() + "'where id = " +id+"",baglan);


            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from kitaplar where yazar like '%" + textBox6.Text + "%'", baglan);            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())


            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kitapad"].ToString());
                ekle.SubItems.Add(oku["yazar"].ToString());
                ekle.SubItems.Add(oku["yayınevi"].ToString());
                ekle.SubItems.Add(oku["sayfa"].ToString());


                listView1.Items.Add(ekle);


            }

            baglan.Close();



        }


    }
    }


