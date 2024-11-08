using System;
using System.Windows.Forms;
using CustomTextEditorControl; // Пространство имен для вашей библиотеки

namespace TextEditorDemo
{
	public partial class Form1 : Form
	{
		private CustomTextEditor customTextEditor;

		public Form1()
		{
			InitializeComponent();
			InitializeCustomTextEditor();
		}

		private void InitializeCustomTextEditor()
		{
			customTextEditor = new CustomTextEditor
			{
				Dock = DockStyle.Fill
			};

			// Подписываемся на событие изменения текста
			customTextEditor.TextChangedEvent += CustomTextEditor_TextChanged;

			// Добавляем элемент управления на форму
			Controls.Add(customTextEditor);
		}

		// Обработчик события изменения текста
		private void CustomTextEditor_TextChanged(object sender, EventArgs e)
		{
			Text = "Текущий текст: " + customTextEditor.GetText();
		}

		// Метод для передачи данных в контрол
		private void SetSampleText()
		{
			customTextEditor.SetText("Пример текста");
			customTextEditor.SelectedFont = "Calibri";
			customTextEditor.FontSize = 14;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			SetSampleText();
		}
	}
}

