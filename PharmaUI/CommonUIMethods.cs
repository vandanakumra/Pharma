using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI
{
    public static class ExtensionMethods
    {
        public static PharmaBusinessObjects.Master.UserMaster LoggedInUser { get; set; }
        public static string FontFamily = "Microsoft Sans Serif";

        
        public static int FontSize = 9;
        public static Panel MainPanel;

        public const string MatchEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                                + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

        public static List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }

            return list;
        }

        

        public static List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }


        public static void DisableAllTextBoxAndComboBox(Control frm, Control ctrlToEnable = null)
        {
            foreach (Control c in frm.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    DisableAllTextBoxAndComboBox(c);
                }
                else
                {
                    if (c is TextBox)
                    {
                        TextBox tb = (TextBox)c;

                        if (!(tb.Enabled == false || tb.ReadOnly == true))
                        {
                            c.BackColor = Color.White;
                        }
                    }

                    else if(c is ComboBox)
                    {
                        if (c.Enabled == true)
                        {
                            c.BackColor = Color.White;
                        }
                    }
                }
            }

            if (ctrlToEnable != null)
            {
                ctrlToEnable.BackColor = Color.LightPink;
               
            }
        }

        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).First();
        }

        public static double? SafeConversionDouble(string inputVal)
        {
            double outputVal;
            if (!double.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }

        public static Decimal ? SafeConversionDecimal(string inputVal)
        {
            decimal outputVal;
            if (!decimal.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }

        internal static void FormLoad(Form form, string lblText)
        {

            List<Control> allControls = ExtensionMethods.GetAllControls(form);
            allControls.ForEach(k => { k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize);  });

            Panel panel1 = new Panel();
            panel1.Location = new Point(0, 0);
            panel1.BackColor = Color.MidnightBlue;
            panel1.Width = form.Width;
            panel1.Height = 50;
            panel1.Dock = DockStyle.Fill;
            panel1.Margin = new Padding(3, 3, 3, 3);
            panel1.Padding = new Padding(3, 3, 3, 3);
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);

            Label lbl = new Label();
            lbl.Width = (int)(panel1.Width);
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;
            lbl.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, 14, FontStyle.Bold);
            lbl.Text = lblText;
            lbl.ForeColor =  Color.White;
            panel1.Controls.Add(lbl);
            
            form.Controls.Add(panel1);
        }

        internal static void HomeFormLoad(Form form, string lblText)
        {

            List<Control> allControls = ExtensionMethods.GetAllControls(form);
            allControls.ForEach(k => { if (k.Name != "lblHmHeading" && k.GetType() != typeof(GroupBox)) { k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize); } });

            //Panel panel1 = new Panel();
            //panel1.Location = new Point(0, 0);
            //panel1.BackColor = Color.White;
            //panel1.Width = form.Width;
            //panel1.Height = 50;
            //panel1.Dock = DockStyle.Fill;
            //panel1.Margin = new Padding(3, 3, 3, 3);
            //panel1.Padding = new Padding(3, 3, 3, 3);
            //panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //panel1.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);

            //Label lbl = new Label();
            //lbl.Width = (int)(panel1.Width * 0.5);
            //lbl.Dock = DockStyle.Fill;
            //lbl.Anchor = AnchorStyles.Left;
            //lbl.TextAlign = ContentAlignment.MiddleLeft;
            //lbl.Top = 10;
            //lbl.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, 14, FontStyle.Bold);
            //lbl.Text = lblText;
            //lbl.ForeColor = Color.MidnightBlue;
            //panel1.Controls.Add(lbl);

            Panel panel1 = new Panel();
            panel1.Location = new Point(0, 0);
            panel1.BackColor = Color.MidnightBlue;
            panel1.Width = form.Width;
            panel1.Height = 50;
            panel1.Dock = DockStyle.Fill;
            panel1.Margin = new Padding(3, 3, 3, 3);
            panel1.Padding = new Padding(3, 3, 3, 3);
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);

            Label lbl = new Label();
            lbl.Width = (int)(panel1.Width);
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;
            lbl.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, 14, FontStyle.Bold);
            lbl.Text = lblText;
            lbl.ForeColor = Color.White;
            panel1.Controls.Add(lbl);

            form.Controls.Add(panel1);
        }

        public static void AddFormToPanel(Form frm, Panel pnl)
        {
            foreach (Form control in pnl.Controls)
            {
                pnl.Controls.Remove(control);
            }
           
            pnl.Controls.Add(frm);
        }

        public static void AddChildFormToPanel(Control parentForm, Control childFrm, Panel pnl)
        {
            pnl.Controls[parentForm.Name].Visible = false;

            pnl.Controls.Add(childFrm);
        }

        public static void RemoveChildFormToPanel(Control parentForm, Control childFrm, Panel pnl)
        {
            pnl.Controls.Remove(childFrm);
            pnl.Controls[parentForm.Name].Visible = true;
        }

        public static void SetFormProperties(Form frm)
        {
           
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ControlBox = false;
            frm.Text = "";
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.ShowIcon = false;
            frm.Dock = DockStyle.Fill;
            frm.AutoSize = false;
            frm.AutoSizeMode = AutoSizeMode.GrowOnly;
            
           
        }

        //public static void SetChildFormProperties(Form frm)
        //{
        //    frm.FormBorderStyle = FormBorderStyle.FixedSingle;
        //    frm.ControlBox = false;
        //    frm.Text = "";           
        //    frm.ShowIcon = false;
        //    frm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        //    frm.StartPosition = FormStartPosition.CenterScreen;

        //}

        public static int? SafeConversionInt(string inputVal)
        {
            int outputVal;

            if (!int.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }

        public static bool IsValidEmail(string emailaddress)
        {     
            if (emailaddress != null) return System.Text.RegularExpressions.Regex.IsMatch(emailaddress, MatchEmailPattern);
            else return false;
        }
       
    }
}
