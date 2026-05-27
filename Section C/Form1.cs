namespace Section_C
{
    public partial class Form1 : Form
    {
        private Label lblOutput;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblMake;
        private TextBox txtMake;
        private Label lblQuantity;
        private TextBox txtQuantity;

        public Form1()
        {
            InitializeComponent();

            lblOutput = new Label() { Location = new Point(150, 50), Width = 400 };
            lblCode = new Label() { Text = "Enter the code:", Location = new Point(150, 150) };
            txtCode = new TextBox() { Location = new Point(150, 180), Width = 200 };
            lblMake = new Label() { Text = "Enter the make:", Location = new Point(150, 210) };
            txtMake = new TextBox() { Location = new Point(150, 240), Width = 200 };
            lblQuantity = new Label() { Text = "Enter the quantity:", Location = new Point(150, 270) };
            txtQuantity = new TextBox() { Location = new Point(150, 300), Width = 200 };

            Button btnAdd = new Button() { Text = "Add", Location = new Point(360, 180), Height = 35 };
            Button btnDelete = new Button() { Text = "Delete", Location = new Point(360, 240), Height = 35 };
            Button btnFind = new Button() { Text = "Find", Location = new Point(360, 300), Height = 35 };

            this.Controls.Add(lblCode);
            this.Controls.Add(txtCode);
            this.Controls.Add(lblMake);
            this.Controls.Add(txtMake);
            this.Controls.Add(lblQuantity);
            this.Controls.Add(txtQuantity);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnFind);

            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnFind.Click += BtnFind_Click;
        }
    
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            string make = txtMake.Text;
            string quantity = txtQuantity.Text;
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(quantity))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            lblOutput.Text = $"Added: Code={code}, Make={make}, Quantity={quantity}";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Please enter a code.");
                return;
            }
            lblOutput.Text = $"Deleted: Code={code}";
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Please enter a code.");
                return;
            }
            lblOutput.Text = $"Found: Code={code}";
        }
    }
}