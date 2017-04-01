namespace Forecasting
{
    partial class Main
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart_forcasting = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_sesError = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_sesAlpha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_desError = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_desAlpha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_desBeta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_forcasting)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_forcasting
            // 
            chartArea1.AxisX.Interval = 5D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.BorderColor = System.Drawing.Color.DarkGray;
            chartArea1.Name = "ChartArea1";
            this.chart_forcasting.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_forcasting.Legends.Add(legend1);
            this.chart_forcasting.Location = new System.Drawing.Point(245, 12);
            this.chart_forcasting.Name = "chart_forcasting";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_forcasting.Series.Add(series1);
            this.chart_forcasting.Size = new System.Drawing.Size(1036, 614);
            this.chart_forcasting.TabIndex = 0;
            this.chart_forcasting.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            title1.Name = "title_forecastingSes";
            title1.Text = "Sword Forecasting";
            this.chart_forcasting.Titles.Add(title1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_sesError);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_sesAlpha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SES";
            // 
            // textBox_sesError
            // 
            this.textBox_sesError.Enabled = false;
            this.textBox_sesError.Location = new System.Drawing.Point(149, 39);
            this.textBox_sesError.Name = "textBox_sesError";
            this.textBox_sesError.Size = new System.Drawing.Size(72, 20);
            this.textBox_sesError.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Squared error:";
            // 
            // textBox_sesAlpha
            // 
            this.textBox_sesAlpha.Enabled = false;
            this.textBox_sesAlpha.Location = new System.Drawing.Point(149, 17);
            this.textBox_sesAlpha.Name = "textBox_sesAlpha";
            this.textBox_sesAlpha.Size = new System.Drawing.Size(72, 20);
            this.textBox_sesAlpha.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alpha smoothing coëfficiënt: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_desBeta);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_desError);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_desAlpha);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 91);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DES";
            // 
            // textBox_desError
            // 
            this.textBox_desError.Enabled = false;
            this.textBox_desError.Location = new System.Drawing.Point(149, 61);
            this.textBox_desError.Name = "textBox_desError";
            this.textBox_desError.Size = new System.Drawing.Size(72, 20);
            this.textBox_desError.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Squared error:";
            // 
            // textBox_desAlpha
            // 
            this.textBox_desAlpha.Enabled = false;
            this.textBox_desAlpha.Location = new System.Drawing.Point(149, 17);
            this.textBox_desAlpha.Name = "textBox_desAlpha";
            this.textBox_desAlpha.Size = new System.Drawing.Size(72, 20);
            this.textBox_desAlpha.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Alpha smoothing coëfficiënt: ";
            // 
            // textBox_desBeta
            // 
            this.textBox_desBeta.Enabled = false;
            this.textBox_desBeta.Location = new System.Drawing.Point(149, 39);
            this.textBox_desBeta.Name = "textBox_desBeta";
            this.textBox_desBeta.Size = new System.Drawing.Size(72, 20);
            this.textBox_desBeta.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Beta smoothing coëfficiënt: ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 638);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart_forcasting);
            this.Name = "Main";
            this.Text = "Forecasting";
            ((System.ComponentModel.ISupportInitialize)(this.chart_forcasting)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_forcasting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_sesAlpha;
        private System.Windows.Forms.TextBox textBox_sesError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_desError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_desAlpha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_desBeta;
        private System.Windows.Forms.Label label5;
    }
}

