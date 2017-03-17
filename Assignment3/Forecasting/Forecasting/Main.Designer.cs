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
            ((System.ComponentModel.ISupportInitialize)(this.chart_forcasting)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_forcasting
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_forcasting.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_forcasting.Legends.Add(legend1);
            this.chart_forcasting.Location = new System.Drawing.Point(12, 12);
            this.chart_forcasting.Name = "chart_forcasting";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_forcasting.Series.Add(series1);
            this.chart_forcasting.Size = new System.Drawing.Size(660, 401);
            this.chart_forcasting.TabIndex = 0;
            this.chart_forcasting.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            title1.Name = "title_forecastingSes";
            title1.Text = "Sword Forecasting";
            this.chart_forcasting.Titles.Add(title1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 546);
            this.Controls.Add(this.chart_forcasting);
            this.Name = "Main";
            this.Text = "Forecasting";
            ((System.ComponentModel.ISupportInitialize)(this.chart_forcasting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_forcasting;
    }
}

