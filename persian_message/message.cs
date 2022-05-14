using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace persian_message
{
    public partial class message : Form
    {
        public message()
        {
            InitializeComponent();
        }
        public enum persianDialogResult
        {
            Yes,No,Ok,Cancel,Abort,Retry,Ignore
        }
        public enum persianMessageBoxButton
        {
            AbortRetryIgnore,Ok,OkCancel,RetryCancel,YesNo,YesNoCancel
        }
        public enum persianMessageBoxTheme
        {
            ghostWhite, silver, Gray
        }
        public enum persianMessageBoxIcon
        {
            Warning,Information, Error,Question

        }
        DialogResult _persianDialogResult;
        private DialogResult persianResult
        {
            get { return _persianDialogResult; }
            set { _persianDialogResult = value; }
        }
        private Image GetIcon(persianMessageBoxIcon messageIcon)
        {
            switch (messageIcon)
            {
                case persianMessageBoxIcon.Information:
                    return Properties.Resources.info;
                case persianMessageBoxIcon.Error:
                    return Properties.Resources.eror;
                case persianMessageBoxIcon.Question:

                    return Properties.Resources.question;
                case persianMessageBoxIcon.Warning:

                    return Properties.Resources.warn;
            }
            
                    return Properties.Resources.info;
        }
        private void SetButton(persianMessageBoxButton MessageButton)
        {
            GroupBox1.Top = label1.Height + 20;
            GroupBox1.Left = label1.Left;
           
            //GroupBox1.Width = label1.Width;
            
            this.Left = GroupBox1.Width;

            switch (MessageButton)
            {
                case persianMessageBoxButton.AbortRetryIgnore:
                    btncancel.Visible = false;
                    btnno.Visible = false;
                    btnok.Visible = false;
                    btnyes.Visible = false;
                    btnignore.Visible = true;
                    btnretry.Visible = true;
                    btnabort.Visible = true;
                    

                    btnabort.Left = GroupBox1.Width - 336;
                    btnretry.Left = GroupBox1.Width - 226;
                    btnignore.Left = GroupBox1.Width - 116;
                    break;
                case persianMessageBoxButton.Ok:
                    btncancel.Visible = false;
                    btnno.Visible = false;
                    btnok.Visible = true;
                    btnyes.Visible = false;
                    btnretry.Visible = false;
                    btnabort.Visible = false;
                    btnignore.Visible = false;

                    
                   btnok.Left = GroupBox1.Width -226;
                    
                    break;
                case persianMessageBoxButton.OkCancel:
                    btncancel.Visible = true;
                    btnno.Visible = false;
                    btnok.Visible = true;
                    btnyes.Visible = false;
                    btnretry.Visible = false;
                    btnabort.Visible = false;
                    btnignore.Visible = false;


                    btnok.Left = GroupBox1.Width -158;
                    btncancel.Left = GroupBox1.Width - 280;
                    break;
                case persianMessageBoxButton.RetryCancel:
                    btncancel.Visible = true;
                    btnno.Visible = false;
                    btnok.Visible = false;
                    btnyes.Visible = false;
                    btnretry.Visible = true;
                    btnabort.Visible = false;
                    btnignore.Visible = false;


                    btnretry.Left = GroupBox1.Width - 116;
                    btncancel.Left = GroupBox1.Width - 336;
                    break;
                case persianMessageBoxButton.YesNo:
                    btncancel.Visible = false;
                    btnno.Visible = true;
                    btnok.Visible = false;
                    btnyes.Visible = true;
                    btnretry.Visible = false;
                    btnabort.Visible = false;
                    btnignore.Visible = false;
                   btnyes.Left = GroupBox1.Width - 158;
                   btnno.Left = GroupBox1.Width - 280;
                    break;
                case persianMessageBoxButton.YesNoCancel:
                    btncancel.Visible = true;
                    btnno.Visible = true;
                    btnok.Visible = false;
                    btnyes.Visible = true;
                    btnretry.Visible = false;
                    btnabort.Visible = false;
                    btnignore.Visible = false;


                    btnyes.Left = GroupBox1.Width - 116;
                    btnno.Left = GroupBox1.Width - 226;
                    btncancel.Left = GroupBox1.Width - 336;
                    break;



            }
        }

        private void SetTheme(persianMessageBoxTheme MessageTheme)
        {
            switch (MessageTheme)
            {
                case persianMessageBoxTheme.silver:
                    this.BackColor = Color.FromArgb(211, 220, 223);
                    
                    break;
                case persianMessageBoxTheme.Gray:
                    this.BackColor = Color.Gainsboro;
                    break;
                case persianMessageBoxTheme.ghostWhite:
                    this.BackColor = Color.GhostWhite;
                    break;
            }
        }


        private void getsound(persianMessageBoxIcon Icon)
        {
            System.Media.SoundPlayer player= new System.Media.SoundPlayer();
            switch (Icon)
            {
                case persianMessageBoxIcon.Error:
                    player.Stream = Properties.Resources.sound_warning;
                    player.Play();
                    break;

                case persianMessageBoxIcon.Warning:
                    player.Stream = Properties.Resources.Message;
                    player.Play();
                    break;

                case persianMessageBoxIcon.Question:
                    player.Stream = Properties.Resources.sound_question;
                    player.Play();
                    break;
                case persianMessageBoxIcon.Information:
                    player.Stream = Properties.Resources.sound_information;
                    player.Play();
                    break;
            }
        }

        public static DialogResult show(string Message)
        {
            message bax = new message();
            bax.Text = " ";
            bax.label1.Text = Message;
            bax.SetButton(persianMessageBoxButton.Ok);
            bax.SetTheme(persianMessageBoxTheme.Gray);
            bax.ShowDialog();
            return bax._persianDialogResult;
        }
        public static DialogResult show(string Message,string title)
        {
            message bax = new message();
            bax.Text = title;
            bax.label1.Text = Message;
            bax.SetButton(persianMessageBoxButton.Ok);
            bax.SetTheme(persianMessageBoxTheme.Gray);
            bax.ShowDialog();
            return bax._persianDialogResult;
        }
        public static DialogResult show(string Message, string title,persianMessageBoxButton messageButton)
        {
            message bax = new message();
            bax.Text = title;
            bax.label1.Text = Message;
            bax.SetButton(messageButton);
            bax.SetTheme(persianMessageBoxTheme.Gray);
            bax.ShowDialog();
            return bax._persianDialogResult;
        }
        public static DialogResult show(string Message, string title, persianMessageBoxButton messageButton,persianMessageBoxIcon messageIcon)
        {
            message bax = new message();
            bax.Text = title;
            bax.label1.Text = Message;
            bax.SetButton(messageButton);
            bax.pictureBox1.Image = bax.GetIcon(messageIcon);
            bax.getsound(messageIcon);
            bax.SetTheme(persianMessageBoxTheme.Gray);
            bax.ShowDialog();
            return bax._persianDialogResult;
        }
        public static DialogResult show(string Message, string title, persianMessageBoxButton messageButton, persianMessageBoxIcon messageIcon,persianMessageBoxTheme theme)
        {
            message bax = new message();
            bax.Text = title;
            bax.label1.Text = Message;
            bax.SetButton(messageButton);
            bax.pictureBox1.Image = bax.GetIcon(messageIcon);
            bax.getsound(messageIcon);
            bax.SetTheme(theme);
            bax.ShowDialog();
            return bax._persianDialogResult;
        }
        private void message_Load(object sender, EventArgs e)
        {

        }

        private void btnyes_Click(object sender, EventArgs e)
        {
            persianResult = DialogResult.Yes;
            this.Close();
        }

        private void btnretry_Click(object sender, EventArgs e)
        {
            persianResult = DialogResult.Retry;
            this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            persianResult = DialogResult.OK;
            this.Close();
        }

        private void btnno_Click(object sender, EventArgs e)
        {
            persianResult = DialogResult.No;
            this.Close();
        }

        private void btnabort_Click(object sender, EventArgs e)
        {
            persianResult = DialogResult.Abort;
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            persianResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnignore_Click(object sender, EventArgs e)
        {
            persianResult = DialogResult.Ignore;
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
