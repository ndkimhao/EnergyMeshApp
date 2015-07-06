using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using EnergyMonitorApp.Properties;
using System.IO;
using System.Threading;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro.ColorTables;
using ZedGraph;

namespace EnergyMonitorApp
{
	public partial class MainForm : MetroForm
	{

		public MainForm()
		{
			InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
			gridDeviceInit();
			gridBlockInit();
			cbThemeInit();
		}

		#region "Device compare function"

		private void lbDeviceCompare_SelectedIndexChanged(object sender, EventArgs e)
		{
			var sItems = lbDeviceCompare.SelectedItems;
			if (sItems.Count > 0)
			{
				DateTime beginTime = DateTime.MaxValue;
				DateTime endTime = DateTime.MinValue;
				foreach (Device dev in sItems)
				{
					if (dev.BeginTime < beginTime)
					{
						beginTime = dev.BeginTime;
					}
					if (dev.EndTime > endTime)
					{
						endTime = dev.EndTime;
					}
				}
				dtCompareBegin.Enabled = dtCompareEnd.Enabled = btnUpdateCompare.Enabled = true;
				dtCompareBegin.Value = dtCompareBegin.MinDate = dtCompareEnd.MinDate = beginTime;
				dtCompareEnd.Value = dtCompareBegin.MaxDate = dtCompareEnd.MaxDate = endTime;
			}
			else
			{
				dtCompareBegin.Enabled = dtCompareEnd.Enabled = btnUpdateCompare.Enabled = false;
				dtCompareBegin.Value = dtCompareBegin.MinDate = dtCompareEnd.MinDate = DateTime.Now;
				dtCompareEnd.Value = dtCompareBegin.MaxDate = dtCompareEnd.MaxDate = DateTime.Now;
			}
		}

