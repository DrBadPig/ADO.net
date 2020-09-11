using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace ADO_NET_1
{
    public partial class Form1 : Form
    {
        string path;

        Dictionary<string, int> verbs = new Dictionary<string, int>();
        Dictionary<string, int> adjs = new Dictionary<string, int>();

        SqlConnection cn;

        public Form1()
        {
            InitializeComponent();

            cn = new SqlConnection();
            string connection = ConfigurationManager.ConnectionStrings["ADO_NET_1.Properties.Settings.ConfigMan"].ConnectionString;

            cn.ConnectionString = connection;
        }

        private void buttonTableHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It will be created new table in your database. ",
                "Hey you, wait a minute", MessageBoxButtons.OK);
        }

        private void buttonSetPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
            }
        }
        /// <summary>
        /// Finds all words by type from all txt files
        /// </summary>
        /// <param name="path">path to txt file</param>
        /// <param name="type">"v" is for verbs and "a" is for adjectives</param>
        private void CheckAllFiles(string path, string type)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);

            if (dinfo.Exists)
            {
                try
                {
                    FileInfo[] _files = dinfo.GetFiles();
                    foreach (FileInfo current in _files)
                    {
                        if (current.Extension == ".txt")
                        {
                            switch (type)
                            {
                                case "v":
                                    GetVerbs(current.FullName);
                                    break;
                                case "a":
                                    GetAdj(current.FullName);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    DirectoryInfo[] dirs = dinfo.GetDirectories();
                    foreach (DirectoryInfo current in dirs)
                    {
                        CheckAllFiles(path + @"\" + current.Name, type);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Path is not exists");
            }
        }

        private void GetVerbs(string path)
        {
            StreamReader reader = new StreamReader(path);

            string text = reader.ReadToEnd();

            foreach (var item in text.Split('.', ' ', '?', '!', ',', '\r', '\n', '\t'))
            {
                if (item.Length > 3)
                {
                    if ((item[item.Length - 1] == 'ь' && item[item.Length - 2] == 'т') ||
                        (item[item.Length - 1] == 'и' && item[item.Length - 2] == 'т'))
                    {
                        if (verbs.ContainsKey(item))
                        {
                            verbs[item]++;
                        }
                        else
                        {
                            verbs.Add(item, 1);
                        }
                    }
                }
            }

            reader.Close();
        }

        private void GetAdj(string path)
        {
            StreamReader reader = new StreamReader(path);

            string text = reader.ReadToEnd();

            foreach (var item in text.Split('.', ' ', '?', '!', ',', '\r', '\n', '\t'))
            {
                if (item.Length > 3)
                {
                    if ((item[item.Length - 1] == 'й' && item[item.Length - 2] == 'ы')
                    ||
                    (item[item.Length - 1] == 'й' && item[item.Length - 2] == 'и')
                    ||
                    (item[item.Length - 1] == 'я' && item[item.Length - 2] == 'а')
                    ||
                    (item[item.Length - 1] == 'я' && item[item.Length - 2] == 'я')
                    ||
                    (item[item.Length - 1] == 'е' && item[item.Length - 2] == 'о')
                    ||
                    (item[item.Length - 1] == 'е' && item[item.Length - 2] == 'е')
                    ||
                    (item[item.Length - 1] == 'е' && item[item.Length - 2] == 'ы')
                    ||
                    (item[item.Length - 1] == 'е' && item[item.Length - 2] == 'и')
                    ||
                    (item[item.Length - 1] == 'х' && item[item.Length - 2] == 'и')
                    ||
                    (item[item.Length - 1] == 'х' && item[item.Length - 2] == 'ы')
                    ||
                    (item[item.Length - 1] == 'й' && item[item.Length - 2] == 'е')
                    ||
                    (item[item.Length - 1] == 'й' && item[item.Length - 2] == 'о')
                    ||
                    (item[item.Length - 1] == 'м' && item[item.Length - 2] == 'ы')
                    ||
                    (item[item.Length - 1] == 'м' && item[item.Length - 2] == 'и')
                    )
                    {
                        if (verbs.ContainsKey(item))
                        {
                            adjs[item]++;
                        }
                        else
                        {
                            adjs.Add(item, 1);
                        }
                    }
                }
            }
            reader.Close();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            verbs.Clear();
            adjs.Clear();
            if (textBoxTableName.Text.Length > 0 && comboSearchType.SelectedItem != null && path != null)
            {
                string type = comboSearchType.SelectedItem.ToString();
                switch (type)
                {
                    case "Verbs":
                        CheckAllFiles(path, "v");
                        break;
                    case "Adjectives":
                        CheckAllFiles(path, "a");
                        break;
                }


                cn.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "create table " + textBoxTableName.Text + "(id int, word nvarchar(20), count int)";

                cmd.ExecuteNonQuery();

                int id;

                switch (type)
                {
                    case "Verbs":
                        id = 0;
                        foreach (var item in verbs)
                        {
                            cmd.CommandText = $"insert into " + textBoxTableName.Text + 
                                "(id, word, count) " + $"values ({id}, N'{item.Key}', {item.Value})";
                            cmd.ExecuteNonQuery();
                            id++;
                        }

                        break;
                    case "Adjectives":
                        id = 0;
                        foreach (var item in adjs)
                        {
                            cmd.CommandText = $"insert into " + textBoxTableName.Text +
                                "(id, word, count) " + $"values ({id}, N'{item.Key}', {item.Value})";
                            cmd.ExecuteNonQuery();
                            id++;
                        }

                        break;
                }

                cn.Close();
            }
        }
    }
}
