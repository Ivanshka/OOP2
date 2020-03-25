namespace Laba_6
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.radioName = new System.Windows.Forms.RadioButton();
            this.radioSpecialty = new System.Windows.Forms.RadioButton();
            this.radioCourse = new System.Windows.Forms.RadioButton();
            this.radioAvScore = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioAccurate = new System.Windows.Forms.RadioButton();
            this.radioRegular = new System.Windows.Forms.RadioButton();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.resultList = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioName
            // 
            this.radioName.AutoSize = true;
            this.radioName.Location = new System.Drawing.Point(6, 19);
            this.radioName.Name = "radioName";
            this.radioName.Size = new System.Drawing.Size(52, 17);
            this.radioName.TabIndex = 1;
            this.radioName.TabStop = true;
            this.radioName.Text = "ФИО";
            this.radioName.UseVisualStyleBackColor = true;
            this.radioName.Click += new System.EventHandler(this.radioName_Click);
            // 
            // radioSpecialty
            // 
            this.radioSpecialty.AutoSize = true;
            this.radioSpecialty.Location = new System.Drawing.Point(64, 19);
            this.radioSpecialty.Name = "radioSpecialty";
            this.radioSpecialty.Size = new System.Drawing.Size(102, 17);
            this.radioSpecialty.TabIndex = 2;
            this.radioSpecialty.TabStop = true;
            this.radioSpecialty.Text = "специальности";
            this.radioSpecialty.UseVisualStyleBackColor = true;
            this.radioSpecialty.CheckedChanged += new System.EventHandler(this.radioSpecialty_CheckedChanged);
            // 
            // radioCourse
            // 
            this.radioCourse.AutoSize = true;
            this.radioCourse.Location = new System.Drawing.Point(172, 19);
            this.radioCourse.Name = "radioCourse";
            this.radioCourse.Size = new System.Drawing.Size(53, 17);
            this.radioCourse.TabIndex = 3;
            this.radioCourse.TabStop = true;
            this.radioCourse.Text = "курсу";
            this.radioCourse.UseVisualStyleBackColor = true;
            this.radioCourse.CheckedChanged += new System.EventHandler(this.radioCourse_CheckedChanged);
            // 
            // radioAvScore
            // 
            this.radioAvScore.AutoSize = true;
            this.radioAvScore.Location = new System.Drawing.Point(231, 19);
            this.radioAvScore.Name = "radioAvScore";
            this.radioAvScore.Size = new System.Drawing.Size(106, 17);
            this.radioAvScore.TabIndex = 4;
            this.radioAvScore.TabStop = true;
            this.radioAvScore.Text = "среднему баллу";
            this.radioAvScore.UseVisualStyleBackColor = true;
            this.radioAvScore.CheckedChanged += new System.EventHandler(this.radioAvScore_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioName);
            this.groupBox1.Controls.Add(this.radioAvScore);
            this.groupBox1.Controls.Add(this.radioSpecialty);
            this.groupBox1.Controls.Add(this.radioCourse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 44);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск по";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioRegular);
            this.groupBox2.Controls.Add(this.radioAccurate);
            this.groupBox2.Location = new System.Drawing.Point(358, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 44);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Режим";
            // 
            // radioAccurate
            // 
            this.radioAccurate.AutoSize = true;
            this.radioAccurate.Location = new System.Drawing.Point(6, 19);
            this.radioAccurate.Name = "radioAccurate";
            this.radioAccurate.Size = new System.Drawing.Size(61, 17);
            this.radioAccurate.TabIndex = 7;
            this.radioAccurate.TabStop = true;
            this.radioAccurate.Text = "точный";
            this.radioAccurate.UseVisualStyleBackColor = true;
            this.radioAccurate.CheckedChanged += new System.EventHandler(this.radioAccurate_CheckedChanged);
            // 
            // radioRegular
            // 
            this.radioRegular.AutoSize = true;
            this.radioRegular.Location = new System.Drawing.Point(73, 19);
            this.radioRegular.Name = "radioRegular";
            this.radioRegular.Size = new System.Drawing.Size(146, 17);
            this.radioRegular.TabIndex = 7;
            this.radioRegular.TabStop = true;
            this.radioRegular.Text = "регулярные выражения";
            this.radioRegular.UseVisualStyleBackColor = true;
            this.radioRegular.CheckedChanged += new System.EventHandler(this.radioRegular_CheckedChanged);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(12, 62);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(655, 20);
            this.SearchBox.TabIndex = 7;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(592, 25);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // resultList
            // 
            this.resultList.FormattingEnabled = true;
            this.resultList.Location = new System.Drawing.Point(12, 88);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(655, 368);
            this.resultList.TabIndex = 9;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 461);
            this.Controls.Add(this.resultList);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioName;
        private System.Windows.Forms.RadioButton radioSpecialty;
        private System.Windows.Forms.RadioButton radioCourse;
        private System.Windows.Forms.RadioButton radioAvScore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioRegular;
        private System.Windows.Forms.RadioButton radioAccurate;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.ListBox resultList;
    }
}