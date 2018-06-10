namespace Otoczka_Wypukla
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.generate_button = new System.Windows.Forms.Button();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.QuantityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(117, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(533, 492);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // generate_button
            // 
            this.generate_button.Location = new System.Drawing.Point(319, 514);
            this.generate_button.Margin = new System.Windows.Forms.Padding(4);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(112, 47);
            this.generate_button.TabIndex = 1;
            this.generate_button.Text = "Generate";
            this.generate_button.UseVisualStyleBackColor = true;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(198, 539);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(100, 22);
            this.quantityTextBox.TabIndex = 2;
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(193, 519);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(119, 17);
            this.QuantityLabel.TabIndex = 3;
            this.QuantityLabel.Text = "Quantity of points";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 576);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.generate_button);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Label QuantityLabel;
    }
}

