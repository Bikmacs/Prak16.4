using System.Diagnostics.Tracing;

namespace prak16._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader sw = new StreamReader("1.txt"))
            {
                string[] line = File.ReadAllLines("1.txt");
                foreach (string lines in line)
                {
                    listBox1.Items.Add(lines);
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите значение n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!int.TryParse(textBox1.Text, out int n))
                {
                    MessageBox.Show("Некорректное значение n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var countries = new List<(string Name, int Population)>();
                string[] lines = File.ReadAllLines("1.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string countryName = string.Join(" ", parts.Take(parts.Length - 1));
                    if (int.TryParse(parts.Last().Replace(" ", ""), out int population))
                    {
                        countries.Add((countryName, population));
                    }
                }

                var filteredCountries = countries
                    .Where(c => c.Population > n)
                    .OrderBy(c => c.Name.Length)
                    .ThenBy(c => c.Name)
                    .ToList();

                foreach (var country in filteredCountries)
                {
                    listBox2.Items.Add($"{country.Name} {country.Population}");
                }
            }
        }
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }
    }
}
