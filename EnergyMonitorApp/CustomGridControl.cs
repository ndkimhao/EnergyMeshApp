using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnergyMonitorApp
{
	class MyGridImageEditControl : GridImageEditControl
	{
		public MyGridImageEditControl(ImageList imageList, ImageSizeMode sizeMode)
		{
			ImageList = imageList;
			ImageSizeMode = sizeMode;
		}
	}

	public class GridImageCombo : GridComboBoxExEditControl
	{
		private ImageList _ImageList;
		private Dictionary<string, string> _NameDict;

		public GridImageCombo(ImageList imageList, Dictionary<string, string> nameDict, int itemHeight)
		{
			_ImageList = imageList;
			_NameDict = nameDict;

			DisableInternalDrawing = true;
			DropDownStyle = ComboBoxStyle.DropDownList;
			ItemHeight = itemHeight;

			for (int i = 0; i < imageList.Images.Count; i++)
				Items.Add(imageList.Images.Keys[i]);

			DrawItem += GridImageComboDrawItem;
		}

		public override void CellRender(Graphics g)
		{
			Rectangle r = EditorCell.Bounds;
			r.X += 4;
			r.Width -= 4;

			RenderItem(g, r, Text);
		}

		void GridImageComboDrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				e.DrawBackground();

				RenderItem(e.Graphics, e.Bounds,
					_ImageList.Images.Keys[e.Index]);
			}
		}

		private void RenderItem(Graphics g, Rectangle bounds, string key)
		{
			Image image = _ImageList.Images[key];

			if (image != null)
			{
				Rectangle r = bounds;
				r.Size = image.Size;
				r.X += 2;
				r.Y += (bounds.Height - r.Height) / 2;

				g.DrawImageUnscaled(image, r);

				r = bounds;
				r.X += image.Width + 2;
				r.Width -= image.Width + 2;

				using (StringFormat sf = new StringFormat())
				{
					sf.LineAlignment = StringAlignment.Center;

					g.DrawString(_NameDict[key], Font, Brushes.Black, r, sf);
				}
			}
		}
	}

	public enum RadialAction { Accept, Delete }
	public class MyGridRadialMenuEditControl : GridRadialMenuEditControl
	{
		public MyGridRadialMenuEditControl()
		{
			SetRadialMenu();
		}

		#region SetRadialMenu

		private void SetRadialMenu()
		{
			Symbol = "\uf040";
			SymbolSize = 14;
			Diameter = 175;

			RadialMenuItem item;

			item = new RadialMenuItem();
			item.Tag = RadialAction.Accept;
			item.Text = "Chấp nhận";
			item.Symbol = "\uf00c";
			Items.Add(item);

			item = new RadialMenuItem();
			Items.Add(item);

			item = new RadialMenuItem();
			item.Tag = RadialAction.Delete;
			item.Text = "Xóa";
			item.Symbol = "\uf00d";
			Items.Add(item);
		}

		#endregion

		#region InitializeContext

		public override void InitializeContext(GridCell cell, CellVisualStyle style)
		{
			base.InitializeContext(cell, style);

			if (style != null)
			{
				Symbol = "\uf040";
				Colors.RadialMenuButtonBorder = Color.Green;
			}
		}

		#endregion
	}
}
