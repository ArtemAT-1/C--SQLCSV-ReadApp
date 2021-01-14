using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using System.Globalization;

namespace ProjectCSharp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
            Form1_Load2();
        }

        private void SortCSV()
        {
            {

                string[] lines = File.ReadAllLines(@"C:\\Users\\Артем\\Desktop\\File1.csv");
                var data = lines.Skip(1);
                var sorted = data.Select(line => new
                {
                    SortKey = String.Concat(line.Split(',')[0]),
                    Line = line
                })
                               .OrderBy(x => x.SortKey)
                               .Select(x => x.Line);
                File.WriteAllLines(@"C:\\Users\\Артем\\Desktop\\File1_1.csv", lines.Take(1).Concat(sorted));


            }
        }

        private void Form1_Load4()
        {

            dataGridView2.Refresh();

        }

        private void Form1_Load3()
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

        }


        private void Form1_Load2()
        {
            List<Elements> records;
            using (var reader = new StreamReader(@"C:\\Users\\Артем\\Desktop\\File1.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<Elements>().ToList();
            }
            dataGridView2.DataSource = records;
        }

        private void Form1_Load()
        {
            

                string connectString = "Data Source=DESKTOP-9C8FBQR; Initial Catalog=namenklature;" +
                    "Integrated Security=true;";

                SqlConnection myConnection = new SqlConnection(connectString);

                myConnection.Open();

                string query = "select TagName,Type,Value from T1 Order by ID Asc";

                SqlCommand command = new SqlCommand(query, myConnection);

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    data.Add(new string[3]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                }

                reader.Close();

                myConnection.Close();

                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            
        }



        private void button1_Click(object sender, EventArgs e)
        {

            Int32 selectedColumnCount = dataGridView2.Rows.Count;
            if (selectedColumnCount > 0)
            {


                for (int i = 0; i < selectedColumnCount; i++)
                {

                    String a = dataGridView2[0, i].Value.ToString();
                    String b = dataGridView2[1, i].Value.ToString();
                    float c = float.Parse(dataGridView2[2,i].Value.ToString());

                    string connectString = "Data Source=DESKTOP-9C8FBQR; Initial Catalog=namenklature;" +
                "Integrated Security=true;";
                    string sql = string.Format("insert into T1(TagName,Type,Value) values (@TageName, @Type, @Value)");

                    SqlConnection myConnection = new SqlConnection(connectString);

                    myConnection.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {

                        cmd.Parameters.AddWithValue("@TageName", a);
                        cmd.Parameters.AddWithValue("@Type", b);
                        cmd.Parameters.AddWithValue("@Value", c);

                        cmd.ExecuteNonQuery();
                    }
                    Form1_Load3();
                    Form1_Load();
                }




            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1_Load4();
            Int32 selectedColumnCount = dataGridView1.Rows.Count;
            if (selectedColumnCount > 0)
            {


                for (int i = 0; i < selectedColumnCount-1; i++)
                {

                    String a = dataGridView1[0, i].Value.ToString();
                    String b = dataGridView1[1, i].Value.ToString();
                    String c = dataGridView1[2, i].Value.ToString();




                    {
                        string path = @"C:\\Users\\Артем\\Desktop\\File1.csv";
                        //string line = String.Format("{0}, {1}, {2}\n", a, b, c.ToString());
                        string line = String.Format("{0}, {1}, {2}", a, b, c.ToString().Replace(",", "."));
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(line);
                        }
                    }

                }

            }
            Form1_Load2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SortCSV();
            label1.Text = "Отсортировано в File1_1.csv";

        }


    }
}