		private void btnUpdateCompare_Click(object sender, EventArgs e)
		{
			var sItems = lbDeviceCompare.SelectedItems;
			DateTime beginTime = dtCompareBegin.MinDate;
			DateTime endTime = dtCompareEnd.MaxDate;
			if (dtCompareBegin.Value >= dtCompareEnd.Value)
			{
				MessageBoxEx.Show(this, "<font size='18'><b>Ngày bắt đầu phải trước ngày kết thúc !</b></font>",
						"<font size='15'><b>Thông báo</b></font>", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dtCompareBegin.Value = beginTime;
				dtCompareEnd.Value = endTime;
			}
			else
			{
				if (dtCompareBegin.Value < beginTime)
				{
					dtCompareBegin.Value = beginTime;
				}
				if (dtCompareEnd.Value > endTime)
				{
					dtCompareEnd.Value = endTime;
				}
			}
			new Thread(GenerateCompareGraph).Start();
		}

		private readonly Color[] compareColor = new Color[] { Color.Red,Color.Blue,Color.Green,Color.Gold,Color.Gainsboro,
		Color.Black,Color.CadetBlue,Color.Brown,Color.Gray,Color.Ivory,Color.Violet,Color.Tomato,Color.SteelBlue,Color.MistyRose };
		private void GenerateCompareGraph()
		{
			var sItems = lbDeviceCompare.SelectedItems;
			int sCount = sItems.Count;
			if (sCount > 0)
			{
				lblStatus.Text = "Đang thống kê dữ liệu...";
				progDeviceCompare.IsRunning = true;

				DateTime beginTime = dtCompareBegin.Value;
				DateTime endTime = dtCompareEnd.Value;
				GraphPane pane = graphCompare.GraphPane;
				pane.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

				pane.Title.Text = "Thống kê các thiết bị theo " + cbCompareType.SelectedItem;
				pane.YAxis.Title.Text = "Điện năng tiêu thụ (WH)";
				pane.XAxis.Title.Text = "Khoảng thời gian";
				int type = cbCompareType.SelectedIndex;
				string[] arrLabel = null;
				double[][] arrValue = null;
				if (type == 0)
				{
					arrLabel = new string[24];
					arrValue = new double[sCount][];
					for (int i = 0; i < 24; i++)
					{
						arrLabel[i] = i + "h";
					}
				}
				else if (type == 1)
				{
					arrLabel = new string[7];
					arrValue = new double[sCount][];
					for (int i = 2; i <= 7; i++)
					{
						arrLabel[i - 2] = "Thứ " + i;
					}
					arrLabel[6] = "Chủ nhật";
				}
				else if (type == 2)
				{
					arrLabel = new string[31];
					arrValue = new double[sCount][];
					for (int i = 1; i <= 31; i++)
					{
						arrLabel[i - 1] = i.ToString();
					}
				}
				else if (type == 3)
				{
					arrLabel = new string[12];
					arrValue = new double[sCount][];
					for (int i = 1; i <= 12; i++)
					{
						arrLabel[i - 1] = i.ToString();
					}
				}
				for (int i = 0; i < sCount; i++)
				{
					arrValue[i] = new double[arrLabel.Length];
				}
				pane.XAxis.MajorTic.IsBetweenLabels = true;
				pane.XAxis.Scale.TextLabels = arrLabel;
				pane.XAxis.Type = AxisType.Text;
				pane.BarSettings.Type = BarType.Stack;

				double totalWH = 0;
				double WH = 0;
				for (int d = 0; d < sCount; d++)
				{
					foreach (long blockID in ((Device)sItems[d]).BlockList)
					{
						PowerBlock block = LogManager.PowerBlockList[blockID];
						int forTo = block.RealPowerList.Count - 1;
						for (int i = 0; i < block.RealPowerList.Count; i++)
						{
							Log_ClientRealPower rec = block.RealPowerList[i];
							if (rec.Time < beginTime || rec.Time > endTime) continue;
							if (i < forTo)
							{
								TimeSpan diff = block.RealPowerList[i + 1].Time - rec.Time;
								WH = rec.RealPower * diff.TotalSeconds;
								totalWH += WH;
							}
							if (type == 0)
							{
								arrValue[d][rec.Time.Hour - 1] += WH;
							}
							else if (type == 1)
							{
								int idx = (int)rec.Time.DayOfWeek;
								if (idx == 0)
									idx = 6;
								else
									idx -= 1;
								arrValue[d][idx] += WH;
							}
							else if (type == 2)
							{
								arrValue[d][rec.Time.Day - 1] += WH;
							}
							else if (type == 3)
							{
								arrValue[d][rec.Time.Month - 1] += WH;
							}
						}
					}
				}
				pane.CurveList.Clear();

				if (cbComparePieChart.Checked)
				{
					double[] arrValue1D = new double[sCount];
					double total = 0;
					for (int i = 0; i < sCount; i++)
					{
						double tmp = 0;
						for (int j = 0; j < arrLabel.Length; j++)
						{
							tmp += arrValue[i][j];
						}
						arrValue1D[i] = tmp;
						total += tmp;
					}
					for (int i = 0; i < sCount; i++)
					{
						double val = arrValue1D[i];
						if (val > 0)
						{
							Color c1 = pieChartColor[rand.Next(pieChartColor.Length)];
							Color c2 = pieChartColor[rand.Next(pieChartColor.Length)];
							float angle = (float)rand.NextDouble() * 180;
							val = val * 100 / total;
							double displacement = CaclDisplacement(val);
							pane.AddPieSlice(val, c1, c2, angle, displacement, ((Device)sItems[i]).Name);
						}
					}
				}
				else
				{
					pane.XAxis.IsVisible = true;
					pane.YAxis.IsVisible = true;
					for (int i = 0; i < sCount; i++)
					{
						bool hasVal = false;
						for (int j = 0; j < arrLabel.Length; j++)
						{
							if (arrValue[i][j] > 0)
							{
								arrValue[i][j] /= 3600;
								hasVal = true;
							}
						}
						if (hasVal)
						{
							BarItem myBar = pane.AddBar(((Device)sItems[i]).Name, null, arrValue[i], Color.Red);
							Color c = compareColor[i];
							myBar.Bar.Fill = new Fill(c, Color.White, c);
						}
					}
				}

				Graphics g = this.CreateGraphics();
				pane.YAxis.ResetAutoScale(pane, g);
				pane.Y2Axis.ResetAutoScale(pane, g);
				pane.XAxis.ResetAutoScale(pane, g);
				g.Dispose();
				pane.ZoomStack.Clear();
				pane.XAxis.Scale.Format = "HH:mm dd/MM/yy";

				graphCompare.AxisChange();
				graphCompare.Refresh();
				totalWH /= 3600;
				if (totalWH > 1000)
				{
					txtComparePower.Text = (totalWH / 1000).ToString("F2") + " kWH";
				}
				else
				{
					txtComparePower.Text = totalWH.ToString("F2") + " WH";
				}
				txtComparePrice.Text = (totalWH * 1622.05 / 1000).ToString("n0") + " đ";

				progDeviceCompare.IsRunning = false;
				lblStatus.Text = "Thống kê dữ liệu hoàn tất";
			}
		}

		#endregion

		#region "Device statistic function"

		private void cbDeviceStatistic_SelectedIndexChanged(object sender, EventArgs e)
		{
			Device dev = (Device)cbDeviceStatistic.SelectedItem;
			if (dev != null)
			{
				DateTime beginTime = dev.BeginTime;
				DateTime endTime = dev.EndTime;
				if (beginTime != DateTime.MaxValue && endTime != DateTime.MinValue)
				{
					cbStatisticType.Enabled = dtStatisticBegin.Enabled = dtStatisticEnd.Enabled = btnUpdateStatistic.Enabled = true;
					dtStatisticBegin.Value = dtStatisticBegin.MinDate = dtStatisticEnd.MinDate = beginTime;
					dtStatisticEnd.Value = dtStatisticBegin.MaxDate = dtStatisticEnd.MaxDate = endTime;
				}
				else
				{
					cbStatisticType.Enabled = dtStatisticBegin.Enabled = dtStatisticEnd.Enabled = btnUpdateStatistic.Enabled = false;
					dtStatisticBegin.Value = dtStatisticBegin.MinDate = dtStatisticEnd.MinDate = DateTime.Now;
					dtStatisticEnd.Value = dtStatisticBegin.MaxDate = dtStatisticEnd.MaxDate = DateTime.Now;
				}
			}
		}

		private void btnUpdateStatistic_Click(object sender, EventArgs e)
		{
			Device dev = (Device)cbDeviceStatistic.SelectedItem;
			if (dev != null)
			{
				DateTime beginTime = dev.BeginTime;
				DateTime endTime = dev.EndTime;
				if (dtStatisticBegin.Value >= dtStatisticEnd.Value)
				{
					MessageBoxEx.Show(this, "<font size='18'><b>Ngày bắt đầu phải trước ngày kết thúc !</b></font>",
							"<font size='15'><b>Thông báo</b></font>", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					dtStatisticBegin.Value = beginTime;
					dtStatisticEnd.Value = endTime;
				}
				else
				{
					if (dtStatisticBegin.Value < beginTime)
					{
						dtStatisticBegin.Value = beginTime;
					}
					if (dtStatisticEnd.Value > endTime)
					{
						dtStatisticEnd.Value = endTime;
					}
				}
			}
			new Thread(GenerateStatisticGraph).Start();
		}

		private readonly Color[] pieChartColor = new Color[] { 
			Color.AliceBlue,Color.AntiqueWhite,Color.Aqua,Color.Aquamarine,Color.Azure,Color.Beige,Color.Bisque,Color.BlanchedAlmond,Color.Cornsilk,
			Color.Cyan,Color.LightBlue,Color.LightCoral,Color.LightCyan,Color.LightGoldenrodYellow,Color.LightGray,Color.LightGreen,Color.LightPink,
			Color.LightSalmon,Color.LightSeaGreen,Color.LightSkyBlue,Color.LightYellow,Color.PapayaWhip,Color.PeachPuff,Color.Thistle,Color.WhiteSmoke,
			Color.Red,Color.Green,Color.Gray,Color.Yellow,Color.LimeGreen,Color.MediumAquamarine,Color.Brown,Color.BlueViolet,Color.Violet
		};
		private Random rand = new Random();
		private void GenerateStatisticGraph()
		{
			Device dev = (Device)cbDeviceStatistic.SelectedItem;
			if (dev != null)
			{
				lblStatus.Text = "Đang thống kê dữ liệu...";
				progDeviceStatistic.IsRunning = true;

				DateTime beginTime = dtStatisticBegin.Value;
				DateTime endTime = dtStatisticEnd.Value;
				GraphPane pane = graphStatistic.GraphPane;
				pane.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

				pane.Title.Text = "Thống kê " + dev.Name + " theo " + cbStatisticType.SelectedItem;
				pane.YAxis.Title.Text = "Điện năng tiêu thụ (WH)";
				pane.XAxis.Title.Text = "Khoảng thời gian";
				int type = cbStatisticType.SelectedIndex;
				string[] arrLabel = null;
				double[] arrValue = null;
				if (type == 0)
				{
					arrLabel = new string[24];
					arrValue = new double[24];
					for (int i = 0; i < 24; i++)
					{
						arrLabel[i] = i + "h";
					}
				}
				else if (type == 1)
				{
					arrLabel = new string[7];
					arrValue = new double[7];
					for (int i = 2; i <= 7; i++)
					{
						arrLabel[i - 2] = "Thứ " + i;
					}
					arrLabel[6] = "Chủ nhật";
				}
				else if (type == 2)
				{
					arrLabel = new string[31];
					arrValue = new double[31];
					for (int i = 1; i <= 31; i++)
					{
						arrLabel[i - 1] = i.ToString();
					}
				}
				else if (type == 3)
				{
					arrLabel = new string[12];
					arrValue = new double[12];
					for (int i = 1; i <= 12; i++)
					{
						arrLabel[i - 1] = i.ToString();
					}
				}
				pane.XAxis.MajorTic.IsBetweenLabels = true;
				pane.XAxis.Scale.TextLabels = arrLabel;
				pane.XAxis.Type = AxisType.Text;

				double totalWH = 0;
				double WH = 0;
				foreach (long blockID in dev.BlockList)
				{
					PowerBlock block = LogManager.PowerBlockList[blockID];
					int forTo = block.RealPowerList.Count - 1;
					for (int i = 0; i < block.RealPowerList.Count; i++)
					{
						Log_ClientRealPower rec = block.RealPowerList[i];
						if (rec.Time < beginTime || rec.Time > endTime) continue;
						if (i < forTo)
						{
							TimeSpan diff = block.RealPowerList[i + 1].Time - rec.Time;
							WH = rec.RealPower * diff.TotalSeconds;
							totalWH += WH;
						}
						if (type == 0)
						{
							arrValue[rec.Time.Hour - 1] += WH;
						}
						else if (type == 1)
						{
							int idx = (int)rec.Time.DayOfWeek;
							if (idx == 0)
								idx = 6;
							else
								idx -= 1;
							arrValue[idx] += WH;
						}
						else if (type == 2)
						{
							arrValue[rec.Time.Day - 1] += WH;
						}
						else if (type == 3)
						{
							arrValue[rec.Time.Month - 1] += WH;
						}
					}
				}

				pane.CurveList.Clear();
				if (cbStatisticPieChart.Checked)
				{
					Dictionary<int, double> dictTmp = new Dictionary<int, double>();
					for (int i = 0; i < arrValue.Length; i++)
					{
						dictTmp.Add(i, arrValue[i] * 100 / totalWH);
					}
					var pairs = dictTmp.OrderByDescending(i => i.Value);
					Dictionary<int, double> dictTmpFinal = new Dictionary<int, double>();
					for (int i = 0; i < 3; i++)
					{
						var pair = pairs.ElementAt(0);
						dictTmpFinal.Add(pair.Key, pair.Value);
						dictTmp.Remove(pair.Key);
					}
					double otherValue = 0;
					foreach (var pair in dictTmp)
					{
						if (pair.Value > 10)
						{
							dictTmpFinal.Add(pair.Key, pair.Value);
						}
						else
						{
							otherValue += pair.Value;
						}
					}
					foreach (var pair in dictTmpFinal)
					{
						if (pair.Value > 0)
						{
							Color c1 = pieChartColor[rand.Next(pieChartColor.Length)];
							Color c2 = pieChartColor[rand.Next(pieChartColor.Length)];
							float angle = (float)rand.NextDouble() * 180;
							double displacement = CaclDisplacement(pair.Value);
							pane.AddPieSlice(pair.Value, c1, c2, angle, displacement, arrLabel[pair.Key]);
						}
					}
					if (otherValue > 0)
					{
						Color c1 = pieChartColor[rand.Next(pieChartColor.Length)];
						Color c2 = pieChartColor[rand.Next(pieChartColor.Length)];
						float angle = (float)rand.NextDouble() * 180;
						double displacement = CaclDisplacement(otherValue);
						pane.AddPieSlice(otherValue, c1, c2, angle, displacement, "Khác");
					}
				}
				else
				{
					pane.XAxis.IsVisible = true;
					pane.YAxis.IsVisible = true;
					for (int i = 0; i < arrValue.Length; i++)
					{
						arrValue[i] /= 3600;
					}
					BarItem myBar = pane.AddBar("Điện năng tiêu thụ (WH)", null, arrValue, Color.Red);
					myBar.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);
				}

				Graphics g = this.CreateGraphics();
				pane.YAxis.ResetAutoScale(pane, g);
				pane.Y2Axis.ResetAutoScale(pane, g);
				pane.XAxis.ResetAutoScale(pane, g);
				g.Dispose();
				pane.ZoomStack.Clear();
				pane.XAxis.Scale.Format = "HH:mm dd/MM/yy";

				graphStatistic.AxisChange();
				graphStatistic.Refresh();

				totalWH /= 3600;
				if (totalWH > 1000)
				{
					txtStatisticPower.Text = (totalWH / 1000).ToString("F2") + " kWH";
				}
				else
				{
					txtStatisticPower.Text = totalWH.ToString("F2") + " WH";
				}
				txtStatisticPrice.Text = (totalWH * 1622.05 / 1000).ToString("n0") + " đ";

				progDeviceStatistic.IsRunning = false;
				lblStatus.Text = "Thống kê dữ liệu hoàn tất";
			}
		}

		private static double CaclDisplacement(double value)
		{
			double displacement = 0;
			if (value < 20)
			{
				displacement = 0.05;
			}
			else if (value < 40)
			{
				displacement = 0.04;
			}
			else if (value < 60)
			{
				displacement = 0.03;
			}
			else if (value < 80)
			{
				displacement = 0.02;
			}
			else
			{
				displacement = 0.01;
			}
			return displacement;
		}

		#endregion

		#region "Device history function"

		private void cbDeviceHisStatisCompareInit()
		{
			cbDeviceHistory.Items.Clear();
			cbDeviceStatistic.Items.Clear();
			lbDeviceCompare.Items.Clear();
			foreach (Device dev in DeviceManager.DeviceList)
			{
				if (!dev.IsDeleted)
				{
					cbDeviceHistory.Items.Add(dev);
					cbDeviceStatistic.Items.Add(dev);
					lbDeviceCompare.Items.Add(dev);
				}
			}
			cbDeviceHistory.SelectedIndex = 0;
			cbHistoryY2.SelectedIndex = 0;
			cbDeviceStatistic.SelectedIndex = 0;
			cbStatisticType.SelectedIndex = 0;
			cbCompareType.SelectedIndex = 0;
			cbDeviceHisStatisCompareUpdate();
		}

		private void cbDeviceHisStatisCompareUpdate()
		{
			if (cbDeviceHistory.Items.Count > 0)
			{
				cbDeviceHistory_SelectedIndexChanged(this, null);
				cbDeviceStatistic_SelectedIndexChanged(this, null);
				lbDeviceCompare_SelectedIndexChanged(this, null);
				cbStatisticType.SelectedIndex = 0;
				cbCompareType.SelectedIndex = 0;
				cbHistoryY2.SelectedIndex = 0;
			}
		}

		private void GenerateHistoryGraph()
		{
			Device dev = (Device)cbDeviceHistory.SelectedItem;
			if (dev != null)
			{
				int y2val = cbHistoryY2.SelectedIndex;
				lblStatus.Text = "Đang thống kê dữ liệu...";
				progDeviceHistory.IsRunning = true;

				DateTime beginTime = dtHistoryBegin.Value;
				DateTime endTime = dtHistoryEnd.Value;
				GraphPane pane = graphHistory.GraphPane;

				pane.Title.Text = "Lịch sử tiêu thụ: " + dev.Name;
				pane.YAxis.Title.Text = "Công suất thực (W)";
				if (y2val == 0)
				{
					pane.Y2Axis.Title.Text = "Dòng điện tiêu thụ (A)";
				}
				else if (y2val == 1)
				{
					pane.Y2Axis.Title.Text = "Điện áp (V)";
				}
				else if (y2val == 2)
				{
					pane.Y2Axis.Title.Text = "Công suất biểu kiến (VA)";
				}
				pane.Y2Axis.IsVisible = true;
				pane.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

				pane.XAxis.Type = AxisType.Date;
				pane.XAxis.Title.Text = "Thời gian";
				pane.XAxis.Scale.Format = "HH:mm dd/MM/yy";
				pane.XAxis.Scale.FontSpec.Size = 8;

				double wh = 0;
				List<double> powerList_X = new List<double>();
				List<double> powerList_Y = new List<double>();
				List<double> subList_X = new List<double>();
				List<double> subList_Y = new List<double>();
				foreach (long blockID in dev.BlockList)
				{
					PowerBlock block = LogManager.PowerBlockList[blockID];
					bool isFirst = true;
					int forTo = block.RealPowerList.Count - 1;
					for (int i = 0; i < block.RealPowerList.Count; i++)
					{
						Log_ClientRealPower rec = block.RealPowerList[i];
						if (rec.Time < beginTime || rec.Time > endTime) continue;
						if (i < forTo)
						{
							TimeSpan diff = block.RealPowerList[i + 1].Time - rec.Time;
							wh += rec.RealPower * diff.TotalSeconds;
						}
						if (isFirst)
						{
							isFirst = false;
							double lastDt;
							if (powerList_X.Count > 0 && Math.Abs((rec.Time - DateTime.FromOADate(lastDt = powerList_X.Last())).TotalSeconds) > 20)
							{
								powerList_Y.Add(-1);
								powerList_X.Add(lastDt);
								powerList_Y.Add(0);
								powerList_X.Add(rec.Time.ToOADate());
								powerList_Y.Add(0);
							}
							if (powerList_X.Count == 0)
							{
								powerList_X.Add(rec.Time.ToOADate());
								powerList_Y.Add(0);
							}
						}
						powerList_X.Add(rec.Time.ToOADate());
						powerList_Y.Add(rec.RealPower);
					}

					isFirst = true;
					foreach (Log_ClientDetailPower rec in block.DetailPowerList)
					{
						if (rec.Time < beginTime || rec.Time > endTime) continue;
						if (isFirst)
						{
							isFirst = false;
							double lastDt;
							if (subList_X.Count > 0 && Math.Abs((rec.Time - DateTime.FromOADate(lastDt = subList_X.Last())).TotalSeconds) > 20)
							{
								subList_Y.Add(-1);
								subList_X.Add(lastDt);
								subList_Y.Add(0);
								subList_X.Add(rec.Time.ToOADate());
								subList_Y.Add(0);
							}
							if (subList_X.Count == 0)
							{
								subList_X.Add(rec.Time.ToOADate());
								subList_Y.Add(0);
							}
						}
						subList_X.Add(rec.Time.ToOADate());
						if (y2val == 0)
						{
							subList_Y.Add(rec.I);
						}
						else if (y2val == 1)
						{
							subList_Y.Add(rec.V);
						}
						else if (y2val == 2)
						{
							subList_Y.Add(rec.I * rec.V);
						}
					}
				}

				if (powerList_X.Count > 0)
				{
					powerList_X.Add(powerList_X.Last());
					powerList_Y.Add(0);
					powerList_Y.Add(-1);
				}
				if (subList_X.Count > 0)
				{
					subList_X.Add(subList_X.Last());
					subList_Y.Add(0);
					subList_Y.Add(-1);
				}

				pane.CurveList.Clear();
				LineItem curve;

				curve = pane.AddCurve("Công suất thực (P-W)", powerList_X.ToArray(), filterSignal(powerList_Y.ToArray(), 175, 5, 3), Color.Red, SymbolType.None);
				curve.Line.Width = 2.0F;

				if (y2val == 0)
				{
					curve = pane.AddCurve("Dòng điện (I-A)", subList_X.ToArray(), filterSignal(subList_Y.ToArray(), 50, 1, 2), Color.Blue, SymbolType.None);
					curve.IsY2Axis = true;
				}
				else if (y2val == 1)
				{
					curve = pane.AddCurve("Điện áp (U-V)", subList_X.ToArray(), filterSignal(subList_Y.ToArray(), 5, 0, 0), Color.Blue, SymbolType.None);
					curve.IsY2Axis = true;
				}
				else if (y2val == 2)
				{
					curve = pane.AddCurve("Công suất biểu kiến (S-VA)", subList_X.ToArray(), filterSignal(subList_Y.ToArray(), 50, 1, 2), Color.Blue, SymbolType.None);
					curve.IsY2Axis = false;
				}

				Graphics g = this.CreateGraphics();
				pane.YAxis.ResetAutoScale(pane, g);
				pane.Y2Axis.ResetAutoScale(pane, g);
				pane.XAxis.ResetAutoScale(pane, g);
				g.Dispose();
				pane.ZoomStack.Clear();
				pane.XAxis.Scale.Format = "HH:mm dd/MM/yy";

				graphHistory.AxisChange();
				graphHistory.Refresh();

				wh /= 3600;
				if (wh > 1000)
				{
					wh /= 1000;
					txtDeviceHistoryPower.Text = wh.ToString("F2") + " kWH";
				}
				else
				{
					txtDeviceHistoryPower.Text = wh.ToString("F2") + " WH";
				}

				progDeviceHistory.IsRunning = false;
				lblStatus.Text = "Thống kê dữ liệu hoàn tất";
			}
		}

		private double[] filterSignal(double[] input, int look, int rippleLook, int rippleThreshold)
		{
			List<double> output = new List<double>();
			List<double> tmpList = new List<double>();
			for (int i = 0; i < input.Length; i++)
			{
				double val = input[i];
				if (val != -1)
				{
					tmpList.Add(val);
				}
				else
				{
					output.AddRange(_filterSignal(tmpList.ToArray(), look, rippleLook, rippleThreshold));
					tmpList = new List<double>();
				}
			}
			return output.ToArray();
		}

		private double[] _filterSignal(double[] input, int look, int rippleLook, int rippleThreshold)
		{
			double[] output = new double[input.Length];
			if (look * 2 >= input.Length)
			{
				look = input.Length / 2;
			}
			int iTo = input.Length - look - 1;
			int length = input.Length;
			double sum, iS0, iS2;
			int avgCount, jTo;
			for (int i = 0; i < input.Length; i++)
			{
				// Ripple filter
				if (input[i] == 0)
				{
					output[i] = 0;
					continue;
				}
				if (rippleThreshold > 0)
				{
					int start = Math.Max(0, i - rippleLook);
					int end = Math.Min(length, i + rippleLook);
					int zeroCount = 0;
					for (int k = start; k < end; k++)
					{
						if (input[k] == 0) zeroCount++;
					}
					if (zeroCount >= rippleThreshold)
					{
						output[i] = 0;
						continue;
					}
				}
				// Real filter
				sum = 0;
				avgCount = 0;
				jTo = Math.Min(length, i + look);
				for (int j = Math.Max(0, i - look); j < jTo; j++)
				{
					double val = input[j];
					if (val != 0)
					{
						sum += val;
						avgCount++;
					}
				}
				iS0 = output[i] = sum / avgCount;
				if (i >= 2 && iS0 > 0 && output[i - 1] == 0 && (iS2 = output[i - 2]) > 0)
				{
					output[i - 1] = (iS0 + iS2) / 2;
				}
			}
			return output;
		}

		private void cbDeviceHistory_SelectedIndexChanged(object sender, EventArgs e)
		{
			Device dev = (Device)cbDeviceHistory.SelectedItem;
			if (dev != null)
			{
				DateTime beginTime = dev.BeginTime;
				DateTime endTime = dev.EndTime;
				if (beginTime != DateTime.MaxValue && endTime != DateTime.MinValue)
				{
					cbHistoryY2.Enabled = dtHistoryBegin.Enabled = dtHistoryEnd.Enabled = btnUpdateHistory.Enabled = true;
					dtHistoryBegin.Value = dtHistoryBegin.MinDate = dtHistoryEnd.MinDate = beginTime;
					dtHistoryEnd.Value = dtHistoryBegin.MaxDate = dtHistoryEnd.MaxDate = endTime;
				}
				else
				{
					cbHistoryY2.Enabled = dtHistoryBegin.Enabled = dtHistoryEnd.Enabled = btnUpdateHistory.Enabled = false;
					dtHistoryBegin.Value = dtHistoryBegin.MinDate = dtHistoryEnd.MinDate = DateTime.Now;
					dtHistoryEnd.Value = dtHistoryBegin.MaxDate = dtHistoryEnd.MaxDate = DateTime.Now;
				}
			}
		}

		private void btnUpdateHistory_Click(object sender, EventArgs e)
		{
			Device dev = (Device)cbDeviceHistory.SelectedItem;
			if (dev != null)
			{
				DateTime beginTime = dev.BeginTime;
				DateTime endTime = dev.EndTime;
				if (dtHistoryBegin.Value >= dtHistoryEnd.Value)
				{
					MessageBoxEx.Show(this, "<font size='18'><b>Ngày bắt đầu phải trước ngày kết thúc !</b></font>",
							"<font size='15'><b>Thông báo</b></font>", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					dtHistoryBegin.Value = beginTime;
					dtHistoryEnd.Value = endTime;
				}
				else
				{
					if (dtHistoryBegin.Value < beginTime)
					{
						dtHistoryBegin.Value = beginTime;
					}
					if (dtHistoryEnd.Value > endTime)
					{
						dtHistoryEnd.Value = endTime;
					}
				}
			}
			new Thread(GenerateHistoryGraph).Start();
		}

		#endregion

		#region "Block list function"


		private readonly Dictionary<int, Color> sensorColorDict = new Dictionary<int, Color>()
		{
			{2 << 8 | 0, Color.Red}
		};
		private void updateBlockList()
		{
			GridPanel panel = gridBlocks.PrimaryGrid;
			panel.Rows.Clear();
			foreach (PowerBlock block in LogManager.PowerBlockList.Values)
			{
				string id = string.Format("{0}.{1}.{2}", block.ClientID, block.SensorID, block.SessionID);
				string timeStr = block.BeginTime.ToString("HH:mm:ss dd/MM/yyyy") + "\r\n" +
					block.EndTime.ToString("HH:mm:ss dd/MM/yyyy");
				GridRow row = new GridRow(id, block.WH.ToString("F2") + " WH", timeStr, GetChartPoints(block), -1, "Nhập");
				Device owner = DeviceManager.getBlockOwner(block.ID);
				if (owner == null)
				{
					Color c = sensorColorDict[block.ClientID << 8 | block.SensorID];
					SetCellColor(row.Cells[0], c);
				}
				else
				{
					if (owner.Name == null)
					{
						row.Cells[4].Value = -2;
					}
					else
					{
						row.Cells[4].Value = owner.ID;
					}
				}
				row.Tag = block;
				panel.Rows.Add(row);
			}
		}

		private void gridBlockInit()
		{
			colBlockDevice.EditorType = typeof(GridImageComboDevice);
			colBlockDevice.EditorParams = new object[] { deviceImageListCombo, DeviceManager.DeviceList, deviceImageListCombo.ImageSize.Width * 2 };

			GridMicroChartEditControl mc = (GridMicroChartEditControl)colBlockChart.RenderControl;
			mc.LineChartStyle.LineColor = Color.Blue;
		}

		private void gridBlocks_CellClick(object sender, GridCellClickEventArgs e)
		{
			if (e.GridCell.ColumnIndex == 5)
			{
				GridPanel panel = gridDevice.PrimaryGrid;
				GridRow row = e.GridCell.GridRow;
				PowerBlock block = (PowerBlock)row.Tag;
				Device owner = DeviceManager.getBlockOwner(block.ID);
				DeviceManager.DeleteBlock(block.ID);
				int newDevID = (int)row.Cells[4].Value;
				if (newDevID == -1)
				{
					Color c = sensorColorDict[block.ClientID << 8 | block.SensorID];
					SetCellColor(row.Cells[0], c);
				}
				else
				{
					Device dev;
					if (newDevID == -2)
					{
						dev = DeviceManager.NullDevice;
					}
					else
					{
						dev = DeviceManager.getByID(newDevID);
					}
					if (!dev.BlockList.Exists(l => l == block.ID))
					{
						dev.BlockList.Add(block.ID);
						dev.BlockList.Sort((l1, l2) => l1.CompareTo(l2));
					}
					if (newDevID == -2 || owner == null || owner.ID != newDevID) SetCellColor(row.Cells[0], Color.Gray);
				}
				DeviceManager.SaveDeviceList();
				cbDeviceHisStatisCompareUpdate();
			}
		}

		private void SetCellColor(GridCell cell, Color c)
		{
			cell.CellStyles.Default.Background.Color1 = c;
			cell.CellStyles.Selected.Background.Color1 = c;
			cell.CellStyles.SelectedMouseOver.Background.Color1 = c;
		}

		private string GetChartPoints(PowerBlock block)
		{
			StringBuilder sb = new StringBuilder();
			foreach (Log_ClientRealPower rec in block.RealPowerList)
			{
				sb.Append(rec.RealPower.ToString("F2"));
				sb.Append(' ');
			}
			return sb.ToString();
		}

		#endregion

		#region "Device list function"

		private void gridDeviceInit()
		{
			colDeviceType.EditorType = typeof(MyGridImageEditControl);
			colDeviceType.EditorParams = new object[] { deviceImageList, ImageSizeMode.Zoom };
			colDeviceAction.EditorType = typeof(MyGridRadialMenuEditControl);
			((MyGridRadialMenuEditControl)colDeviceAction.EditControl).ItemClick += RadialDevice_ItemClick;

			GridPanel panel = gridDevice.PrimaryGrid;
			DeviceManager.LoadDeviceList();
			foreach (Device dev in DeviceManager.DeviceList)
			{
				if (!dev.IsDeleted)
				{
					panel.Rows.Add(new GridRow(dev.ID, dev.ImageKey, dev.Name, null));
				}
			}
		}

		private void RadialDevice_ItemClick(object sender, EventArgs e)
		{
			if (((BaseItem)sender).Tag != null)
			{
				RadialAction action = (RadialAction)((BaseItem)sender).Tag;
				GridPanel panel = gridDevice.PrimaryGrid;
				SelectedElementCollection selectedRows = gridDevice.GetSelectedRows();
				if (selectedRows.Count != 0)
				{
					int rowIndex = ((GridRow)selectedRows[0]).RowIndex;
					if (action == RadialAction.Delete)
					{
						string act = isAddingRow ? "HỦY</font> thiết bị vừa tạo" : "XÓA</font> thiết bị";
						if (MessageBoxEx.Show(this, "<font size='18'><b>Bạn có thật sự muốn <font color='#B02B2C'>" + act + " ?</b></font>",
							"<font size='15'><b>Xác nhận</b></font>", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							if (isAddingRow && rowIndex == (panel.Rows.Count - 1))
							{
								isAddingRow = false;
								gridDevice.PrimaryGrid.ShowInsertRow = false;
								gridDevice.PrimaryGrid.ShowInsertRow = true;
							}
							else
							{
								int ID = (int)((GridRow)panel.Rows[rowIndex]).Cells[0].Value;
								DeviceManager.getByID(ID).IsDeleted = true;
							}
							panel.Rows.RemoveAt(rowIndex);
							gridBlockInit();
						}
					}
					else if (action == RadialAction.Accept)
					{
						GridRow row = (GridRow)panel.Rows[rowIndex];
						if (isAddingRow && rowIndex == (panel.Rows.Count - 1))
						{
							Device dev = new Device()
							{
								ID = DeviceManager.GetNewId(),
								ImageKey = (string)row.Cells[1].Value,
								Name = (string)row.Cells[2].Value,
								IsDeleted = false,
								BlockList = new List<long>()
							};
							row.Cells[0].Value = dev.ID;
							DeviceManager.DeviceList.Add(dev);
							DeviceManager.SaveDeviceList();

							isAddingRow = false;
							gridDevice.PrimaryGrid.ShowInsertRow = true;
						}
						else
						{
							int ID = (int)row.Cells[0].Value;
							Device dev = DeviceManager.getByID(ID);
							dev.ImageKey = (string)row.Cells[1].Value;
							dev.Name = (string)row.Cells[2].Value;
							DeviceManager.SaveDeviceList();
						}
						row.RowDirty = false;
						gridBlockInit();
					}
					cbDeviceHisStatisCompareInit();
				}
			}
		}

		private void gridDevice_CloseEdit(object sender, GridCloseEditEventArgs e)
		{
			if (e.GridCell.ColumnIndex == 1)
			{
				e.GridCell.EditorType = typeof(MyGridImageEditControl);
				e.GridCell.EditorParams = new object[] { deviceImageList, ImageSizeMode.Zoom };
			}
		}

		private readonly Dictionary<string, string> deviceTypeDict = new Dictionary<string, string>()
		{
			{"air_conditioner.jpg", "Máy lạnh"},
			{"electric_socket.jpg", "Ổ cắm"},
			{"fan.jpg", "Quạt máy"},
			{"washing_machine.jpg", "Máy giặt"},
			{"water_heater.jpg", "Máy nước nóng"},
			{"line.jpg", "Đường điện"},
			{"other.jpg", "Khác"},
		};
		private void gridDevice_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
		{
			if (e.GridCell.ColumnIndex == 1)
			{
				e.GridCell.EditorType = typeof(GridImageCombo);
				e.GridCell.EditorParams = new object[] { deviceImageListCombo, deviceTypeDict, deviceImageListCombo.ImageSize.Width * 2 };
			}
		}

		private void gridDevice_RowSetDefaultValues(object sender, GridRowSetDefaultValuesEventArgs e)
		{
			if (e.NewRowContext == NewRowContext.RowInit)
			{
				GridRow row = e.GridRow;
				row.Cells[0].Value = "Mới";
				row.Cells[1].Value = Device.DefaultImageKey;
				row.Cells[2].Value = Device.DefaultName;
				row.Cells[3].Value = null;
			}
		}

		private bool isAddingRow = false;
		private void gridDevice_RowAdded(object sender, GridRowAddedEventArgs e)
		{
			gridDevice.PrimaryGrid.ShowInsertRow = false;
			isAddingRow = true;
			GridPanel panel = gridDevice.PrimaryGrid;
		}

		#endregion

		#region "Update Data"

		Thread updateDataThread;
		private void btnUpdateData_Click(object sender, EventArgs e)
		{
			if (updateDataThread == null || !updateDataThread.IsAlive)
			{
				updateDataThread = new Thread(doUpdateDate);
				updateDataThread.IsBackground = true;
				updateDataThread.Priority = ThreadPriority.Highest;
				updateDataThread.Start();
			}
		}

		private void doUpdateDate()
		{
			lbFileList.Visible = false;
			progUpdateData.IsRunning = true;

			lblStatus.Text = "Đang cập nhật dữ liệu...";

			List<string> curLog = LogManager.GetAllLog().Select(str => str.Replace('\\', '/')).ToList();
			List<string> listBoxItems = new List<string>();

			// Get data from ftp server
			try
			{
				string[] ftpList = NetHelper.ListLogsFTP();
				foreach (string uri in ftpList)
				{
					string path = uri.Replace(G.FTP_SERVER_URI, "");
					string realPath = "logs/" + path;
					try
					{
						if (File.Exists(realPath))
						{
							listBoxItems.Add(path + " (cũ)");
						}
						else
						{
							listBoxItems.Add(path + " (mới)");
							NetHelper.DownloadFTP(uri, realPath);
						}
						curLog.Remove(curLog.Find(str => realPath.Equals(str)));
					}
					catch
					{
						lblStatus.Text = "Tải file từ máy chủ FTP lỗi: " + path;
					}
				}
			}
			catch
			{
				lblStatus.Text = "Kết nối máy chủ FTP lỗi";
			}

			// Get data directly from Master
			try
			{
				string[] httpList = NetHelper.ListLogsHTTP();
				foreach (string uri in httpList)
				{
					try
					{
						string realPath = "logs/" + uri;
						NetHelper.DownloadHTTP(uri, realPath);
						if (File.Exists(realPath))
						{
							listBoxItems.Add(uri + " (cập nhật)");
						}
						else
						{
							listBoxItems.Add(uri + " (mới)");
						}
						curLog.Remove(curLog.Find(str => realPath.Equals(str)));
					}
					catch
					{
						lblStatus.Text = "Tải file từ máy chủ HTTP lỗi: " + uri;
					}
				}
			}
			catch
			{
				lblStatus.Text = "Kết nối máy chủ HTTP lỗi";
			}

			// Local file
			foreach (string path in curLog)
			{
				string dispPath = path.Replace("logs/", "");
				listBoxItems.Add(dispPath + " (nội bộ)");
			}

			// Display data
			lbFileList.Items.Clear();
			listBoxItems.Sort();
			lbFileList.DataSource = listBoxItems;

			// Load log
			lblStatus.Text = "Đang xử lý dữ liệu...";
			try
			{
				LogManager.LoadLog();
			}
			catch
			{
				lblStatus.Text = "Xử lý dữ liệu lỗi";
			}

			DateTime updatedDate = LogManager.GetUpdatedLog();
			TimeSpan diff = DateTime.Now - updatedDate;
			string strDate = updatedDate.ToString("HH:mm:ss dd/MM/yyyy");
			string strDiff = diff.Days == 0 ? string.Format("{0:00} giờ {1:00} phút {2:00} giây",
				diff.Hours, diff.Minutes, diff.Seconds) :
				string.Format("{0} ngày {1:00} giờ {2:00} phút {3:00} giây",
				(int)diff.TotalDays, diff.Hours, diff.Minutes, diff.Seconds);
			txtLogUpdateTime.Text = strDate;
			lblStatus.Text = "Dữ liệu cập nhật đến " + strDate + " (trễ " + strDiff + ")"; ;
			txtDiffTime.Text = strDiff;

			lbFileList.Visible = true;
			progUpdateData.IsRunning = false;

			updateBlockList();
			tabEnvironmentInit();
			cbDeviceHisStatisCompareInit();

			tabCompare.Enabled = tabEnvironment.Enabled = tabDeviceStatistic.Enabled = tabDeviceHistory.Enabled = tabBlockManager.Enabled = true;
		}

		private void btnAuthor_Click(object sender, EventArgs e)
		{
			new AboutForm().ShowDialog(this);
		}

		#endregion

		#region "Theme function"

		private void cbThemeInit()
		{
			foreach (string name in Enum.GetNames(typeof(eStyle)))
			{
				ComboBoxItem item = new ComboBoxItem();
				item.Text = name;
				cbTheme.Items.Add(item);
			}
			cbTheme.Text = styleManager.ManagerStyle.ToString();
			cpBaseColor.SymbolColor = cpBaseColor.SelectedColor = styleManager.MetroColorParameters.BaseColor;
			cpCanvasColor.SymbolColor = cpCanvasColor.SelectedColor = styleManager.MetroColorParameters.CanvasColor;
		}

		private void cbTheme_SelectedIndexChanged(object sender, EventArgs e)
		{
			styleManager.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), cbTheme.Text);
			cpBaseColor.SymbolColor = cpBaseColor.SelectedColor = styleManager.MetroColorParameters.BaseColor;
			cpCanvasColor.SymbolColor = cpCanvasColor.SelectedColor = styleManager.MetroColorParameters.CanvasColor;
			this.WindowState = FormWindowState.Normal;
			this.WindowState = FormWindowState.Maximized;
		}

		private void cpCanvasColor_SelectedColorChanged(object sender, EventArgs e)
		{
			MetroColorGeneratorParameters param = new MetroColorGeneratorParameters();
			cpCanvasColor.SymbolColor = param.CanvasColor = cpCanvasColor.SelectedColor;
			cpBaseColor.SymbolColor = param.BaseColor = styleManager.MetroColorParameters.BaseColor;
			styleManager.MetroColorParameters = param;
		}

		private void cpBaseColor_SelectedColorChanged(object sender, EventArgs e)
		{
			MetroColorGeneratorParameters param = new MetroColorGeneratorParameters();
			cpCanvasColor.SymbolColor = param.CanvasColor = styleManager.MetroColorParameters.CanvasColor;
			cpBaseColor.SymbolColor = param.BaseColor = cpBaseColor.SelectedColor;
			styleManager.MetroColorParameters = param;
		}

		#endregion\

		#region "Evironment function"

		private void tabEnvironmentInit()
		{
			DateTime minEnvironmentDT = DateTime.MaxValue;
			DateTime maxEnvironmentDT = DateTime.MinValue;
			foreach (LogRecord lrec in LogManager.LogEntryList)
			{
				ILogEnvironment rec = lrec as ILogEnvironment;
				if (rec != null)
				{
					if (rec.Time < minEnvironmentDT)
					{
						minEnvironmentDT = rec.Time;
					}
					if (rec.Time > maxEnvironmentDT)
					{
						maxEnvironmentDT = rec.Time;
					}
				}
			}
			dtEnvironmentBegin.Value = dtEnvironmentBegin.MinDate = dtEnvironmentEnd.MinDate = minEnvironmentDT;
			dtEnvironmentEnd.Value = dtEnvironmentBegin.MaxDate = dtEnvironmentEnd.MaxDate = maxEnvironmentDT;
		}

		private readonly Dictionary<byte, Color> clientTemperatureColor = new Dictionary<byte, Color>()
		{
			{1, Color.Red},
			{2, Color.Blue}
		};
		private void btnUpdateEvironment_Click(object sender, EventArgs e)
		{
			DateTime minEnvironmentDT = dtEnvironmentBegin.MinDate;
			DateTime maxEnvironmentDT = dtEnvironmentBegin.MaxDate;
			if (dtEnvironmentBegin.Value >= dtEnvironmentEnd.Value)
			{
				MessageBoxEx.Show(this, "<font size='18'><b>Ngày bắt đầu phải trước ngày kết thúc !</b></font>",
						"<font size='15'><b>Thông báo</b></font>", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dtEnvironmentBegin.Value = minEnvironmentDT;
				dtEnvironmentEnd.Value = maxEnvironmentDT;
			}
			else
			{
				if (dtEnvironmentBegin.Value < minEnvironmentDT)
				{
					dtEnvironmentBegin.Value = minEnvironmentDT;
				}
				if (dtEnvironmentEnd.Value > maxEnvironmentDT)
				{
					dtEnvironmentEnd.Value = maxEnvironmentDT;
				}
			}
			DateTime beginTime = dtEnvironmentBegin.Value;
			DateTime endTime = dtEnvironmentEnd.Value;

			double sum = 0;
			int avgCount = 0;
			Dictionary<byte, List<double>> dictData_X = new Dictionary<byte, List<double>>();
			Dictionary<byte, List<double>> dictData_Y = new Dictionary<byte, List<double>>();
			foreach (LogRecord lrec in LogManager.LogEntryList)
			{
				ILogEnvironment rec = lrec as ILogEnvironment;
				if (rec != null)
				{
					if (rec.Time < beginTime || rec.Time > endTime)
					{
						continue;
					}
					sum += rec.Temperature;
					avgCount++;

					List<double> list_X;
					if (!dictData_X.TryGetValue(rec.ClientID, out list_X))
					{
						list_X = new List<double>();
						dictData_X.Add(rec.ClientID, list_X);
					}
					List<double> list_Y;
					if (!dictData_Y.TryGetValue(rec.ClientID, out list_Y))
					{
						list_Y = new List<double>();
						dictData_Y.Add(rec.ClientID, list_Y);
					}
					list_X.Add(rec.Time.ToOADate());
					list_Y.Add(rec.Temperature);
				}
			}
			sum /= avgCount;
			txtAverageTemperature.Text = sum.ToString("F2") + "\u00B0C";

			GraphPane pane = graphEnvironment.GraphPane;
			pane.Title.Text = "Lịch sử môi trường";
			pane.YAxis.Title.Text = "Nhiệt độ (\u00B0C)";
			pane.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

			pane.XAxis.Type = AxisType.Date;
			pane.XAxis.Title.Text = "Thời gian";
			pane.XAxis.Scale.Format = "HH:mm dd/MM/yy";
			pane.XAxis.Scale.FontSpec.Size = 8;

			pane.CurveList.Clear();
			foreach (KeyValuePair<byte, List<double>> data in dictData_X)
			{
				LineItem curve = pane.AddCurve("Nhiệt độ mạch " + data.Key + " (\u00B0C)",
					data.Value.ToArray(), lowPassFilter(dictData_Y[data.Key].ToArray(), 40, 0.8),
					clientTemperatureColor[data.Key], SymbolType.None);
			}

			Graphics g = this.CreateGraphics();
			pane.YAxis.ResetAutoScale(pane, g);
			pane.Y2Axis.ResetAutoScale(pane, g);
			pane.XAxis.ResetAutoScale(pane, g);
			g.Dispose();
			pane.ZoomStack.Clear();
			pane.XAxis.Scale.Format = "HH:mm dd/MM/yy";

			graphEnvironment.AxisChange();
			graphEnvironment.Refresh();
		}

		private double[] lowPassFilter(double[] noisy, int range, double decay)
		{
			double[] clean = new double[noisy.Length];
			double[] coefficients = Coefficients(range, decay);

			double divisor = 0;
			for (int i = -range; i <= range; i++)
				divisor += coefficients[Math.Abs(i)];

			for (int i = range; i < clean.Length - range; i++)
			{
				double temp = 0;
				for (int j = -range; j <= range; j++)
					temp += noisy[i + j] * coefficients[Math.Abs(j)];
				clean[i] = temp / divisor;
			}

			double leadSum = 0;
			double trailSum = 0;
			int leadRef = range;
			int trailRef = clean.Length - range - 1;
			for (int i = 1; i <= range; i++)
			{
				leadSum += (clean[leadRef] - clean[leadRef + i]) / i;
				trailSum += (clean[trailRef] - clean[trailRef - i]) / i;
			}
			double leadSlope = leadSum / range;
			double trailSlope = trailSum / range;

			for (int i = 1; i <= range; i++)
			{
				clean[leadRef - i] = clean[leadRef] + leadSlope * i;
				clean[trailRef + i] = clean[trailRef] + trailSlope * i;
			}
			return clean;
		}

		private double[] Coefficients(int range, double decay)
		{
			double[] coefficients = new double[range + 1];
			for (int i = 0; i <= range; i++)
				coefficients[i] = Math.Pow(decay, i);
			return coefficients;
		}

		#endregion

	}
}
