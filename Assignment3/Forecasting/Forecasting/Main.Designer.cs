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
            this.chart_forcastingSes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_forcastingSes)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_forcastingSes
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_forcastingSes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_forcastingSes.Legends.Add(legend1);
            this.chart_forcastingSes.Location = new System.Drawing.Point(12, 12);
            this.chart_forcastingSes.Name = "chart_forcastingSes";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_forcastingSes.Series.Add(series1);
            this.chart_forcastingSes.Size = new System.Drawing.Size(660, 401);
            this.chart_forcastingSes.TabIndex = 0;
            this.chart_forcastingSes.Text = "chart1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 546);
            this.Controls.Add(this.chart_forcastingSes);
            this.Name = "Main";
            this.Text = "Forecasting";
            ((System.ComponentModel.ISupportInitialize)(this.chart_forcastingSes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_forcastingSes;
    }
}

