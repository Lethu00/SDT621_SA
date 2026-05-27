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
        private Button btnAdd;
        private Button btnDelete;
        private Button btnFind;
        private readonly MobilePhoneService mobilePhoneService;

        public Form1()
        {
            InitializeComponent();
            mobilePhoneService = new MobilePhoneService(new MobilePhoneTableRepository());

            lblOutput = new Label()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(120, 35),
                TextAlign = ContentAlignment.MiddleLeft,
                Width = 400,
                Height = 36
            };

            lblCode = new Label() { Text = "Mobile Code", Location = new Point(145, 120), Width = 110, Height = 25 };
            txtCode = new TextBox() { Location = new Point(300, 116), Width = 180, Height = 27 };
            lblMake = new Label() { Text = "Make", Location = new Point(145, 170), Width = 110, Height = 25 };
            txtMake = new TextBox() { Location = new Point(300, 166), Width = 180, Height = 27 };
            lblQuantity = new Label() { Text = "Quantity", Location = new Point(145, 220), Width = 110, Height = 25 };
            txtQuantity = new TextBox() { Location = new Point(300, 216), Width = 180, Height = 27 };

            btnAdd = new Button() { Text = "Add", Location = new Point(95, 310), Width = 110, Height = 40 };
            btnDelete = new Button() { Text = "Delete", Location = new Point(280, 310), Width = 110, Height = 40 };
            btnFind = new Button() { Text = "Find", Location = new Point(465, 310), Width = 110, Height = 40 };

            this.Controls.Add(lblOutput);
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
    
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            lblOutput.Text = mobilePhoneService.Add(txtCode.Text, txtMake.Text, txtQuantity.Text);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            lblOutput.Text = mobilePhoneService.Delete(txtCode.Text, txtQuantity.Text);
        }

        private void BtnFind_Click(object? sender, EventArgs e)
        {
            lblOutput.Text = mobilePhoneService.Find(txtCode.Text);
        }
    }
}
