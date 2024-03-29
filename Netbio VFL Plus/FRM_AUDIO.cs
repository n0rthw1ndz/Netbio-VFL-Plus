﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Netbio_VFL_Plus
{
    public partial class FRM_AUDIO : Form
    {
        FRM_DEBUG SND_DEBUG = new FRM_DEBUG();

        byte Chmod = 0;

        public FRM_AUDIO()
        {
            InitializeComponent();
        }

        private void scanSNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();

            OFD.Filter = ".SND|*.snd|.SNP|*.snp|All Files (*.*)|*.*"; ;
            OFD.FilterIndex = 1;



            OFD.ShowDialog();

            LIB_AUDIO.SND_PARSE(OFD.FileName, LV_AUDIO, LBL_TCOUNT, SND_DEBUG.DEBUG_LOG);

            LBL_FILE.Text = OFD.FileName;


        }

        private void LV_AUDIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int i = LV_AUDIO.SelectedIndices[0];
                int sel_offset = int.Parse(LV_AUDIO.Items[i].SubItems[1].Text);
                int next_offset = int.Parse(LV_AUDIO.Items[i + 1].SubItems[1].Text);
                int freq = int.Parse(LV_AUDIO.Items[i].SubItems[2].Text);
                int loop = int.Parse(LV_AUDIO.Items[i].SubItems[3].Text);

                //  int t_sz = int.Parse(LV_AUDIO.Items[i].SubItems[5].Text);

                int t_sz = next_offset - sel_offset;
                // MessageBox.Show("SEL OFF: "+ sel_offset.ToString("X") + "SZ: " + t_sz.ToString("X"));
                LBL_BLK.Text = "BLK SZ: " + t_sz.ToString("X");
                LBL_OFF.Text = "ADDRESS: " + sel_offset.ToString("X");



                if (RDT_IO.SNP_FLAG == 0)
                {
                    LIB_AUDIO.PLAY_LV_CLIP(LBL_FILE.Text, sel_offset, t_sz, freq, Chmod, TB_VOL.Value, loop, LBL_AD_STATUS, PG_SOUND);
                    Thread.Sleep(700);
                    LV_AUDIO.SelectedItems.Clear();
                }

                if (RDT_IO.SNP_FLAG == 1)
                {
                    LIB_AUDIO.PLAY_LV_CLIP(RDT_IO.FP_DISC, sel_offset, t_sz, freq, Chmod, TB_VOL.Value, loop, LBL_AD_STATUS, PG_SOUND);
                    Thread.Sleep(700);
                    LV_AUDIO.SelectedItems.Clear();
                }
            }
            catch (ArgumentException AOR) 
            {


            }
        }



        private void RB_MONO_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_MONO.Checked) 
            {
                Chmod = 1;
            }
        }

        private void RB_STEREO_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_STEREO.Checked) 
            {
                Chmod = 0;
            }
        }

        private void SND_TIMER_Tick(object sender, EventArgs e)
        {

        }

        private void BTN_DEBUG_Click(object sender, EventArgs e)
        {
          
            SND_DEBUG.ShowDialog();

        }

        private void TB_VOL_Scroll(object sender, EventArgs e)
        {
            LBL_VOL.Text = "Volume: " + TB_VOL.Value.ToString();
        }

        private void BTN_PLAY_ALL_Click(object sender, EventArgs e)
        {
            // ATTEMPT TO PLAY ALL CLIPS IN SUCCESSION
            string path = string.Empty;



            // CHECK FORM RELATIVITY
            if (RDT_IO.SNP_FLAG > 0)
            {
                path = RDT_IO.FP_DISC;
            }
            if (RDT_IO.SNP_FLAG == 0)
            {
                path = LBL_FILE.Text;
            }

        //    MessageBox.Show(LIB_AUDIO.CLIP_COUNT.ToString());


            LIB_AUDIO.PLAY_ALL_CLIPS(path, LV_AUDIO, LIB_AUDIO.CLIP_COUNT, Chmod, TB_VOL.Value, LBL_AD_STATUS, PG_SOUND);
        }
    }
}
