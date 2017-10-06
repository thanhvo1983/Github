using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kvics.Controls.Chart;

namespace Hotmill.Test
{
    public partial class TestChartForm_V4 : Form
    {
        public TestChartForm_V4()
        {
            InitializeComponent();
        }

        private void TestChartForm_V4_Load(object sender, EventArgs e)
        {
            /*
            customChart1.CategoryColor = Color.Black;
            
            customChart1.CategoryAxis1.Color = Color.Black;
            customChart1.CategoryAxis2.Color = Color.Black;
            
            customChart1.CategoryAxis1.TextFormat.Color = Color.Black;
            customChart1.CategoryAxis2.TextFormat.Color = Color.Black;
            
            customChart1.CategoryAxis1.MajorTick.Color = Color.Black;
            customChart1.CategoryAxis2.MajorTick.Color = Color.Black;
            
            customChart1.CategoryAxis1.MinorTick.Color = Color.Black;
            customChart1.CategoryAxis2.MinorTick.Color = Color.Black;

            customChart1.ValueAxis1.Color = Color.Black;
            customChart1.ValueAxis2.Color = Color.Black;

            customChart1.ValueAxis1.TextFormat.Color = Color.Black;
            customChart1.ValueAxis2.TextFormat.Color = Color.Black;

            customChart1.CategoryAxis.Color = Color.Black;
            customChart1.CategoryAxis.Title.Color = Color.Black;
            customChart1.CategoryAxis.MajorTick.Color = Color.Black;
            */
            //customChart1.GridLine1_DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            //customChart1.GridLine2_DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            //customChart1.Category;

            //customChart2.SkipFirstTickMark = true;
            //customChart2.SkipLastTickMark = true;
            #region LineSeries 1 Chart 4
            LineSeries lineseries = new LineSeries("Test");
            lineseries.IsSolidLine = false;
            lineseries.Marker.Style = MarkerStyle.THANG;
            lineseries.Marker.Size = 19;
            //lineseries.Marker.Size = 1;
            lineseries.Color = Color.SkyBlue;
            lineseries.Marker.ForeColor = Color.SkyBlue;

            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(11);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(11);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(30);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(40);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(30);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(60);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(50);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(60);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(70);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(50);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(30);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(70);
            lineseries.Values.Add(Double.MinValue);
            lineseries.Values.Add(10);
            lineseries.Values.Add(Double.MinValue);

            customChart4.ValueAxis2.LineSeries.Add(lineseries);
            #endregion

            #region LineSeries 2 Chart 4
            LineSeries lineseries2 = new LineSeries("Test2");
            lineseries2.IsSolidLine = false;
            lineseries2.Marker.Style = MarkerStyle.THANG;
            lineseries2.Marker.Size = 21;
            lineseries2.Color = Color.Orange;
            lineseries2.Marker.ForeColor = Color.Orange;

            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);
            lineseries2.Values.Add(10);
            lineseries2.Values.Add(Double.MinValue);

            customChart4.ValueAxis2.LineSeries.Add(lineseries2);
            #endregion

            #region LineSeries 1 Chart 2
            LineSeries lineseries3 = new LineSeries("Test3");
            lineseries3.Marker.Style = MarkerStyle.TAM_GIAC;
            lineseries3.Marker.Size = 10;
            lineseries3.Color = Color.Blue;
            lineseries3.Marker.ForeColor = Color.White;
            lineseries3.Marker.BackColor = Color.Blue;

            lineseries3.Values.Add(1100);
            lineseries3.Values.Add(1100);
            lineseries3.Values.Add(3000);
            lineseries3.Values.Add(4000);
            lineseries3.Values.Add(3000);
            lineseries3.Values.Add(3500);
            lineseries3.Values.Add(2400);
            lineseries3.Values.Add(1900);
            lineseries3.Values.Add(3200);
            lineseries3.Values.Add(1400);
            lineseries3.Values.Add(2800);
            lineseries3.Values.Add(1900);
            lineseries3.Values.Add(1000);
            lineseries3.Values.Add(1100);
            lineseries3.Values.Add(1260);
            lineseries3.Values.Add(3000);
            lineseries3.Values.Add(2100);
            lineseries3.Values.Add(3000);
            lineseries3.Values.Add(3400);
            lineseries3.Values.Add(1500);
            lineseries3.Values.Add(2400);
            lineseries3.Values.Add(2500);
            lineseries3.Values.Add(3200);
            lineseries3.Values.Add(3000);
            lineseries3.Values.Add(1900);
            lineseries3.Values.Add(1000);
            lineseries3.Values.Add(2100);
            lineseries3.Values.Add(1100);
            lineseries3.Values.Add(3000);
            lineseries3.Values.Add(1700);
            lineseries3.Values.Add(3800);

            customChart2.ValueAxis1.LineSeries.Add(lineseries3);
            #endregion

            #region TetragonSeries 1 Chart 2
            TetragonSeries tetragonSeries1 = new TetragonSeries("Test TetragonSeries");
            tetragonSeries1.Color = Color.LightYellow;

            tetragonSeries1.Values.Add(new MinMax(1100, 1500));
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax(1500, 3300));
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax());
            tetragonSeries1.Values.Add(new MinMax(1200, 2500));

            customChart2.ValueAxis1.TetragonSeries.Add(tetragonSeries1);
            #endregion

            #region BarSeries 1 Chart 3
            BarSeries barSeries1 = new BarSeries("Bar 1");
            barSeries1.BorderSize = 1;
            barSeries1.BorderColor = Color.White;
            barSeries1.Color = Color.Yellow;
            barSeries1.Size = 40;

            barSeries1.Values.Add(150);
            barSeries1.Values.Add(150);
            barSeries1.Values.Add(150);
            barSeries1.Values.Add(150);
            barSeries1.Values.Add(150);
            barSeries1.Values.Add(150);
            barSeries1.Values.Add(150);

            customChart3.ValueAxis1.BarSeries.Add(barSeries1);
            #endregion

            #region BarSeries 2 Chart 1
            BarSeries barSeries2 = new BarSeries("Bar 2");
            barSeries2.BorderSize = 1;
            barSeries2.BorderColor = Color.White;
            barSeries2.Color = Color.Red;
            barSeries2.Size = 25;

            barSeries2.Values.Add(180);
            barSeries2.Values.Add(140);
            barSeries2.Values.Add(100);
            barSeries2.Values.Add(80);
            barSeries2.Values.Add(50);
            barSeries2.Values.Add(30);
            barSeries2.Values.Add(20);

            customChart1.ValueAxis1.BarSeries.Add(barSeries2);
            #endregion

            #region BarSeries 3 Chart 1
            BarSeries barSeries3 = new BarSeries("Bar 3");
            barSeries3.BorderSize = 1;
            barSeries3.BorderColor = Color.White;
            barSeries3.Color = Color.Yellow;
            barSeries3.Size = 25;

            barSeries3.Values.Add(180);
            barSeries3.Values.Add(140);
            barSeries3.Values.Add(100);
            barSeries3.Values.Add(80);
            barSeries3.Values.Add(50);
            barSeries3.Values.Add(30);
            barSeries3.Values.Add(20);

            customChart1.ValueAxis1.BarSeries.Add(barSeries3);
            #endregion
        }
    }
}