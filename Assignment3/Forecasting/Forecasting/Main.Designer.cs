﻿namespace Forecasting
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart_forcasting = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_sesAlpha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_sesError = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_forcasting)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_forcasting
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_forcasting.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart_forcasting.Legends.Add(legend3);
            this.chart_forcasting.Location = new System.Drawing.Point(222, 12);
            this.chart_forcasting.Name = "chart_forcasting";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart_forcasting.Series.Add(series3);
            this.chart_forcasting.Size = new System.Drawing.Size(660, 401);
            this.chart_forcasting.TabIndex = 0;
            this.chart_forcasting.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            title3.Name = "title_forecastingSes";
            title3.Text = "Sword Forecasting";
            this.chart_forcasting.Titles.Add(title3);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_sesError);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_sesAlpha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smoothing coëfficiënt: ";
            // 
            // textBox_sesAlpha
            // 
            this.textBox_sesAlpha.Enabled = false;
            this.textBox_sesAlpha.Location = new System.Drawing.Point(122, 17);
            this.textBox_sesAlpha.Name = "textBox_sesAlpha";
            this.textBox_sesAlpha.Size = new System.Drawing.Size(72, 20);
            this.textBox_sesAlpha.TabIndex = 1;
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
            // textBox_sesError
            // 
            this.textBox_sesError.Enabled = false;
            this.textBox_sesError.Location = new System.Drawing.Point(122, 39);
            this.textBox_sesError.Name = "textBox_sesError";
            this.textBox_sesError.Size = new System.Drawing.Size(72, 20);
            this.textBox_sesError.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 404);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart_forcasting);
            this.Name = "Main";
            this.Text = "Forecasting";
            ((System.ComponentModel.ISupportInitialize)(this.chart_forcasting)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_forcasting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_sesAlpha;
        private System.Windows.Forms.TextBox textBox_sesError;
        private System.Windows.Forms.Label label2;
    }
}

