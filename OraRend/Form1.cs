namespace OraRend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Pw_TB.UseSystemPasswordChar = true;
            Pw_TB.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void GO_BTN_Click(object sender, EventArgs e)
        {
            List<UniClass> classes = Scraper.ScrapeClasses(UN_TB.Text, Pw_TB.Text);
            dataGridView1.DataSource = classes;

            var excel = new Excelizer(@"C:\Users\izyng7");
            excel.CreateTimeTable(classes);
        }
    }
}