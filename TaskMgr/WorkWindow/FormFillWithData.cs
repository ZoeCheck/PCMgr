﻿using PCMgr.Lanuages;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PCMgr.WorkWindow
{
    public partial class FormFillWithData : Form
    {
        public FormFillWithData(string path)
        {
            InitializeComponent();
            labelFilePath.Text = path;
            file = path;
        }

        private string file = "";

        [DllImport(NativeMethods.COREDLLNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private extern static bool MFM_FillData(string szFileDir, bool force, uint fileSize);
        [DllImport(NativeMethods.COREDLLNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private extern static bool MFM_EmeptyFile(string szFileDir, bool force);

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(radioButtonZeroData.Checked)
            {
                if (numericUpDownFileSize.Value == 0)
                    MessageBox.Show(LanuageMgr.GetStr("FillFileNeedSize"));
                else
                {
                    if(MFM_FillData(file, checkBoxForce.Checked, Convert.ToUInt32(numericUpDownFileSize.Value) * 1024))
                        MessageBox.Show(LanuageMgr.GetStr("FillFileSuccess"));
                    else MessageBox.Show(LanuageMgr.GetStr("FillFileFailed"));
                }
            }
            else if(radioButtonEmepty.Checked)
            {
                if(MFM_EmeptyFile(file, checkBoxForce.Checked))
                    MessageBox.Show(LanuageMgr.GetStr("FillFileSuccess"));
                else MessageBox.Show(LanuageMgr.GetStr("FillFileFailed"));
            }
        }
    }
}
