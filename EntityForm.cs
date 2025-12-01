using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace KursYonetimSistemi
{
    public partial class EntityForm<T> : Form where T : class, new()
    {
        public T Entity { get; private set; }

        public EntityForm(T entity)
        {
            Entity = entity ?? new T();
            InitializeComponent();
            this.Text = $"{((entity == null) ? "Yeni" : "Düzenle")}";
            GenerateControls();
        }

        private void GenerateControls()
        {
            var properties = typeof(T).GetProperties();
            int yPos = 10;

            foreach (var prop in properties)
            {
                if (prop.Name == "Id" || prop.Name.Contains("Ids")) continue;

                var lbl = new Label { Text = prop.Name, Location = new Point(10, yPos), AutoSize = true };
                this.Controls.Add(lbl);

                Control input = null;
                if (prop.PropertyType == typeof(string) || prop.PropertyType == typeof(int))
                {
                    input = new TextBox { Name = $"txt{prop.Name}", Location = new Point(150, yPos), Width = 200 };
                    input.Text = prop.GetValue(Entity)?.ToString() ?? "";
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    input = new CheckBox { Name = $"chk{prop.Name}", Location = new Point(150, yPos) };
                    (input as CheckBox).Checked = (bool)(prop.GetValue(Entity) ?? false);
                }
                else if (prop.PropertyType == typeof(DateTime))
                {
                    input = new DateTimePicker { Name = $"dtp{prop.Name}", Location = new Point(150, yPos) };
                    var val = prop.GetValue(Entity);
                    if (val != null && ((DateTime)val) > (new DateTime(1800,1,1)) )
                        (input as DateTimePicker).Value = (DateTime)val;
                }
                 else if (prop.PropertyType == typeof(TimeSpan))
                {
                    input = new DateTimePicker { Name = $"dtp{prop.Name}", Location = new Point(150, yPos), Format = DateTimePickerFormat.Time, ShowUpDown = true };
                    var val = prop.GetValue(Entity);
                    if(val != null)
                        (input as DateTimePicker).Value = DateTime.Today + (TimeSpan)val;
                }

                if (input != null)
                {
                    this.Controls.Add(input);
                    yPos += 30;
                }
            }

            var btnSave = new Button { Text = "Kaydet", Location = new Point(150, yPos), DialogResult = DialogResult.OK };
            btnSave.Click += (s, e) => SaveChanges();
            this.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "İptal", Location = new Point(240, yPos), DialogResult = DialogResult.Cancel };
            this.Controls.Add(btnCancel);

            this.Height = yPos + 80;
            this.Width = 400;
        }

        private void SaveChanges()
        {
            try
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    var input = this.Controls.Find($"txt{prop.Name}", true).FirstOrDefault() ??
                                this.Controls.Find($"chk{prop.Name}", true).FirstOrDefault() ??
                                this.Controls.Find($"dtp{prop.Name}", true).FirstOrDefault();

                    if (input is TextBox txt)
                    {
                        if (prop.PropertyType == typeof(int))
                        {
                            if (int.TryParse(txt.Text, out int val))
                            {
                                prop.SetValue(Entity, val);
                            }
                            else
                            {
                                throw new FormatException($"{prop.Name} alanı sayısal bir değer olmalıdır.");
                            }
                        }
                        else
                        {
                             prop.SetValue(Entity, txt.Text);
                        }
                    }
                    if (input is CheckBox chk) prop.SetValue(Entity, chk.Checked);
                    if (input is DateTimePicker dtp)
                    {
                        if (prop.PropertyType == typeof(DateTime))
                            prop.SetValue(Entity, dtp.Value);
                        else if (prop.PropertyType == typeof(TimeSpan))
                            prop.SetValue(Entity, dtp.Value.TimeOfDay);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Geçersiz Değer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None; // prevent form from closing
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "EntityForm";
            this.ResumeLayout(false);
        }
    }
}
