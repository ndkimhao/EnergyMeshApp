using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnergyMeshApp
{

	public sealed class DeviceListBox : ListBox
	{
		public ImageList ImageList { get; set; }

		public DeviceListBox()
		{
			DrawMode = DrawMode.OwnerDrawFixed;
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.DrawFocusRectangle();
			if (e.Index >= 0 && e.Index < Items.Count)
			{
				Device dev = (Device)Items[e.Index];
				Image image = ImageList.Images[dev.ImageKey];
				image = ResizeImage(image, 48, 48);

				Rectangle r = e.Bounds;
				r.Size = image.Size;
				r.X += 2;
				r.Y += (e.Bounds.Height - r.Height) / 2;
				e.Graphics.DrawImageUnscaled(image, r);

				r = e.Bounds;
				r.X += image.Width + 2;
				r.Width -= image.Width + 2;
				using (StringFormat sf = new StringFormat())
				{
					sf.LineAlignment = StringAlignment.Center;
					e.Graphics.DrawString(dev.Name, Font, new SolidBrush(ForeColor), r, sf);
				}
			}
			base.OnDrawItem(e);
		}

		private static Bitmap ResizeImage(Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}
	}

	public sealed class DeviceComboBox : ComboBox
	{
		public ImageList ImageList { get; set; }

		public DeviceComboBox()
		{
			DrawMode = DrawMode.OwnerDrawFixed;
			DropDownStyle = ComboBoxStyle.DropDownList;
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.DrawFocusRectangle();
			if (e.Index >= 0 && e.Index < Items.Count)
			{
				Device dev = (Device)Items[e.Index];
				Image image = ImageList.Images[dev.ImageKey];
				image = ResizeImage(image, 48, 48);

				Rectangle r = e.Bounds;
				r.Size = image.Size;
				r.X += 2;
				r.Y += (e.Bounds.Height - r.Height) / 2;
				e.Graphics.DrawImageUnscaled(image, r);

				r = e.Bounds;
				r.X += image.Width + 2;
				r.Width -= image.Width + 2;
				using (StringFormat sf = new StringFormat())
				{
					sf.LineAlignment = StringAlignment.Center;
					e.Graphics.DrawString(dev.Name, Font, new SolidBrush(ForeColor), r, sf);
				}
			}
			base.OnDrawItem(e);
		}

		private static Bitmap ResizeImage(Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}
	}

	class MyGridImageEditControl : GridImageEditControl
	{
		public MyGridImageEditControl(ImageList imageList, ImageSizeMode sizeMode)
		{
			ImageList = imageList;
			ImageSizeMode = sizeMode;
		}
	}

	class GridImageComboDevice : GridComboBoxExEditControl
	{
		private ImageList _ImageList;
		private List<Device> _DeviceList;
		private Font StrikeoutFont;

		public GridImageComboDevice(ImageList imageList, List<Device> deviceList, int itemHeight)
		{
			_ImageList = imageList;
			_DeviceList = deviceList;

			DisableInternalDrawing = true;
			DropDownStyle = ComboBoxStyle.DropDownList;
			ItemHeight = itemHeight;

			Items.Add(-1);
			Items.Add(-2);
			foreach (Device dev in _DeviceList)
			{
				if (!dev.IsDeleted)
				{
					Items.Add(dev.ID);
				}
			}
			foreach (Device dev in _DeviceList)
			{
				if (dev.IsDeleted)
				{
					Items.Add(dev.ID);
				}
			}
			StrikeoutFont = new Font(Font, FontStyle.Strikeout | FontStyle.Italic);
			DrawItem += GridImageComboDrawItem;
		}

		public override void CellRender(Graphics g)
		{
			Rectangle r = EditorCell.Bounds;
			r.X += 4;
			r.Width -= 4;
			RenderItem(g, r, int.Parse(Text));
		}

		void GridImageComboDrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				e.DrawBackground();
				RenderItem(e.Graphics, e.Bounds, e.Index == 0 ? -1 : e.Index == 1 ? -2 : getDevice(e.Index - 2).ID);
			}
		}

		private Device getDevice(int index)
		{
			int count = -1;
			foreach (Device dev in _DeviceList)
			{
				if (!dev.IsDeleted)
				{
					count++;
					if (count == index)
					{
						return dev;
					}
				}
			}
			foreach (Device dev in _DeviceList)
			{
				if (dev.IsDeleted)
				{
					count++;
					if (count == index)
					{
						return dev;
					}
				}
			}
			return null;
		}

		private void RenderItem(Graphics g, Rectangle bounds, int deviceID)
		{
			Device dev = _DeviceList.Find(d => d.ID == deviceID);
			Image image = dev == null ? _ImageList.Images[0] : _ImageList.Images[dev.ImageKey];

			Rectangle r = bounds;
			if (dev != null)
			{
				r.Size = image.Size;
				r.X += 2;
				r.Y += (bounds.Height - r.Height) / 2;
				g.DrawImageUnscaled(image, r);
			}

			r = bounds;
			r.X += image.Width + 2;
			r.Width -= image.Width + 2;
			using (StringFormat sf = new StringFormat())
			{
				sf.LineAlignment = StringAlignment.Center;
				if (dev == null)
				{
					g.DrawString(deviceID == -1 ? "(Chưa chọn)" : "(Trống)", Font, new SolidBrush(ForeColor), r, sf);
				}
				else
				{
					g.DrawString(dev.Name, dev.IsDeleted ? StrikeoutFont : Font, new SolidBrush(ForeColor), r, sf);
				}
			}
		}
	}

	class GridImageCombo : GridComboBoxExEditControl
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
				RenderItem(e.Graphics, e.Bounds, _ImageList.Images.Keys[e.Index]);
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
					g.DrawString(_NameDict[key], Font, new SolidBrush(ForeColor), r, sf);
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
