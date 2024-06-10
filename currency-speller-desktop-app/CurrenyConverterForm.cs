using System.Net.Http;

namespace currency_speller_desktop_app
{
    public partial class CurrenyConverterForm : Form
    {
        private HttpClient httpClient = new HttpClient();

        public CurrenyConverterForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConvertButton_ClickAsync(object sender, EventArgs e)
        {
            string amount = txtInput.Text;
            txtResult.Text = "";
            if (string.IsNullOrEmpty(amount))
            {
                txtResult.Text = "Input is empty. Please provide a value.";
            }
            else
            {
                try
                {
                    string result = ConvertCurrency(amount);
                    txtResult.Text = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private string ConvertCurrency(string amount)
        {
            string url = $"https://localhost:7205/api/ConvertCurrency/{amount}";

            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                throw new Exception("Failed to convert currency. Please try again later.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = string.Empty;
            txtResult.Text = string.Empty;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
