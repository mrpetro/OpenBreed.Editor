﻿namespace OpenBreed.Editor.UI.WinForms.Controls.Levels
{
    partial class LevelEditorCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BodyEditorCtrl = new OpenBreed.Editor.UI.WinForms.Controls.Levels.LevelBodyEditorCtrl();
            this.SuspendLayout();
            // 
            // BodyEditorCtrl
            // 
            this.BodyEditorCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyEditorCtrl.Location = new System.Drawing.Point(0, 0);
            this.BodyEditorCtrl.Name = "BodyEditorCtrl";
            this.BodyEditorCtrl.Size = new System.Drawing.Size(471, 370);
            this.BodyEditorCtrl.TabIndex = 0;
            // 
            // LevelEditorCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BodyEditorCtrl);
            this.Name = "LevelEditorCtrl";
            this.Size = new System.Drawing.Size(471, 370);
            this.ResumeLayout(false);

        }

        #endregion

        private LevelBodyEditorCtrl BodyEditorCtrl;
    }
}
