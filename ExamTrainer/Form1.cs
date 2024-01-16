//Created by LLlE0, 16.01.2024
//Feel free to use it!

namespace ExamTrainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> lines;

        private void Form1_Load(object sender, EventArgs e)
        {
            lines = new List<string>();
        }


        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (Path.GetExtension(files[files.Length - 1]) == ".txt")
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    richTextBox1.Text = "���������� ���������� txt ����";
                }
            }

        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (Path.GetExtension(files[files.Length - 1]) == ".txt")
                    {
                        try
                        {
                            lines = File.ReadAllLines(files[files.Length - 1]).ToList();
                            if (lines.Count == 0)
                            {
                                richTextBox1.Text = "���� ������!";
                            }
                        }
                        catch (Exception ex)
                        {
                            richTextBox1.Text = "������ ��� ������ �����: " + ex.Message;
                        }
                    }
                    else
                    {
                        richTextBox1.Text = "���������� ���������� .txt ����";
                    }

                    richTextBox1.Text = "���� ������� ��������. ������� ������!";
                }

            }

            private void button1_Click(object sender, EventArgs e)
            {
                if (lines.Count == 0)
                {
                    richTextBox1.Text = "������� ����� ���������� .txt ���� � ���������\n";
                }
                else
                {
                    Random random = new Random();
                    int num = random.Next(lines.Count);
                    richTextBox2.Text = "";
                    richTextBox2.Text = lines[num];
                }
            }
        }
    } 