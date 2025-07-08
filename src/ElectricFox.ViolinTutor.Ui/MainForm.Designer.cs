using System.Windows.Forms;

namespace ElectricFox.ViolinTutor.Ui
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            splitContainer1 = new SplitContainer();
            violinLayout = new PictureBox();
            staveBox = new PictureBox();
            tempoSlider = new TrackBar();
            panel1 = new Panel();
            newLineButton = new Button();
            restSisteenth = new Button();
            restEighth = new Button();
            restQuarter = new Button();
            restHalf = new Button();
            restWhole = new Button();
            timSignatureButton = new Button();
            stopButton = new Button();
            playButton = new Button();
            deleteButton = new Button();
            keyLabel = new Label();
            keyDropDown = new ComboBox();
            semiquaverButton = new Button();
            quaverButton = new Button();
            crotchetButton = new Button();
            minimButton = new Button();
            semibreveButton = new Button();
            repeatEndButton = new Button();
            repeatStartButton = new Button();
            barButton = new Button();
            saveButton = new Button();
            openButton = new Button();
            newButton = new Button();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)violinLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)staveBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tempoSlider).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 54);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(violinLayout);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(staveBox);
            splitContainer1.Size = new Size(1420, 634);
            splitContainer1.SplitterDistance = 464;
            splitContainer1.TabIndex = 1;
            // 
            // violinLayout
            // 
            violinLayout.BackColor = Color.White;
            violinLayout.Dock = DockStyle.Fill;
            violinLayout.Location = new Point(0, 0);
            violinLayout.Name = "violinLayout";
            violinLayout.Size = new Size(464, 634);
            violinLayout.TabIndex = 1;
            violinLayout.TabStop = false;
            violinLayout.Paint += ViolinLayoutPaint;
            violinLayout.MouseDown += ViolinLayoutMouseDown;
            violinLayout.Resize += ViolinLayoutResize;
            // 
            // staveBox
            // 
            staveBox.BackColor = Color.White;
            staveBox.Dock = DockStyle.Fill;
            staveBox.Location = new Point(0, 0);
            staveBox.Name = "staveBox";
            staveBox.Size = new Size(952, 634);
            staveBox.TabIndex = 0;
            staveBox.TabStop = false;
            staveBox.Paint += StaveBoxPaint;
            staveBox.MouseDown += StaveBoxMouseDown;
            staveBox.Resize += StaveBoxResize;
            // 
            // tempoSlider
            // 
            tempoSlider.LargeChange = 10;
            tempoSlider.Location = new Point(1070, 3);
            tempoSlider.Maximum = 300;
            tempoSlider.Minimum = 1;
            tempoSlider.Name = "tempoSlider";
            tempoSlider.Size = new Size(268, 45);
            tempoSlider.TabIndex = 1;
            tempoSlider.TickFrequency = 10;
            tempoSlider.Value = 80;
            tempoSlider.Scroll += TempoSliderScroll;
            // 
            // panel1
            // 
            panel1.Controls.Add(newLineButton);
            panel1.Controls.Add(restSisteenth);
            panel1.Controls.Add(restEighth);
            panel1.Controls.Add(restQuarter);
            panel1.Controls.Add(restHalf);
            panel1.Controls.Add(restWhole);
            panel1.Controls.Add(timSignatureButton);
            panel1.Controls.Add(stopButton);
            panel1.Controls.Add(playButton);
            panel1.Controls.Add(deleteButton);
            panel1.Controls.Add(tempoSlider);
            panel1.Controls.Add(keyLabel);
            panel1.Controls.Add(keyDropDown);
            panel1.Controls.Add(semiquaverButton);
            panel1.Controls.Add(quaverButton);
            panel1.Controls.Add(crotchetButton);
            panel1.Controls.Add(minimButton);
            panel1.Controls.Add(semibreveButton);
            panel1.Controls.Add(repeatEndButton);
            panel1.Controls.Add(repeatStartButton);
            panel1.Controls.Add(barButton);
            panel1.Controls.Add(saveButton);
            panel1.Controls.Add(openButton);
            panel1.Controls.Add(newButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1420, 54);
            panel1.TabIndex = 2;
            // 
            // newLineButton
            // 
            newLineButton.Location = new Point(677, 12);
            newLineButton.Name = "newLineButton";
            newLineButton.Size = new Size(32, 32);
            newLineButton.TabIndex = 22;
            newLineButton.Tag = "0.0625";
            newLineButton.UseVisualStyleBackColor = true;
            newLineButton.Click += NewLineButtonClick;
            // 
            // restSisteenth
            // 
            restSisteenth.Image = (Image)resources.GetObject("restSisteenth.Image");
            restSisteenth.Location = new Point(629, 12);
            restSisteenth.Name = "restSisteenth";
            restSisteenth.Size = new Size(32, 32);
            restSisteenth.TabIndex = 21;
            restSisteenth.Tag = "0.0625";
            restSisteenth.UseVisualStyleBackColor = true;
            restSisteenth.Click += RestClick;
            // 
            // restEighth
            // 
            restEighth.Image = (Image)resources.GetObject("restEighth.Image");
            restEighth.Location = new Point(591, 12);
            restEighth.Name = "restEighth";
            restEighth.Size = new Size(32, 32);
            restEighth.TabIndex = 20;
            restEighth.Tag = "0.125";
            restEighth.UseVisualStyleBackColor = true;
            restEighth.Click += RestClick;
            // 
            // restQuarter
            // 
            restQuarter.Image = (Image)resources.GetObject("restQuarter.Image");
            restQuarter.Location = new Point(553, 12);
            restQuarter.Name = "restQuarter";
            restQuarter.Size = new Size(32, 32);
            restQuarter.TabIndex = 19;
            restQuarter.Tag = "0.25";
            restQuarter.UseVisualStyleBackColor = true;
            restQuarter.Click += RestClick;
            // 
            // restHalf
            // 
            restHalf.Image = (Image)resources.GetObject("restHalf.Image");
            restHalf.Location = new Point(515, 12);
            restHalf.Name = "restHalf";
            restHalf.Size = new Size(32, 32);
            restHalf.TabIndex = 18;
            restHalf.Tag = "0.5";
            restHalf.UseVisualStyleBackColor = true;
            restHalf.Click += RestClick;
            // 
            // restWhole
            // 
            restWhole.Image = (Image)resources.GetObject("restWhole.Image");
            restWhole.Location = new Point(477, 12);
            restWhole.Name = "restWhole";
            restWhole.Size = new Size(32, 32);
            restWhole.TabIndex = 17;
            restWhole.Tag = "1";
            restWhole.UseVisualStyleBackColor = true;
            restWhole.Click += RestClick;
            // 
            // timSignatureButton
            // 
            timSignatureButton.Image = (Image)resources.GetObject("timSignatureButton.Image");
            timSignatureButton.Location = new Point(1017, 12);
            timSignatureButton.Name = "timSignatureButton";
            timSignatureButton.Size = new Size(32, 32);
            timSignatureButton.TabIndex = 16;
            timSignatureButton.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            stopButton.Image = (Image)resources.GetObject("stopButton.Image");
            stopButton.Location = new Point(979, 12);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(32, 32);
            stopButton.TabIndex = 15;
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += StopButtonClick;
            // 
            // playButton
            // 
            playButton.Image = (Image)resources.GetObject("playButton.Image");
            playButton.Location = new Point(941, 12);
            playButton.Name = "playButton";
            playButton.Size = new Size(32, 32);
            playButton.TabIndex = 14;
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += PlayButtonClick;
            // 
            // deleteButton
            // 
            deleteButton.Image = (Image)resources.GetObject("deleteButton.Image");
            deleteButton.Location = new Point(439, 12);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(32, 32);
            deleteButton.TabIndex = 13;
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButtonClick;
            // 
            // keyLabel
            // 
            keyLabel.AutoSize = true;
            keyLabel.Location = new Point(754, 21);
            keyLabel.Name = "keyLabel";
            keyLabel.Size = new Size(29, 15);
            keyLabel.TabIndex = 12;
            keyLabel.Text = "Key:";
            // 
            // keyDropDown
            // 
            keyDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            keyDropDown.FormattingEnabled = true;
            keyDropDown.Location = new Point(798, 18);
            keyDropDown.Name = "keyDropDown";
            keyDropDown.Size = new Size(121, 23);
            keyDropDown.TabIndex = 11;
            keyDropDown.SelectedIndexChanged += KeySignatureItemClick;
            // 
            // semiquaverButton
            // 
            semiquaverButton.Image = (Image)resources.GetObject("semiquaverButton.Image");
            semiquaverButton.Location = new Point(401, 12);
            semiquaverButton.Name = "semiquaverButton";
            semiquaverButton.Size = new Size(32, 32);
            semiquaverButton.TabIndex = 10;
            semiquaverButton.Tag = "0.0625";
            semiquaverButton.UseVisualStyleBackColor = true;
            semiquaverButton.Click += NoteButtonClick;
            // 
            // quaverButton
            // 
            quaverButton.Image = (Image)resources.GetObject("quaverButton.Image");
            quaverButton.Location = new Point(363, 12);
            quaverButton.Name = "quaverButton";
            quaverButton.Size = new Size(32, 32);
            quaverButton.TabIndex = 9;
            quaverButton.Tag = "0.125";
            quaverButton.UseVisualStyleBackColor = true;
            quaverButton.Click += NoteButtonClick;
            // 
            // crotchetButton
            // 
            crotchetButton.Image = (Image)resources.GetObject("crotchetButton.Image");
            crotchetButton.Location = new Point(325, 12);
            crotchetButton.Name = "crotchetButton";
            crotchetButton.Size = new Size(32, 32);
            crotchetButton.TabIndex = 8;
            crotchetButton.Tag = "0.25";
            crotchetButton.UseVisualStyleBackColor = true;
            crotchetButton.Click += NoteButtonClick;
            // 
            // minimButton
            // 
            minimButton.Image = (Image)resources.GetObject("minimButton.Image");
            minimButton.Location = new Point(287, 12);
            minimButton.Name = "minimButton";
            minimButton.Size = new Size(32, 32);
            minimButton.TabIndex = 7;
            minimButton.Tag = "0.5";
            minimButton.UseVisualStyleBackColor = true;
            minimButton.Click += NoteButtonClick;
            // 
            // semibreveButton
            // 
            semibreveButton.Image = (Image)resources.GetObject("semibreveButton.Image");
            semibreveButton.Location = new Point(249, 12);
            semibreveButton.Name = "semibreveButton";
            semibreveButton.Size = new Size(32, 32);
            semibreveButton.TabIndex = 6;
            semibreveButton.Tag = "1";
            semibreveButton.UseVisualStyleBackColor = true;
            semibreveButton.Click += NoteButtonClick;
            // 
            // repeatEndButton
            // 
            repeatEndButton.Image = (Image)resources.GetObject("repeatEndButton.Image");
            repeatEndButton.Location = new Point(211, 12);
            repeatEndButton.Name = "repeatEndButton";
            repeatEndButton.Size = new Size(32, 32);
            repeatEndButton.TabIndex = 5;
            repeatEndButton.UseVisualStyleBackColor = true;
            // 
            // repeatStartButton
            // 
            repeatStartButton.Image = (Image)resources.GetObject("repeatStartButton.Image");
            repeatStartButton.Location = new Point(173, 12);
            repeatStartButton.Name = "repeatStartButton";
            repeatStartButton.Size = new Size(32, 32);
            repeatStartButton.TabIndex = 4;
            repeatStartButton.UseVisualStyleBackColor = true;
            // 
            // barButton
            // 
            barButton.Image = (Image)resources.GetObject("barButton.Image");
            barButton.Location = new Point(135, 12);
            barButton.Name = "barButton";
            barButton.Size = new Size(32, 32);
            barButton.TabIndex = 3;
            barButton.UseVisualStyleBackColor = true;
            barButton.Click += BarSeparatorButtonClick;
            // 
            // saveButton
            // 
            saveButton.Image = Properties.Resources.disk;
            saveButton.Location = new Point(79, 12);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(32, 32);
            saveButton.TabIndex = 2;
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButtonClick;
            // 
            // openButton
            // 
            openButton.Image = Properties.Resources.folder;
            openButton.Location = new Point(41, 12);
            openButton.Name = "openButton";
            openButton.Size = new Size(32, 32);
            openButton.TabIndex = 1;
            openButton.UseVisualStyleBackColor = true;
            openButton.Click += OpenButtonClick;
            // 
            // newButton
            // 
            newButton.Image = Properties.Resources.page;
            newButton.Location = new Point(3, 12);
            newButton.Name = "newButton";
            newButton.Size = new Size(32, 32);
            newButton.TabIndex = 0;
            newButton.TextAlign = ContentAlignment.BottomRight;
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += NewMelodyButtonClick;
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Melody Files (*.mld)|*.mld|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Melody";
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Melody Files (*.mld)|*.mld|All Files (*.*)|*.*";
            openFileDialog.Title = "Open Melody";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1420, 688);
            Controls.Add(panel1);
            Controls.Add(splitContainer1);
            KeyPreview = true;
            Name = "MainForm";
            Text = "Violin Tutor";
            PreviewKeyDown += MainForm_PreviewKeyDown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)violinLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)staveBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)tempoSlider).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox violinLayout;
        private PictureBox staveBox;
        //private ToolStripContainer toolStripContainer1;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private TrackBar tempoSlider;
        private Panel panel1;
        private Button openButton;
        private Button newButton;
        private Button saveButton;
        private Button semiquaverButton;
        private Button quaverButton;
        private Button crotchetButton;
        private Button minimButton;
        private Button semibreveButton;
        private Button repeatEndButton;
        private Button repeatStartButton;
        private Button barButton;
        private Label keyLabel;
        private ComboBox keyDropDown;
        private Button timSignatureButton;
        private Button stopButton;
        private Button playButton;
        private Button deleteButton;
        private Button restQuarter;
        private Button restHalf;
        private Button restWhole;
        private Button restSisteenth;
        private Button restEighth;
        private Button newLineButton;
    }
}
