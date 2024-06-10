namespace currency_speller_desktop_app
{
    partial class CurrenyConverterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConvert = new Button();
            txtInput = new TextBox();
            panel1 = new Panel();
            lblResult = new Label();
            btnClear = new Button();
            txtResult = new TextBox();
            lblAmountInDollars = new Label();
            lblApplicationHeader = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(18, 102);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(131, 40);
            btnConvert.TabIndex = 1;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += ConvertButton_ClickAsync;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(18, 49);
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "e.g. 999 999,99";
            txtInput.Size = new Size(309, 35);
            txtInput.TabIndex = 2;
            txtInput.TextChanged += inputAmount_TextChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblAmountInDollars);
            panel1.Controls.Add(lblResult);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(txtResult);
            panel1.Controls.Add(btnConvert);
            panel1.Controls.Add(txtInput);
            panel1.Location = new Point(35, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(542, 332);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(18, 169);
            lblResult.Name = "label1";
            lblResult.Size = new Size(69, 30);
            lblResult.TabIndex = 7;
            lblResult.Text = "Result";
            lblResult.Click += label1_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(196, 102);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(131, 40);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(17, 211);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(506, 106);
            txtResult.TabIndex = 4;
            txtResult.TextChanged += textBox4_TextChanged;
            // 
            // label2
            // 
            lblAmountInDollars.AutoSize = true;
            lblAmountInDollars.Location = new Point(18, 16);
            lblAmountInDollars.Name = "label2";
            lblAmountInDollars.Size = new Size(181, 30);
            lblAmountInDollars.TabIndex = 8;
            lblAmountInDollars.Text = "Amount in Dollars";
            lblAmountInDollars.Click += label2_Click;
            // 
            // label3
            // 
            lblApplicationHeader.AutoSize = true;
            lblApplicationHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblApplicationHeader.Location = new Point(190, 22);
            lblApplicationHeader.Name = "label3";
            lblApplicationHeader.Size = new Size(251, 36);
            lblApplicationHeader.TabIndex = 5;
            lblApplicationHeader.Text = "Currency Converter";
            // 
            // CurrenyConverterForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 450);
            Controls.Add(lblApplicationHeader);
            Controls.Add(panel1);
            Name = "CurrenyConverterForm";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnConvert;
        private TextBox txtInput;
        private Panel panel1;
        private TextBox txtResult;
        private Button btnClear;
        private Label lblResult;
        private Label lblAmountInDollars;
        private Label lblApplicationHeader;
    }
}
