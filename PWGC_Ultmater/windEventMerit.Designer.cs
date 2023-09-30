namespace PWGC_Ultmater
{
    partial class windEventMerit
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_first_owne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_last_owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_merito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_last_merit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_nick,
            this.col_first_owne,
            this.col_last_owner,
            this.col_merito,
            this.col_last_merit,
            this.col_total});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(698, 237);
            this.dataGridView1.TabIndex = 1;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Width = 50;
            // 
            // col_nick
            // 
            this.col_nick.HeaderText = "Nick";
            this.col_nick.Name = "col_nick";
            this.col_nick.ReadOnly = true;
            // 
            // col_first_owne
            // 
            this.col_first_owne.HeaderText = "Owner Inicial";
            this.col_first_owne.Name = "col_first_owne";
            this.col_first_owne.ReadOnly = true;
            // 
            // col_last_owner
            // 
            this.col_last_owner.HeaderText = "Owner Final";
            this.col_last_owner.Name = "col_last_owner";
            this.col_last_owner.ReadOnly = true;
            // 
            // col_merito
            // 
            this.col_merito.HeaderText = "Inicial";
            this.col_merito.Name = "col_merito";
            this.col_merito.ReadOnly = true;
            // 
            // col_last_merit
            // 
            this.col_last_merit.HeaderText = "Final";
            this.col_last_merit.Name = "col_last_merit";
            this.col_last_merit.ReadOnly = true;
            // 
            // col_total
            // 
            this.col_total.HeaderText = "Total";
            this.col_total.Name = "col_total";
            this.col_total.ReadOnly = true;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.Location = new System.Drawing.Point(619, 255);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(91, 23);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(12, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Zerar Contagem";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // windEventMerit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(718, 285);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "windEventMerit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DESATIVADO / EM DESENVOLVIMENTO";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nick;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_first_owne;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_last_owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_merito;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_last_merit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_total;
    }
}