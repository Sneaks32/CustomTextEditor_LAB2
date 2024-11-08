using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CustomTextEditorControl
{
	public class CustomTextEditor : UserControl
	{
		private TextBox textBox;
		private TrackBar fontSizeTrackBar;
		private ComboBox fontComboBox;

		public CustomTextEditor()
		{
			InitializeComponent();
			InitializeEvents();
		}

		private void InitializeComponent()
		{
			// Инициализация TextBox
			textBox = new TextBox
			{
				Multiline = true,
				Dock = DockStyle.Fill,
				Font = new Font("Arial", 12)
			};

			// Инициализация TrackBar для размера шрифта
			fontSizeTrackBar = new TrackBar
			{
				Minimum = 8,
				Maximum = 48,
				Value = 12,
				Dock = DockStyle.Top
			};

			// Инициализация ComboBox для выбора шрифта
			fontComboBox = new ComboBox
			{
				Dock = DockStyle.Top,
				DropDownStyle = ComboBoxStyle.DropDownList
			};

			// Заполнение ComboBox списком шрифтов
			foreach (FontFamily font in FontFamily.Families)
			{
				fontComboBox.Items.Add(font.Name);
			}
			fontComboBox.SelectedItem = "Arial"; // Устанавливаем начальный шрифт

			// Добавляем элементы в контрол
			Controls.Add(textBox);
			Controls.Add(fontSizeTrackBar);
			Controls.Add(fontComboBox);
		}

		private void InitializeEvents()
		{
			fontSizeTrackBar.ValueChanged += (sender, e) => UpdateFont();
			fontComboBox.SelectedIndexChanged += (sender, e) => UpdateFont();
		}

		private void UpdateFont()
		{
			if (fontComboBox.SelectedItem != null)
			{
				string fontName = fontComboBox.SelectedItem.ToString();
				float fontSize = fontSizeTrackBar.Value;
				textBox.Font = new Font(fontName, fontSize);
			}
		}

		// Свойства для доступа к шрифту и размеру шрифта извне
		public string SelectedFont
		{
			get => fontComboBox.SelectedItem?.ToString();
			set
			{
				if (FontFamily.Families.Any(f => f.Name == value))
				{
					fontComboBox.SelectedItem = value;
				}
			}
		}

		public float FontSize
		{
			get => textBox.Font.Size;
			set
			{
				if (value >= fontSizeTrackBar.Minimum && value <= fontSizeTrackBar.Maximum)
				{
					fontSizeTrackBar.Value = (int)value;
				}
			}
		}

		// Событие для передачи текста в основное приложение
		public event EventHandler TextChangedEvent
		{
			add => textBox.TextChanged += value;
			remove => textBox.TextChanged -= value;
		}

		// Метод для получения текста
		public string GetText() => textBox.Text;

		// Метод для установки текста
		public void SetText(string text) => textBox.Text = text;
	}
}

