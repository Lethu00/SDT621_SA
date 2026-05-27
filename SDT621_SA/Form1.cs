namespace SDT621_SA
{
    public partial class Form1 : Form
    {
        private Label lblInput;
        private Label lblOutput;
        private TextBox txtName;
        public Form1()
        {
            InitializeComponent();
            lblInput = new Label() { Text = "Enter your name:", Location = new Point(150, 150) };
            txtName = new TextBox() { Location = new Point(150, 180), Width = 200 };
            lblOutput = new Label() { Location = new Point(150, 210), Width = 200 };
            Button btnDisplay = new Button() { Text = "Enter", Location = new Point(360, 180), Height = 35 };

            //controls
            this.Controls.Add(lblInput);
            this.Controls.Add(txtName);
            this.Controls.Add(lblOutput);
            this.Controls.Add(btnDisplay);

            //events
            btnDisplay.Click += BtnDisplay_Click;
        }


        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }
            MessageBox.Show($"Hello {name}!");
        }
    }
}
